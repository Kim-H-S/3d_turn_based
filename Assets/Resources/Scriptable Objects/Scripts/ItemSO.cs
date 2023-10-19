using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ItemData/Default", order = 0)]

[Serializable]
public class ItemSO : ScriptableObject
{
    [Header("ItemInfo")]
    public string itemName;
    public string itemInfo;
    public Sprite icon;
}
