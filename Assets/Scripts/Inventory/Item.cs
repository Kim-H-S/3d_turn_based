using UnityEngine;


public class Item : MonoBehaviour
{
    public ItemSO itemSO;
    public Canvas canvas;


    private void Awake()
    {
        canvas.gameObject.SetActive(false);
    }
    public void PickUp()
    {
        if (GameManager.Instance.InventoryUI.AddItemToInventory(this))
        {
            gameObject.SetActive(false);
        }
    }

    public void OnInteractUI()
    {
        canvas.gameObject.SetActive(true);
    }

    public void OffInteractUI()
    {
        canvas.gameObject.SetActive(false);
    }
}
