using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class DraggableWeapon : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Weapon Weapon { get; private set; }

    private Transform originalParent;
    private Vector3 originalPosition;
    private Canvas mainCanvas;
    private CanvasGroup canvasGroup;

    public void Init(Weapon weapon, Canvas canvas)
    {
        Weapon = weapon;
        mainCanvas = canvas;
    }

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        originalPosition = transform.position;

        if (mainCanvas != null)
        {
            transform.SetParent(mainCanvas.transform, true);
        }

        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (mainCanvas != null)
        {
            RectTransform rectTransform = transform as RectTransform;
            if (rectTransform != null)
            {
                rectTransform.anchoredPosition += eventData.delta / mainCanvas.scaleFactor;
            }
            else
            {
                transform.position = Input.mousePosition;
            }
        }
        else
        {
            transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;

        if (transform != null)
        {
            transform.SetParent(originalParent, true);
            transform.position = originalPosition;
        }
    }
}