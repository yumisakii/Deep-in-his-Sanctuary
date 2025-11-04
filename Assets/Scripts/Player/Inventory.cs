using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }

    [SerializeField] private Canvas inventoryCanvas = null;
    [SerializeField] private InventoryUI inventoryUI = null;
    [SerializeField] private List<WeaponData> allWeaponData = new List<WeaponData>();


    private List<Weapon> inventory = new List<Weapon>();
    private Weapon currentWeapon = null;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;

        inventoryCanvas.enabled = false;

        foreach (WeaponData data in allWeaponData)
            inventory.Add(WeaponBuilder.BuildWeapon(data));

        if (inventory.Count > 0)
            SetCurrentWeapon(inventory[0]);

        inventoryUI.RefreshInventoryUI(inventory);
    }

    public void AddWeapon(Weapon weapon)
    {
        inventory.Add(weapon);
        inventoryUI.RefreshInventoryUI(inventory);
    }

    public Weapon GetCurrentWeapon()
    {
        if (currentWeapon == null && inventory.Count > 0)
        {
            currentWeapon = inventory[0];
        }

        return currentWeapon;
    }
    private void SetCurrentWeapon(Weapon weapon)
    {
        currentWeapon = weapon;
        inventoryUI.SetCurrentWeaponUI(weapon);
    }

    public List<Weapon> GetInventory()
    {
        return inventory;
    }

    public List<Weapon> GetCopieInventory()
    {
        List<Weapon> copieInventory = new List<Weapon>(inventory);        
        return copieInventory;
    }

    public void SwitchInventoryVisibility()
    {
        inventoryCanvas.enabled = !inventoryCanvas.enabled;
    }
}