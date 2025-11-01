using System.Collections.Generic;
using UnityEngine;

public class CombatRoomManager : BaseRoomManager
{
    [SerializeField] private CombatRoomUIManager uiManager = null;

    [SerializeField] private List<MonsterData> allMonstersData = new List<MonsterData>();

    private int loopNumber = 1;

    private Weapon weapon = null;
    private List<Monster> randomMonsters = new List<Monster>();

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
        monster.Health -= weapon.Damage;

        if (monster.Health <= 0)
            monster.IsAlive = false;

        uiManager.ResetAttackingAndSkillUI();
        uiManager.UpdateMonstersUI();

        if (isRoomCleared())
            RoomCleared();

    }

    private bool isRoomCleared()
    {
        foreach (Monster monster in randomMonsters)
        {
            if (monster.IsAlive) // If a monster is alive the Room isn't cleared
                return false;
        }
        return true; // Could also call RoomCleared here
    }

    private void RoomCleared() // Listening to Briney Spears rn
    {
        // Some place for congrats effects

        GoToNextRoom();
    }
}
