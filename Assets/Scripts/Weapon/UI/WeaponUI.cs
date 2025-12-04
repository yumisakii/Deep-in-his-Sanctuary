using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    [SerializeField] private Image WeaponIcon;
    [SerializeField] private Image SpellIcon;
    [SerializeField] private ElementGridUI elementGridUI;

    private Weapon weapon = null;

    public void InitWeapon(Weapon newWeapon)
    {
        weapon = newWeapon;

        WeaponIcon.sprite = Resources.Load<Sprite>("Icons/Weapons/" + weapon.WeaponIconName);
        SpellIcon.sprite = Resources.Load<Sprite>("Icons/Spell/" + weapon.Tier.ToString() + "/" + weapon.SpellIconName);

        elementGridUI.UpdateElementGrid(weapon);
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
