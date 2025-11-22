using System.Collections.Generic;
using UnityEngine;

public class ForgeRoomUIManager : MonoBehaviour
{
    [Header("Main Canvas")]
    [SerializeField] private Canvas mainCanvas;

    [Header("Weapon Slots")]
    [SerializeField] private LootSlotUI weaponSlot1;
    [SerializeField] private LootSlotUI weaponSlot2;
    [SerializeField] private LootSlotUI fusedWeaponSlot;

    [Header("Inventory")]
    [SerializeField] private Transform contentParent;
    [SerializeField] private GameObject weaponSlotPrefab;


    private Weapon selectedWeapon1;
    private Weapon selectedWeapon2;

    private List<GameObject> activeSlots = new List<GameObject>();
    
    public void UpdateForgeUI(List<Weapon> inventory)
    {
        UpdateForgeInventoryUI(inventory);
    }

    public void UpdateForgeInventoryUI(List<Weapon> currentInventory)
    {
        ClearActiveSlots();

        foreach (Weapon weapon in currentInventory)
        {
            if (weapon == selectedWeapon1 || weapon == selectedWeapon2) continue;

            InstantiateForgeWeaponSlot(weapon);
        }
    }

    private void InstantiateForgeWeaponSlot(Weapon weapon)
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

    public void OnWeaponDroppedInSlot(int slotIndex, Weapon weapon)
    {
        if (slotIndex == 1)
        {
            selectedWeapon1 = weapon;
            weaponSlot1.InitLootSlotUI(weapon);
        }
        else if (slotIndex == 2)
        {
            selectedWeapon2 = weapon;
            weaponSlot2.InitLootSlotUI(weapon);
        }

        CheckFusionReady();
    }

    private void CheckFusionReady()
    {
        if (selectedWeapon1 != null && selectedWeapon2 != null)
        {
            Debug.Log("Ready to Fuse!");
            // Ici tu pourras appeler ta logique de preview de fusion
        }
    }
}