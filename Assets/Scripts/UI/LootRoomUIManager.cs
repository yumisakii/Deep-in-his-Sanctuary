using System.Collections.Generic;
using UnityEngine;

public class LootRoomUIManager : MonoBehaviour
{
    [SerializeField] private List<LootSlotUI> lootsSlotList = new List<LootSlotUI>();

    public void SetRandomWeapons(List<Weapon> randomWeapons)
    {
        for (int i = 0; i < lootsSlotList.Count; i++)
        {
            lootsSlotList[i].InitLootSlotUI(randomWeapons[i]);
        }
    }
}
