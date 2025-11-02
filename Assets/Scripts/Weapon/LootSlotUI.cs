using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LootSlotUI : MonoBehaviour
{
    [SerializeField] private LootRoomManager lootRoomManager;

    [SerializeField] private Image WeaponIcon = null;
    [SerializeField] private Image SpellIcon = null;
    [SerializeField] private TextMeshProUGUI WeaponName = null;
    [SerializeField] private Button button = null;


    private Weapon weapon = null;

    public void InitLootSlotUI(Weapon newWeapon)
    {
        weapon = newWeapon;

        WeaponIcon.sprite = Resources.Load<Sprite>("Icons/Weapons/" + weapon.Rarity.ToString() + "/" + weapon.WeaponIconName);
        SpellIcon.sprite = Resources.Load<Sprite>("Icons/Spell/" + weapon.Rarity.ToString() + "/" + weapon.SpellIconName);
        WeaponName.text = weapon.Name;
    }

    public void SelectItem()
    {
        lootRoomManager.ItemSelected(weapon);
    }
}
