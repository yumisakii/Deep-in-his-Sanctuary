using UnityEngine;

public abstract class BaseRoomManager : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] protected GameManager gameManager = null;
    [SerializeField] private BaseRoomManager nextRoomManager = null;

    [Header("Room Canvas")]
    [SerializeField] protected Canvas roomCanva = null;

    protected virtual void OnEnable()
    {
        roomCanva.enabled = true;
    }

    protected virtual void OnDisable()
    {
        roomCanva.enabled = false;
    }

    public virtual RoomType Type => RoomType.Base;

    public void GoToNextRoom()
    {
        gameManager.ChangeRoom(this, nextRoomManager);
    }
}
