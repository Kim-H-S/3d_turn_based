using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTemp : MonoBehaviour
{
    public ItemSO item;
    private void Awake()
    {
    }

    private void Update()
    {
        // 테스트용 레이캐스트

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray,out hit))
            {
                if(hit.collider.gameObject == gameObject)
                {
                    click();
                }
            }
        }
    }

    public void click()
    {
        if (GameManager.Instance.Inventory.AddItemToInventory(item))
        {
            Destroy(gameObject);
        }
    }
}
