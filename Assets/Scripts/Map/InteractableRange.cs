using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableRange : MonoBehaviour
{
    public List<InteractableObject> colldingList {get; private set;}
    public List<Item> colldingItemList { get; private set; }
    private void Awake()
    {
        colldingList = new List<InteractableObject>();
        colldingItemList = new List<Item>();    

    }

    private void OnTriggerEnter(Collider other)
    {           
        InteractableObject io = other.GetComponent<InteractableObject>();
        Item item = other.GetComponent<Item>();
        if (io != null)
        {
            colldingList.Add(io);
            io.OnInteractUI();

        }
        else if(item != null)
        {
            colldingItemList.Add(item);
            item.OnInteractUI();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        InteractableObject io = other.GetComponent<InteractableObject>();
        Item item = other.GetComponent<Item>();
        if (io != null)
        {
            colldingList.Remove(io);
            io.OffInteractUI();
        }
        else if (item != null) 
        {
            colldingItemList.Remove(item);
            item.OffInteractUI();
        }
    }
}
