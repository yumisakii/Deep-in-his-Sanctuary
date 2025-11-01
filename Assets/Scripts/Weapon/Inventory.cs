using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }

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

        foreach (WeaponData data in allWeaponData)
            inventory.Add(WeaponBuilder.BuildWeapon(data));

        if (inventory.Count > 0)
            currentWeapon = inventory[0];
    }

    public void AddWeapon(Weapon weapon)
    {
        inventory.Add(weapon);
    }

    public Weapon GetCurrentWeapon()
    {
        if (currentWeapon == null && inventory.Count > 0)
        {
            currentWeapon = inventory[0];
        }

        return currentWeapon;
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
}