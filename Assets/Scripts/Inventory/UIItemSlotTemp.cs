using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIItemSlotTemp : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Vector2 initialPosition;
    private Vector2 lastDragPosition;
    public RectTransform limitZone;
    

    private void Awake()
    {
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
            GameManager.Instance.Inventory.RemoveItemFromInventory(transform.GetSiblingIndex(), Camera.main.ScreenToWorldPoint(lastDragPosition));
        }
        transform.position = initialPosition;
    }
}