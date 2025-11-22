using UnityEngine;
using UnityEngine.EventSystems;

public class ForgeSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private ForgeRoomUIManager manager;
    [SerializeField] private int slotIndex;

    public void OnDrop(PointerEventData eventData)
    {
        DraggableWeapon draggedItem = eventData.pointerDrag.GetComponent<DraggableWeapon>();

        if (draggedItem != null)
        {
            manager.OnWeaponDroppedInSlot(slotIndex, draggedItem.WeaponData);
            Destroy(draggedItem.gameObject);
        }
    }
}