using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractableData", menuName = "InteractableData/Default", order = 0)]
public class InteractableSO :ScriptableObject

{
    public string objectName;
    public int interactionTime;
    public List<GameObject> dropItemLists = new List<GameObject>();

    public InteractableSO(InteractableSO so)
    {
        objectName = so.objectName;
        interactionTime = so.interactionTime;
        dropItemLists = so.dropItemLists;
    }
}
