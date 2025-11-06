using System.Collections.Generic;
using UnityEngine;

public class CombatRoomUIManager : MonoBehaviour
{
    [SerializeField] private WeaponUI weaponUI = null;
    [SerializeField] private List<MonsterUI> monstersUI = new List<MonsterUI>();

    public void SetCurrentWeapon(Weapon weapon)
    {
        weaponUI.InitWeapon(weapon);
    }

    public void SetMonsters(List<Monster> monsters)
    {
        for (int i = 0; i < monstersUI.Count; i++)
        {
            monstersUI[i].InitMonsterUI(monsters[i]);
        }
    }

    public void AttackingUI()
    {
        weaponUI.ScaleUpIcon("weapon");
        MonstersReadyToTakeDamage();
    }
    public void UsingSkillUI()
    {
        weaponUI.ScaleUpIcon("spell");
        MonstersReadyToTakeDamage();
    }

    public void ResetAttackingAndSkillUI()
    {
        weaponUI.ResetWeaponIconScale();
    }

    private void MonstersReadyToTakeDamage()
    {
        // light them up a litle, put a hover effect.

        foreach (MonsterUI monsterUI in monstersUI)
        {
            if (monsterUI.GetMonster().IsAlive)
                monsterUI.SetButtonInteractable(true);
        }
    }

    public void UpdateMonstersUI()
    {
        foreach (MonsterUI monsterUI in monstersUI)
        {
            if (!monsterUI.GetMonster().IsAlive)
                monsterUI.isDead();

            monsterUI.UpdateMonsterUI();
        }

    }
}
