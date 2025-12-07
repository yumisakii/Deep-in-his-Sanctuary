using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private LobbyRoomManager lobbyRoomManager = null;
    [SerializeField] private CombatRoomManager combatRoomManager = null;
    [SerializeField] private LootRoomManager lootRoomManager = null;
    [SerializeField] private ForgeRoomManager forgeRoomManager = null;

    private void Start()
    {
        DisableAll();
        lobbyRoomManager.enabled = true;
        LoadData();
    }

    private void DisableAll()
    {
        combatRoomManager.enabled = false;
        lootRoomManager.enabled = false;
        lobbyRoomManager.enabled = false;
        forgeRoomManager.enabled = false;
    }

    public void ChangeRoom(BaseRoomManager roomManager, BaseRoomManager newRoomManager)
    {
        SaveManager.SaveGame();
        roomManager.enabled = false;
        newRoomManager.enabled = true;
    }

    private void LoadData()
    {
        GameSaveData data = SaveManager.LoadGame();
        if (data != null && data.isRunActive)
        {
            // Restore Health
            // Restore Inventory:
            foreach (var wData in data.inventory)
            {
                Weapon w = WeaponBuilder.BuildWeaponFromSave(wData);
                Inventory.Instance.AddWeapon(w);
            }
        }
        else
        {
            // Start New Run
        }
    }
}
