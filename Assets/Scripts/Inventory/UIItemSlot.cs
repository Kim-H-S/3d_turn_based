using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[Serializable]

public class UIItemSlot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Vector2 initialPosition;
    private Vector2 lastDragPosition;
    private RectTransform limitZone;

    private UIInventory inventory;
    public Image icon;
    
    

    private void Awake()
    {
        inventory = GetComponentInParent<UIInventory>();
        limitZone = transform.parent.GetComponent<RectTransform>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 delta = eventData.position - lastDragPosition;
        transform.position = (Vector2)transform.position + delta;
        lastDragPosition = eventData.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        initialPosition = transform.position;
        lastDragPosition = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!RectTransformUtility.RectangleContainsScreenPoint(limitZone, eventData.position))
        {
            //아이템을 인벤토리에서 꺼내서 바닥에버림 나중에 플레이어의 위치로 변경
            inventory.RemoveItemFromInventory(transform.GetSiblingIndex());
        }
        transform.position = initialPosition;
    }

    public void AddItemUI(ItemSO itemSO)
    {
        icon.sprite = itemSO.icon;
        icon.gameObject.SetActive(true);
    }

    public void RemoveItemUI()
    {
        icon.sprite = null;
        icon.gameObject.SetActive(false);
    }
}
