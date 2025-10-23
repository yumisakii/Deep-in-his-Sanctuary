using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUIInit : MonoBehaviour
{
    [SerializeField] private Image WeaponIcon;
    [SerializeField] private Image SpellIcon;


    //private string iconName = "Weapon_01";

    public void InitWeapon(string weaponIconName, string spellIconName, Rarity rarity)
    {
        Sprite weaponIcon = Resources.Load<Sprite>("Icons/Weapons/" + rarity.ToString() + "/" + weaponIconName);
        Sprite spellIcon = Resources.Load<Sprite>("Icons/Spell/" + rarity.ToString() + "/" + spellIconName);

        WeaponIcon.sprite = weaponIcon;
        SpellIcon.sprite = spellIcon;
    }
}
