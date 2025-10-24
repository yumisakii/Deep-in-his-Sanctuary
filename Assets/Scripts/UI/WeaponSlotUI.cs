using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponSlotUI : MonoBehaviour
{
    [SerializeField] private Image WeaponIcon;
    [SerializeField] private Image SpellIcon;
    [SerializeField] private TextMeshProUGUI WeaponName;


    //private string iconName = "Weapon_01";

    public void InitWeapon(string weaponIconName, string spellIconName, string weaponName, Rarity rarity)
    {
        Sprite weaponIcon = Resources.Load<Sprite>("Icons/Weapons/" + rarity.ToString() + "/" + weaponIconName);
        Sprite spellIcon = Resources.Load<Sprite>("Icons/Spell/" + rarity.ToString() + "/" + spellIconName);
        string newWeaponName = weaponName;

        WeaponIcon.sprite = weaponIcon;
        SpellIcon.sprite = spellIcon;
        WeaponName.text = newWeaponName;
    }
}
