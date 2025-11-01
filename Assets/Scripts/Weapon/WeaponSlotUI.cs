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

    public void InitWeaponSlotUI(Weapon weapon)
    {
        WeaponIcon.sprite = Resources.Load<Sprite>("Icons/Weapons/" + weapon.Rarity.ToString() + "/" + weapon.WeaponIconName);
        SpellIcon.sprite = Resources.Load<Sprite>("Icons/Spell/" + weapon.Rarity.ToString() + "/" + weapon.SpellIconName);
        WeaponName.text = weapon.Name;
    }
}
