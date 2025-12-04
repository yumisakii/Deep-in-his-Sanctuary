using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LootSlotUI : MonoBehaviour
{
    [Header("Manager")]
    [SerializeField] private LootRoomManager lootRoomManager;
    [SerializeField] private ElementGridUI elementGridUI;

    [Header("UI References")]
    [SerializeField] private Image WeaponIcon = null;
    [SerializeField] private Image SpellIcon = null;
    [SerializeField] private TextMeshProUGUI WeaponName = null;
    [SerializeField] private Button button = null;


    private Weapon weapon = null;

    public void InitLootSlotUI(Weapon newWeapon)
    {
        if (newWeapon == null)
        {
            ResetSlot();
            return;
        }

        weapon = newWeapon;

        WeaponIcon.sprite = Resources.Load<Sprite>("Icons/Weapons/" + weapon.WeaponIconName);
        SpellIcon.sprite = Resources.Load<Sprite>("Icons/Spell/" + weapon.Tier.ToString() + "/" + weapon.SpellIconName);
        WeaponName.text = weapon.Name;

        elementGridUI.UpdateElementGrid(weapon);
    }

    public void ResetSlot()
    {
        weapon = null;
        WeaponIcon.sprite = null;
        SpellIcon.sprite = null;
        WeaponName.text = "";
        elementGridUI.UpdateElementGrid(null);
    }

    public void ItemSelected()
    {
        lootRoomManager.ItemSelected(weapon);
    }
}
