using UnityEngine;

public class LootRoomUIManager : MonoBehaviour
{
    [SerializeField] private WeaponSlotUI weapon_0;
    [SerializeField] private WeaponSlotUI weapon_1;
    [SerializeField] private WeaponSlotUI weapon_2;

    public void SetRandomWeapons(Weapon weapon0, Weapon weapon1, Weapon weapon2)
    {
        weapon_0.InitWeapon(weapon0.WeaponIconName, weapon0.SpellIconName, weapon0.Name, weapon0.Rarity);
        weapon_1.InitWeapon(weapon1.WeaponIconName, weapon1.SpellIconName, weapon1.Name, weapon1.Rarity);
        weapon_2.InitWeapon(weapon2.WeaponIconName, weapon2.SpellIconName, weapon2.Name, weapon2.Rarity);
    }
}
