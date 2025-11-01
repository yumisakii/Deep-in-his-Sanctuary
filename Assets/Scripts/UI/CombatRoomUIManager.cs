using NUnit.Framework;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using Color = UnityEngine.Color;

public class CombatRoomUIManager : MonoBehaviour
{
    [SerializeField] private WeaponUI weaponUI = null;

    [SerializeField] private MonsterUI monster_0 = null;
    [SerializeField] private MonsterUI monster_1 = null;
    [SerializeField] private MonsterUI monster_2 = null;

    [SerializeField] private Button monsterButton_0 = null;
    [SerializeField] private Button monsterButton_1 = null;
    [SerializeField] private Button monsterButton_2 = null;

    private List<MonsterUI> monstersUI = new List<MonsterUI>();

    public void SetCurrentWeapon(Weapon weapon)
    {
        weaponUI.InitWeapon(weapon);
    }

    public void SetMonsters(Monster monster, Monster monster1, Monster monster2)
    {
        monster_0.InitMonsterUI(monster);
        monster_1.InitMonsterUI(monster1);
        monster_2.InitMonsterUI(monster2);

        monstersUI.Add(monster_0);
        monstersUI.Add(monster_1);
        monstersUI.Add(monster_2);
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

        monsterButton_0.enabled = true;
        monsterButton_1.enabled = true;
        monsterButton_2.enabled = true;
    }

    public void UpdateMonstersUI()
    {
        foreach (MonsterUI monsterUI in monstersUI)
            monsterUI.UpdateMonsterUI();
    }
}
