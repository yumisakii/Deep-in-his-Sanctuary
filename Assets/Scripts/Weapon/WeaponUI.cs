using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    [SerializeField] private Image WeaponIcon;
    [SerializeField] private Image SpellIcon;
    [SerializeField] private List<Image> ElementsIcons = new List<Image>();
    
    private Weapon weapon = null;

    public void InitWeapon(Weapon newWeapon)
    {
        weapon = newWeapon;

        WeaponIcon.sprite = Resources.Load<Sprite>("Icons/Weapons/" + weapon.WeaponIconName);
        SpellIcon.sprite = Resources.Load<Sprite>("Icons/Spell/" + weapon.Tier.ToString() + "/" + weapon.SpellIconName);

        UpdateElementGrid(weapon);
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

    public void UpdateElementGrid(Weapon weapon)
    {
        for (int i = 1; i <= 9; i++)
        {
            ElementType type = (ElementType)i;
            bool isActive = weapon.Elements.ContainsKey(type);
            int stackCount = isActive ? weapon.Elements[type] : 0;
            UpdateSpecificElement(type, isActive, stackCount);
        }
    }

    private void UpdateSpecificElement(ElementType type, bool isActive, int stackCount)
    {
        Image imageSlot = GetImageForElement(type);
        if (isActive)
        {
            imageSlot.color = ElementColorMap.GetColor(type);
            // Show the stack count (for later)
            // stackText.text = stackCount.ToString();
        }
        else
        {
            // Not active. Make it dark/transparent.
            imageSlot.color = new Color(0.2f, 0.2f, 0.2f, 0.5f); // Dark gray
            // stackText.text = "";
        }
    }

    private Image GetImageForElement(ElementType type)
    {
        for (int i = 0; i < ElementsIcons.Count; i++)
        {            
            if ((ElementType)(i + 1) == type) // +1 to skip 'None'
            {
                return ElementsIcons[i];
            }
        }

        return null;
    }
}
