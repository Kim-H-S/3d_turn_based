using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractableData", menuName = "InteractableData/InteractableData", order = 0)]
public class InteractableSO : ScriptableObject
{
    
    public enum Type
    {
        Gathering,
        DropItem
    }


    public Type type;


    public InteractableSO(InteractableSO so)
    {
        type = so.type;
    }

}
