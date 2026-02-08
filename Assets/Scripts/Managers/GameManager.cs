using UnityEditor.EditorTools;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private LobbyRoomManager lobbyRoomManager = null;
    [SerializeField] private CombatRoomManager combatRoomManager = null;
    [SerializeField] private LootRoomManager lootRoomManager = null;
    [SerializeField] private ForgeRoomManager forgeRoomManager = null;

    private int loopNumber = 1; 

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

    public void ChangeRoom2(BaseRoomManager currentRoomManager)
    {
        BaseRoomManager newRoomManager = null;

        if (currentRoomManager.Type == RoomType.Combat)
        {
            if (combatRoomManager.IsBossRoom())
                combatRoomManager.SetBossRoom(false);

            newRoomManager = lootRoomManager;
            loopNumber++;
        }

        else if (currentRoomManager.Type == RoomType.Loot)
        {
            if (loopNumber % 3 == 0)
                newRoomManager = forgeRoomManager;
            else
                newRoomManager = combatRoomManager;
        }

        else if (currentRoomManager.Type == RoomType.Forge)
        {
            if (loopNumber % 9 == 0)
            {
                newRoomManager = combatRoomManager;
                combatRoomManager.SetBossRoom(true);
            }
            else
                newRoomManager = combatRoomManager;
        }



        currentRoomManager.enabled = false;
        newRoomManager.enabled = true;
    }

    private void LoadData()
    {
        GameSaveData data = SaveManager.LoadGame();
        if (data != null && data.isRunActive)
        {
            foreach (var wData in data.inventory)
            {
                Weapon w = WeaponBuilder.BuildWeaponFromSave(wData);
                Inventory.Instance.AddWeapon(w);
            }
        }
        else
        {

        }
    }
}
