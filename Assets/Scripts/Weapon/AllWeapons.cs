using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public static class AllWeapons
{
    private static List<Weapon> allWeapons = new List<Weapon>();

    public static void InitAllWeapons(List<WeaponData> dataList)
    {
        allWeapons.Clear();

        foreach (WeaponData data in dataList)
        {
            allWeapons.Add(WeaponBuilder.BuildWeapon(data));
        }
    }

    public static void InitAllWeaponsList(List<Weapon> weapons)
    {
        foreach (Weapon weapon in  weapons)
            allWeapons.Add(weapon);
    }
    
    public static List<Weapon> GetAllWeapons()
    {
        return allWeapons;
    }
    public static List<Weapon> GetCopieAllWeapons()
    {
        List<Weapon> newWeapons = allWeapons;
        return newWeapons;
    }


}
