using UnityEngine;

public class CombatRoomUIManager : MonoBehaviour
{
    [SerializeField] private WeaponUIInit weaponUI;
    [SerializeField] private MonsterUIInit monster_0;
    [SerializeField] private MonsterUIInit monster_1;
    [SerializeField] private MonsterUIInit monster_2;

    public void SetCurrentWeapon(Weapon weapon)
    {
        weaponUI.InitWeapon(weapon.WeaponIconName, weapon.SpellIconName, weapon.Rarity);
    }

    public void SetMonsters(Monster monster, Monster monster1, Monster monster2)
    {
        monster_0.InitMonster(monster.Name, monster.IconName, monster.DangerLevel);
        monster_1.InitMonster(monster1.Name, monster1.IconName, monster1.DangerLevel);
        monster_2.InitMonster(monster2.Name, monster2.IconName, monster2.DangerLevel);
    }
}
