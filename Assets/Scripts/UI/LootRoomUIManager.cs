using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class LootRoomUIManager : MonoBehaviour
{    
    [SerializeField] private List<WeaponSlotUI> weaponsSlotList = new List<WeaponSlotUI>();

    public void SetRandomWeapons(List<Weapon> randomWeapons)
    {
        for (int i = 0; i < weaponsSlotList.Count; i++)
        {
            weaponsSlotList[i].InitWeaponSlotUI(randomWeapons[i]);
        }
    }
}
