using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ItemData", menuName = "ItemData/Default", order = 0)]
public class ItemSO : ScriptableObject
{
    [Header("ItemInfo")]
    public string itemName;
    public string itemInfo;
    public Sprite icon;
}
