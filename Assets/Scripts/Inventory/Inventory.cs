using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory
{

    ItemSO[] inventorySlot;
    List<int> EmptySlot;

    public Inventory()
    {
        InitInventorySlot();
    }

    public void InitInventorySlot()
    {
        inventorySlot = new ItemSO[10]; 
        EmptySlot = new List<int>();

        for (int i = 0; i < 10; i++) 
        {
            EmptySlot.Add(i);
        }
    }

    public bool AddItemToInventory(ItemSO item) 
    {
        if (EmptySlot.Count <= 0) return false;

        EmptySlot.Sort();

        int index = EmptySlot[0];
        EmptySlot.RemoveAt(0);

        inventorySlot[index] = item;
        AddItemUI(index);
        return true;
    }

    public void RemoveItemFromInventory(int index) 
    {
        EmptySlot.Add(index);
        RemoveItemUI(index);
        inventorySlot[index] = null;
    }

    public void AddItemUI(int index)
    {
        //ItemSO의 정보를 이용해서 UI를업데이트
        GameManager.Instance.InventoryUI.GetChild(index).GetComponent<Image>().color = UnityEngine.Color.red;
    }

    public void RemoveItemUI(int index)
    {
        //ItemSO의 정보를 이용해서 UI를업데이트
        GameManager.Instance.InventoryUI.GetChild(index).GetComponent<Image>().color = UnityEngine.Color.white;
    }
}

