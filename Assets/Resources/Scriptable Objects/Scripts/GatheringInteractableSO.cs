using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GatheringInteractableData", menuName = "InteractableData/GatheringInteractableData", order = 0)]
public class GatheringInteractableSO : InteractableSO
{
    public string objectName;
    public int interactionTime;
    public List<GameObject> dropItemLists = new List<GameObject>();

    public GatheringInteractableSO(GatheringInteractableSO so) : base(so)
    {
        objectName = so.objectName;
        interactionTime = so.interactionTime;
        dropItemLists = so.dropItemLists;
    }
}
