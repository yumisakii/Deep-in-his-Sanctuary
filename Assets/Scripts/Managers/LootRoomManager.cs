using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class LootRoomManager : BaseRoomManager
{
    [SerializeField] private LootRoomUIManager uiManager;
    [SerializeField] private Inventory inventory;
    private List<Weapon> randomWeapons = new List<Weapon>();

    protected override void OnEnable()
    {
        base.OnEnable();

        List<Weapon> Weapons = inventory.GetCopieInventory();

        for (int i = 0; i < Weapons.Count; i++)
        {
            randomWeapons.Add(UsefulFunctions.GetRandomElementAndDelete(Weapons));
        }

        uiManager.SetRandomWeapons(randomWeapons);
    }
}
