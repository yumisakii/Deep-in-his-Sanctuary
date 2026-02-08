using System.Collections.Generic;
using UnityEngine;

public class LootRoomManager : BaseRoomManager
{
    [Header("UI Manager")]
    [SerializeField] private LootRoomUIManager uiManager;

    private List<Weapon> randomWeapons = new List<Weapon>();

    public override RoomType Type => RoomType.Loot;

    protected override void OnEnable()
    {
        base.OnEnable();

        randomWeapons.Clear();        

        if (Inventory.Instance == null)
        {
            Debug.LogError("Inventory Singleton is not available! Check execution order.");
            return;
        }

        List<Weapon> weapons = Inventory.Instance.GetCopieAllWeapons();

        for (int i = 0; i < 3; i++)
        {
            randomWeapons.Add(UsefulFunctions.GetRandomElementAndDelete(weapons));
        }

        uiManager.SetRandomWeapons(randomWeapons);
    }

    public void ItemSelected(Weapon weapon)
    {
        Inventory.Instance.AddWeapon(weapon);

        GoToNextRoom();
    }
}
