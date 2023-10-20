using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemTemp : InteractableObject
{

    public ItemSO item;

    public override void Interact()
    {
        click();
    }

    public void click()
    {
        if (GameManager.Instance.Inventory.AddItemToInventory(item))
        {
            Destroy(gameObject);
        }
    }
}
