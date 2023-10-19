using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableRange : MonoBehaviour
{
    public List<InteractableObject> collingList {get; private set;} 
    private void Awake()
    {
        collingList = new List<InteractableObject>();
    }

    private void OnTriggerEnter(Collider other)
    {    
        InteractableObject io = other.GetComponent<InteractableObject>();
        if (io != null)
        {
            collingList.Add(io);
            io.OnInteractUI();

        }
    }

    private void OnTriggerExit(Collider other)
    {
        InteractableObject io = other.GetComponent<InteractableObject>();        
        if (io != null)
        {
            collingList.Remove(io);
            io.OffInteractUI();
        }
    }
}
