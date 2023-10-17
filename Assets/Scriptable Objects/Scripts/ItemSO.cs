using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ItemData/Default", order = 0)]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public string itemInfo;
}
