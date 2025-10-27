using UnityEngine;

public abstract class BaseRoomManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager = null;
    [SerializeField] private BaseRoomManager roomManager = null;
    [SerializeField] private Canvas roomCanva = null;
    [SerializeField] private BaseRoomManager nextRoomManager = null;

    protected virtual void OnEnable()
    {
        roomCanva.enabled = true;
    }

    protected virtual void OnDisable()
    {
        roomCanva.enabled = false;
    }

    public void GoToNextRoom()
    {
        gameManager.ChangeRoom(roomManager, nextRoomManager);
    }
}
