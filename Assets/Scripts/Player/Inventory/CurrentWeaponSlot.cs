using UnityEngine;
using UnityEngine.EventSystems;

public class CurrentWeaponSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        DraggableWeapon draggedItem = eventData.pointerDrag.GetComponent<DraggableWeapon>();

        if (draggedItem != null)
        {
            Inventory.Instance.SetCurrentWeapon(draggedItem.Weapon);
        }
    }
}