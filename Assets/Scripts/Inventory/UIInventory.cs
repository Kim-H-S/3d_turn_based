using System;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{

    public UIItemSlot[] inventorySlot;

    public Dictionary<string, int> itemCount = new Dictionary<string, int>();// 어떤아이템이 몇개있는지

    public UICombination UICombination;
    Item[] itemInSlot;// 아이템이 슬롯의 어느위치에 있는지
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

    public int FindIndexItemSO(ItemSO so)
    {
        return Array.FindIndex(itemInSlot, item => item.itemSO.itemName == so.itemName);
    }

    public void AddToDictinary(string name)
    {
        if (itemCount.ContainsKey(name))
        {
            itemCount[name]++;
        }
        else
        {
            itemCount.Add(name, 1);
        }
    }

    public void RemoveFromDictionary(Item item)
    {
        itemCount[item.itemSO.itemName]--;
    }

    public bool AddItemToInventory(Item item) 
    {
        if (EmptySlot.Count <= 0) return false;

        EmptySlot.Sort();

        int index = EmptySlot[0];
        EmptySlot.RemoveAt(0);

        AddToDictinary(item.itemSO.itemName);
        itemInSlot[index] = item;
        inventorySlot[index].AddItemUI(item.itemSO);

        UICombination.UpdateUICombination();

        item.transform.SetParent(GameManager.Instance.transform);
        

        return true;
    }

    public void RemoveItemFromInventory(int index) 
    {
        if (itemInSlot[index] == null) return;

        Item item = itemInSlot[index];
        itemInSlot[index] = null;

        EmptySlot.Add(index);
        inventorySlot[index].RemoveItemUI();

        item.gameObject.SetActive(true);
        // 아이템의 위치를 플레이어의 위치로 변경해줘야됨 (드랍)
        RemoveFromDictionary(item);
        UICombination.UpdateUICombination();
    }
}

