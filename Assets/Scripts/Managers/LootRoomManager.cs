using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class LootRoomManager : BaseRoomManager
{
    [SerializeField] private LootRoomUIManager uiManager;

    private Weapon randomWeapon_0 = null;
    private Weapon randomWeapon_1 = null;
    private Weapon randomWeapon_2 = null;

    protected override void OnEnable()
    {
        base.OnEnable();

        AllWeapons.InitAllWeapons();

        List<Weapon> Weapons = AllWeapons.GetCopieAllWeapons();

        randomWeapon_0 = UsefulFunctions.GetRandomElementAndDelete(Weapons);
        randomWeapon_1 = UsefulFunctions.GetRandomElementAndDelete(Weapons);
        randomWeapon_2 = UsefulFunctions.GetRandomElementAndDelete(Weapons);

        uiManager.SetRandomWeapons(randomWeapon_0, randomWeapon_1, randomWeapon_2);
    }
}
