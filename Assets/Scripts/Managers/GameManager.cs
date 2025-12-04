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
        roomManager.enabled = false;
        newRoomManager.enabled = true;
    }
}
