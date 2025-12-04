using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForgeRoomUIManager : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private ForgeRoomManager forgeRoomManager;
    [SerializeField] private Canvas mainCanvas;

    [Header("Weapon Slots")]
    [SerializeField] private LootSlotUI weaponSlot1;
    [SerializeField] private LootSlotUI weaponSlot2;
    [SerializeField] private LootSlotUI fusedWeaponSlot;

    [Header("Inventory")]
    [SerializeField] private Transform contentParent;
    [SerializeField] private GameObject weaponSlotPrefab;

    [Header("Fusion Button")]
    [SerializeField] private Button fusionButton;


    private Weapon selectedWeapon1;
    private Weapon selectedWeapon2;
    private List<GameObject> activeSlots = new List<GameObject>();
    
    public void UpdateForgeUI(List<Weapon> inventory)
    {
        selectedWeapon1 = null;
        selectedWeapon2 = null;
        weaponSlot1.ResetSlot();
        weaponSlot2.ResetSlot();
        fusedWeaponSlot.ResetSlot();
        fusionButton.interactable = false;

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
        //UpdateForgeInventoryUI(Inventory.Instance.GetInventory());
    }

    private void CheckFusionReady()
    {
        if (selectedWeapon1 == null || selectedWeapon2 == null)
        {
            fusionButton.interactable = false;
            fusedWeaponSlot.ResetSlot();
            return;
        }

        Weapon previewWeapon = WeaponBuilder.FuseWeapons(selectedWeapon1, selectedWeapon2);

        if (previewWeapon != null)
        {
            forgeRoomManager.SetWeaponsToFuse(selectedWeapon1, selectedWeapon2);
            fusedWeaponSlot.InitLootSlotUI(previewWeapon);

            fusionButton.interactable = true;
        }
        else
        {
            Debug.Log("Fusion Invalid: Tiers mismatch or incompatible sub-elements.");
            fusionButton.interactable = false;
            fusedWeaponSlot.ResetSlot();
        }
    }

    public void InitFusedWeaponSlot(Weapon fusedWeapon)
    {
        fusedWeaponSlot.InitLootSlotUI(fusedWeapon);
    }

    public void OnFusionButtonClicked()
    {
        selectedWeapon1 = null;
        selectedWeapon2 = null;
        weaponSlot1.ResetSlot();
        weaponSlot2.ResetSlot();
        fusionButton.interactable = false;
    }

    public void ResetSelectedWeapons()
    {
        UpdateForgeUI(Inventory.Instance.GetInventory());
        UpdateForgeInventoryUI(Inventory.Instance.GetInventory());
    }
}