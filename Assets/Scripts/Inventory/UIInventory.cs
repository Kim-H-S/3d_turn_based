using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{

    public UIItemSlot[] inventorySlot;
    Item[] itemInSlot;
    List<int> EmptySlot;

    private void Awake()
    {
        InitInventorySlot();
    }

    public void InitInventorySlot()
    {
        inventorySlot = new UIItemSlot[10];
        itemInSlot = new Item[10];
        EmptySlot = new List<int>();

        Transform slotLayout = transform.GetChild(0).GetChild(0);   
        for (int i = 0; i < 10; i++) 
        {
            inventorySlot[i] = slotLayout.GetChild(i).GetComponent<UIItemSlot>();
            EmptySlot.Add(i);
        }
    }

    public bool AddItemToInventory(Item item) 
    {
        if (EmptySlot.Count <= 0) return false;

        EmptySlot.Sort();

        int index = EmptySlot[0];
        EmptySlot.RemoveAt(0);

        itemInSlot[index] = item;
        inventorySlot[index].AddItemUI(item.itemSO);

        return true;
    }

    public void RemoveItemFromInventory(int index) 
    {
        if (itemInSlot[index] == null) return;

        EmptySlot.Add(index);
        inventorySlot[index].RemoveItemUI();

        itemInSlot[index].gameObject.SetActive(true);
        // 아이템의 위치를 플레이어의 위치로 변경해줘야됨 (드랍)
        itemInSlot[index] = null;
    }
}

