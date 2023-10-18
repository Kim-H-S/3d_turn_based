using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RecipeData
{
    public ItemSO itemSO;
    public int count;
}

[CreateAssetMenu(fileName = "CombinationData", menuName = "CombinationData/Default", order = 0)]

public class RecipeSO : ScriptableObject
{
    public List<RecipeData> requiredItems = new List<RecipeData>();

    public GameObject combinationItem;

    public GameObject Combination()
    {
        // UIManager가 들고있는 Inventory에 접근해서 아이템 갯수를 수정
        return Instantiate(combinationItem);
    }
}
