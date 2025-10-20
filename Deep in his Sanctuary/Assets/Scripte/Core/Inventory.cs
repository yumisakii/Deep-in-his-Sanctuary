using System.Collections.Generic;

public class Inventory
{
    List<Weapon> inventory = new List<Weapon>();


    public void AddWeapon(Weapon weapon)
    {
        inventory.Add(weapon);
    }
}


public enum Rarity
{
    Grey,
    Green,
    Blue,
    Purple,
    Red
}
