using System.Collections.Generic;
using UnityEngine;

public class CombinationManager
{
    private static CombinationManager _instance;
    public static CombinationManager Instance { get { return _instance ?? (_instance = new CombinationManager()); } }

    public RecipeSO[] Recipes { get; private set; }

    Dictionary<string, int> itemCount;

    public CombinationManager()
    {
        LoadAllRecipe();
    }
    
    public void LoadAllRecipe()
    {
        Recipes = Resources.LoadAll<RecipeSO>("Scriptable Objects/Objects/Recipe");
        
    }

    public List<RecipeSO> FindPossibleRecipe()
    {
        itemCount = GameManager.Instance.InventoryUI.itemCount;
        List<RecipeSO> possibleList = new List<RecipeSO>();

        foreach (RecipeSO recipe in Recipes) 
        {
            if (CheckRecipe(recipe.requiredItems))
            {
                possibleList.Add(recipe);
            }
        }

        return possibleList;
    }

    public bool CheckRecipe(List<RecipeData> list)
    {
        bool isPossible = true;

        foreach(RecipeData data in list) 
        {
            string key = data.itemSO.itemName;
            if (itemCount.ContainsKey(key) && itemCount[key] >= data.count)
            {
                continue;
            }
            else
            {
                isPossible = false;
                break;
            }
            
        }

        return isPossible;
    }

    public void Combination(RecipeSO recipes)
    {
        foreach(RecipeData data in recipes.requiredItems)
        {
            for(int i =0; i< data.count; i++)
            {
                int index = GameManager.Instance.InventoryUI.FindIndexItemSO(data.itemSO);
                GameManager.Instance.InventoryUI.DestroyItemFromInventory(index);
            }
        }
        GameObject go = GameObject.Instantiate(recipes.combinationItem);
        go.SetActive(false);
        go.transform.SetParent(GameManager.Instance.transform);
        GameManager.Instance.InventoryUI.AddItemToInventory(go.GetComponent<Item>());
        // 인벤토리에 생성된 아이템을 넣어줌
    }
}