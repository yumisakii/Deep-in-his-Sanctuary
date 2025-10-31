using System.Collections.Generic;
using UnityEngine;

public class CombatRoomManager : BaseRoomManager
{
    [SerializeField] private CombatRoomUIManager uiManager;
    [SerializeField] private List<MonsterData> allMonstersData = new List<MonsterData>();

    private int loopNumber = 1;

    private Monster randomMonster0 = null;
    private Monster randomMonster1 = null;
    private Monster randomMonster2 = null;

    protected override void OnEnable()
    {
        base.OnEnable();

        Weapon newWeapon = new Weapon("Weapon_01", "Red", Rarity.Red);
        uiManager.SetCurrentWeapon(newWeapon);

        AllMonsters.InitAllMonsters(allMonstersData, loopNumber);
        List<Monster> monsters = AllMonsters.GetCopieAllMonsters();

        randomMonster0 = UsefulFunctions.GetRandomElementAndDelete(monsters);
        randomMonster1 = UsefulFunctions.GetRandomElementAndDelete(monsters);
        randomMonster2 = UsefulFunctions.GetRandomElementAndDelete(monsters);

        uiManager.SetMonsters(randomMonster0, randomMonster1, randomMonster2);
    }

    private bool isAttacking = false;
    private bool isUsingSkill = false;

    public void Attack()
    {
        isAttacking = true;
        uiManager.AttackingUI();
        ReadyToAttack();
    }

    public void UseSkill()
    {
        isAttacking = true;
        uiManager.UsingSkillUI();
        ReadyToAttack();
    }

    public void ReadyToAttack()
    {

    }

    public void AttackMonster(Monster monster)
    {
        monster.Health -= 10;
        uiManager.ResetAttackingAndSkillUI();
        uiManager.UpdateMonstersUI();
    }
}
