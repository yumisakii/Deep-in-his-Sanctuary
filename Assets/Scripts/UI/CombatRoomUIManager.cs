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
        weaponUI.InitWeapon(weapon.WeaponIconName, weapon.SpellIconName, weapon.Rarity);
    }

    public void SetMonsters(Monster monster, Monster monster1, Monster monster2)
    {
        monster_0.InitMonsterUI(monster.Name, monster.IconName, monster.MaxHealth, monster.DangerLevel);
        monster_1.InitMonsterUI(monster1.Name, monster1.IconName, monster1.MaxHealth, monster1.DangerLevel);
        monster_2.InitMonsterUI(monster2.Name, monster2.IconName, monster2.MaxHealth, monster2.DangerLevel);

        monstersUI.Add(monster_0);
        monstersUI.Add(monster_1);
        monstersUI.Add(monster_2);
    }

    public void AttackingUI()
    {
        //scale up the weapon icon or something
        weaponUI.ScaleUpWeaponIcon();
        Debug.Log("Attacking !!");

        MonstersReadyToTakeDamage();
    }
    public void UsingSkillUI()
    {
        //same here
        Debug.Log("Using skill !!");

        MonstersReadyToTakeDamage();
    }

    private void MonstersReadyToTakeDamage()
    {
        // light them up a litle, put a hover effect.

        monsterButton_0.enabled = true;
        monsterButton_1.enabled = true;
        monsterButton_2.enabled = true;
    }
}
