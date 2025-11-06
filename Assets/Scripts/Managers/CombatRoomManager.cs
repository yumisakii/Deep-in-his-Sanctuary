using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEditor.PackageManager;
using UnityEngine;

public class CombatRoomManager : BaseRoomManager
{
    [SerializeField] private LobbyRoomManager lobby = null;
    [SerializeField] private CombatRoomUIManager uiManager = null;
    [SerializeField] private HUDManager hudManager = null;
    [SerializeField] private QTEHandler qteHandler = null;
    [SerializeField] private List<MonsterData> allMonstersData = new List<MonsterData>();

    private int loopNumber = 1;

    private Weapon weapon = null;
    private List<Monster> randomMonsters = new List<Monster>();

    private Monster currentMonster = null;

    protected override void OnEnable()
    {
        base.OnEnable();

        weapon = Inventory.Instance.GetCurrentWeapon();
        uiManager.SetCurrentWeapon(weapon);

        randomMonsters.Clear();

        AllMonsters.InitAllMonsters(allMonstersData, loopNumber);
        List<Monster> monsters = AllMonsters.GetCopieAllMonsters();

        for (int i = 0; i < 3; i++)
            randomMonsters.Add(UsefulFunctions.GetRandomElementAndDelete(monsters));

        uiManager.SetMonsters(randomMonsters);
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

        monster.Health -= weapon.Damage;

        if (monster.Health <= 0)
            monster.IsAlive = false;

        uiManager.ResetAttackingAndSkillUI();
        uiManager.UpdateMonstersUI();

        qteHandler.StartQTE();


    }

    private void isRoomCleared()
    {
        foreach (Monster monster in randomMonsters)
        {
            if (monster.IsAlive) // If a monster is alive the Room isn't cleared
                return;
        }

        if (PlayerManager.Instance.Player.GetHealth() <= 0)
            return;

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

        isRoomCleared();
    }

    private void PLayerIsDead()
    {
        Debug.Log("You died.");
        gameManager.ChangeRoom(this, lobby);
    }
}
