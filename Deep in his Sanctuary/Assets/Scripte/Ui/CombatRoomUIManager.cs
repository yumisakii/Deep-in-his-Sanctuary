using UnityEngine;
using UnityEngine.UI;

public class CombatRoomUIManager : MonoBehaviour
{
    [SerializeField] private WeaponUIInit weaponUI;

    public void SetCurrentWeapon(Weapon weapon)
    {
        weaponUI.InitWeapon(weapon.WeaponIconName, weapon.SpellIconName, weapon.Rarity);
        Debug.Log("test1");
    }
}
