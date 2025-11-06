using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    [SerializeField] private Image WeaponIcon;
    [SerializeField] private Image SpellIcon;
    
    private Weapon weapon = null;

    public void InitWeapon(Weapon newWeapon)
    {
        weapon = newWeapon;

        Sprite weaponIcon = Resources.Load<Sprite>("Icons/Weapons/" + weapon.Rarity.ToString() + "/" + weapon.WeaponIconName);
        Sprite spellIcon = Resources.Load<Sprite>("Icons/Spell/" + weapon.Rarity.ToString() + "/" + weapon.SpellIconName);

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
