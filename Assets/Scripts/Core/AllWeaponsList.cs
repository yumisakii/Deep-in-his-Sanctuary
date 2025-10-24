using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public static class AllWeaponsList
{
    private static List<Weapon> allWeapons = new List<Weapon>();

    public static void InitAllWeapons()
    {
        allWeapons.Clear();
        allWeapons.Add(new Weapon("Weapon_01", "Blue", Rarity.Blue));
        allWeapons.Add(new Weapon("Weapon_02", "Blue", Rarity.Blue));
        allWeapons.Add(new Weapon("Weapon_03", "Blue", Rarity.Blue));
        allWeapons.Add(new Weapon("Weapon_04", "Blue", Rarity.Blue));
        allWeapons.Add(new Weapon("Weapon_05", "Blue", Rarity.Blue));
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
