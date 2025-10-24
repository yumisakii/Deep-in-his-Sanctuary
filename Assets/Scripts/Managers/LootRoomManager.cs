using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class LootRoomManager : MonoBehaviour
{
    [SerializeField] private LootRoomUIManager uiManager;
    private Weapon randomWeapon_0 = null;
    private Weapon randomWeapon_1 = null;
    private Weapon randomWeapon_2 = null;

    private void Start()
    {
        AllWeaponsList.InitAllWeapons();

        List<Weapon> Weapons = AllWeaponsList.GetCopieAllWeapons();

        randomWeapon_0 = GetRandomElementAndDelete(Weapons);
        randomWeapon_1 = GetRandomElementAndDelete(Weapons);
        randomWeapon_2 = GetRandomElementAndDelete(Weapons);

        uiManager.SetRandomWeapons(randomWeapon_0, randomWeapon_1, randomWeapon_2);
    }

    private T GetRandomElementAndDelete<T>(List<T> list) where T : class
    {
        if (list == null || list.Count == 0)
        {
            Debug.LogError("The list is empty or null");
            return null;
        }

        int randomIndex = Random.Range(0, list.Count);
        T element = list[randomIndex];
        list.RemoveAt(randomIndex);

        return element;
    }
}
