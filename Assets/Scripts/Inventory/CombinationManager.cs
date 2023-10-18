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
        itemCount = GameManager.Instance.InventoryUI.itemCount;
    }

    public List<RecipeSO> FindPossibleRecipe()
    {
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
}