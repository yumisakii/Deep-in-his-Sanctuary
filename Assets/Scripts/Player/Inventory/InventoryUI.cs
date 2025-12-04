using System.Collections.Generic;
using UnityEngine;
public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Canvas mainCanvas;
    [SerializeField] private Transform contentParent;
    [SerializeField] private GameObject weaponSlotPrefab;
    [SerializeField] private LootSlotUI currentWeaponSlot;

    private List<GameObject> activeSlots = new List<GameObject>();

    public void RefreshInventoryUI(List<Weapon> currentInventory)
    {
        ClearActiveSlots();

        foreach (Weapon weapon in currentInventory)
        {
            InstantiateWeaponSlot(weapon);
        }
    }

    private void InstantiateWeaponSlot(Weapon weapon)
    {
        GameObject newSlot = Instantiate(weaponSlotPrefab);

        newSlot.transform.SetParent(contentParent, false);

        LootSlotUI lootSlotUI = newSlot.GetComponent<LootSlotUI>();

        if (lootSlotUI != null)
            lootSlotUI.InitLootSlotUI(weapon);

        DraggableWeapon draggable = newSlot.GetComponent<DraggableWeapon>();
        if (draggable == null) draggable = newSlot.AddComponent<DraggableWeapon>();

        draggable.Init(weapon, mainCanvas);

        activeSlots.Add(newSlot);
    }

    private void ClearActiveSlots()
    {
        foreach (GameObject slot in activeSlots)
        {
            Destroy(slot);
        }
        activeSlots.Clear();
    }

    public void SetCurrentWeaponUI(Weapon weapon)
    {
        currentWeaponSlot.InitLootSlotUI(weapon);
    }
}
