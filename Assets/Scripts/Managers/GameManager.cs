using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] LobbyRoomManager lobbyRoomManager;
    [SerializeField] CombatRoomManager combatRoomManager;
    [SerializeField] LootRoomManager lootRoomManager;


    private bool inRun = false;

    private void Start()
    {
        DisableAll();
        lobbyRoomManager.enabled = true;
    }

    private void Game()
    {
        if (!inRun)
        {
            lobbyRoomManager.enabled = true;
        }
    }

    private void DisableAll()
    {
        combatRoomManager.enabled = false;
        lootRoomManager.enabled = false;
        lobbyRoomManager.enabled = false;
    }

    public void ChangeRoom(BaseRoomManager roomManager, BaseRoomManager newRoomManager)
    {
        roomManager.enabled = false;
        newRoomManager.enabled = true;
    }
}
