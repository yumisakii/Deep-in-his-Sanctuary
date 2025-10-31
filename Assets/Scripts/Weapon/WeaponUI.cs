using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
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

    public void ScaleUpIcon(string icon)
    {
        if (icon == "weapon")
            UsefulFunctions.ScaleImage(WeaponIcon, 1.2f);
        else if (icon == "spell")
            UsefulFunctions.ScaleImage(SpellIcon, 1.2f);
    }

    public void ResetWeaponIconScale()
    {
        UsefulFunctions.ResetImageScale(WeaponIcon);
        UsefulFunctions.ResetImageScale(SpellIcon);
    }
}
