using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }

    [SerializeField] private Canvas inventoryCanvas = null;
    [SerializeField] private InventoryUI inventoryUI = null;
    [SerializeField] private List<WeaponData> allWeaponData = new List<WeaponData>();

    private List<Weapon> allWeapons = new List<Weapon>();
    private List<Weapon> inventory = new List<Weapon>();
    private Weapon currentWeapon = null;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        inventoryCanvas.enabled = false;

        foreach (WeaponData data in allWeaponData)
            allWeapons.Add(WeaponBuilder.BuildWeapon(data));

        inventory.Add(WeaponBuilder.BuildWeapon(allWeaponData[0]));

        if (inventory.Count > 0)
            SetCurrentWeapon(inventory[0]);

        inventoryUI.RefreshInventoryUI(inventory);
    }

    public void AddWeapon(Weapon weapon)
    {
        inventory.Add(weapon);
        inventoryUI.RefreshInventoryUI(inventory);
    }

    public void RemoveWeapon(Weapon weapon)
    {
        if (inventory.Contains(weapon))
        {
            inventory.Remove(weapon);
            inventoryUI.RefreshInventoryUI(inventory);
            if (currentWeapon == weapon)
            {
                SetCurrentWeapon(inventory.Count > 0 ? inventory[0] : null);
            }
        }
    }

    public Weapon GetCurrentWeapon()
    {
        if (currentWeapon == null && inventory.Count > 0)
        {
            currentWeapon = inventory[0];
        }

        return currentWeapon;
    }
    public void SetCurrentWeapon(Weapon weapon)
    {
        currentWeapon = weapon;
        inventoryUI.SetCurrentWeaponUI(weapon);
    }

    public List<Weapon> GetInventory()
    {
        return inventory;
    }

    public List<Weapon> GetCopieAllWeapons()
    {
        List<Weapon> copieData = new List<Weapon>(allWeapons); 
        return copieData;
    }

    public void SwitchInventoryVisibility()
    {
        inventoryCanvas.enabled = !inventoryCanvas.enabled;
    }
}