using System.Collections.Generic;
using System.Threading;
using UnityEditor.EditorTools;
using UnityEditor.PackageManager;
using UnityEngine;

public class CombatRoomManager : BaseRoomManager
{
    [Header("Special Managers")]
    [SerializeField] private CombatRoomUIManager uiManager = null;
    [SerializeField] private LobbyRoomManager lobby = null;
    [SerializeField] private HUDManager hudManager = null;
    [SerializeField] private QTEHandler qteHandler = null;

    [Header("Prefabs")]
    [SerializeField] private GameObject prefabParents = null;
    [SerializeField] private GameObject monsterPrefab = null;
    [SerializeField] private GameObject bossPrefab = null;

    [Header("Scriptables Objects Data")]
    [SerializeField] private List<MonsterData> allMonstersData = new List<MonsterData>();
    [SerializeField] private List<StatusEffectData> allStatusEffectData = new List<StatusEffectData>();



    private bool isBossRoom = false;

    private Weapon currentWeapon = null;
    private List<GameObject> currentMonstersSlots = new List<GameObject>();
    private List<Monster> currentMonstersData = new List<Monster>();

    private Monster currentMonster = null;

    private int numberOfMonsters = 3;

    public override RoomType Type => RoomType.Combat;

    protected override void OnEnable()
    {
        base.OnEnable();

        Inventory.Instance.onChangeCurrentWeaponTriggerd.AddListener(UpdateCurrentWeapon);

        UpdateCurrentWeapon();

        currentMonstersSlots.Clear();
        currentMonstersData.Clear();

        AllMonsters.InitAllMonsters(allMonstersData, loopNumber);
        List<Monster> monsters = AllMonsters.GetCopieAllMonsters();


        if (isBossRoom)
        {
            float value = Random.value;
            if (value < 0.7f)
                numberOfMonsters = 1;
            else
                numberOfMonsters = 2;
        }
        else
        {
            float value = Random.value;

            if (value < 0.5f)
                numberOfMonsters = 2;
            else if (value < 0.85f)
                numberOfMonsters = 3;
            else
                numberOfMonsters = 4;
        }

        GameObject prefab = null;

        if (isBossRoom)
            prefab = bossPrefab;
        else
            prefab = monsterPrefab;


        for (int i = 0; i < numberOfMonsters; i++)
        {
            GameObject newMonsterSlot = Instantiate(prefab, Vector3.zero, Quaternion.identity, prefabParents.transform);

            currentMonstersSlots.Add(newMonsterSlot);
            currentMonstersData.Add(UsefulFunctions.GetRandomElementAndDelete(monsters));
        }

        uiManager.SetMonsters(currentMonstersData, currentMonstersSlots);
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        Inventory.Instance.onChangeCurrentWeaponTriggerd.RemoveListener(UpdateCurrentWeapon);
    }

    public void Awake()
    {
        StatusEffectBuilder.InitAllStatusEffects(allStatusEffectData);
    }

    public void Attack()
    {
        uiManager.AttackingUI();
    }

    public void UseSkill()
    {
        uiManager.UsingSkillUI();
    }

    public void AttackMonster(Monster monster)
    {
        currentMonster = monster;

        monster.TakeDamage(currentWeapon.Damage);


        foreach (var pair in currentWeapon.Elements)
        {
            ElementType type = pair.Key;
            int stackCount = pair.Value;

            StatusEffect newStatusEffect = StatusEffectBuilder.BuildStatusEffect(type, currentWeapon.Damage, stackCount);

            if (newStatusEffect != null)
            {
                monster.ApplyStatus(newStatusEffect);
            }
        }

        ProcessTurnEffectsOnAllMonsters();
        monster.CheckIfAlive();

        uiManager.ResetAttackingAndSkillUI();
        uiManager.UpdateMonstersUI();


        if (monster.IsAlive)
            qteHandler.StartQTE(monster);
        else
            isRoomCleared();
    }

    private void ProcessTurnEffectsOnAllMonsters()
    {
        foreach (Monster monster in currentMonstersData)
            monster.ProcessTurnEffects();
    }

    private void isRoomCleared()
    {        
        foreach (Monster monster in currentMonstersData)
        {
            if (monster.IsAlive) // If a monster is alive the Room isn't cleared
                return;
        }

        RoomCleared();
    }

    private void RoomCleared()
    {
        // congrats effects or somth

        GoToNextRoom();
    }

    public void QTESuccess(int success)
    {
        if (success == 0)
        {
            PlayerManager.Instance.Player.TakeDamage(currentMonster.Damage);
        }
        else if (success == 1)
        {
            PlayerManager.Instance.Player.TakeDamage(Mathf.RoundToInt(currentMonster.Damage/2)); // Rounding to never have x.5 hp.
        }
        else if (success == 2)
        {
            return;
        }
        else
        {
            Debug.LogError("QTESuccess() didn't return an expected value.");
        }

        hudManager.UpdateHUD();

        if (PlayerManager.Instance.Player.GetHealth() <= 0)
            PLayerIsDead();
        else
            isRoomCleared();
    }

    private void PLayerIsDead()
    {
        Debug.Log("You died.");
        gameManager.ChangeRoom(this, lobby);
    }

    private void UpdateCurrentWeapon()
    {
        currentWeapon = Inventory.Instance.GetCurrentWeapon();
        uiManager.SetCurrentWeapon(currentWeapon);
    }

    public void SetBossRoom(bool isBoss)
    {
        isBossRoom = isBoss;
    }

    public bool IsBossRoom()
    {
        return isBossRoom;
    }
}
