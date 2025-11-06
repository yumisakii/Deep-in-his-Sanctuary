using UnityEngine;

public abstract class BaseRoomManager : MonoBehaviour
{
    [SerializeField] protected GameManager gameManager = null;
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
        gameManager.ChangeRoom(this, nextRoomManager);
    }
}
