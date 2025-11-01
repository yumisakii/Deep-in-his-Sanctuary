using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<WeaponData> allWeaponData = new List<WeaponData>();

    private List<Weapon> inventory = new List<Weapon>();
    private Weapon currentWeapon = null;

    private void Start()
    {
        foreach (WeaponData data in allWeaponData)
            inventory.Add(WeaponBuilder.BuildWeapon(data));

        currentWeapon = inventory[0];
    }

    public void AddWeapon(Weapon weapon)
    {
        inventory.Add(weapon);
    }

    public Weapon GetCurrentWeapon()
    {
        return currentWeapon;
    }

    public List<Weapon> GetInventory()
    {
        return inventory;
    }

    public List<Weapon> GetCopieInventory()
    {
        List<Weapon> copieInventory = inventory;
        return copieInventory;
    }
}