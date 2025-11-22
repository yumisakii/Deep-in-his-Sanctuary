using System.Collections.Generic;
using UnityEngine;

public class ForgeRoomManager : BaseRoomManager
{
    [Header("UI Manager")]
    [SerializeField] private ForgeRoomUIManager uiManager;

    private List<Weapon> currentInventory = new List<Weapon>();

    protected override void OnEnable()
    {
        base.OnEnable();

        currentInventory = Inventory.Instance.GetInventory();

        uiManager.UpdateForgeUI(currentInventory);
    }
}
