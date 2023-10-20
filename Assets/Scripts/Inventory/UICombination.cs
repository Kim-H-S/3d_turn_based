using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICombination : MonoBehaviour 
{
    List<RecipeSO> possibleRecipe;
    Image[] slot;

    private void Awake()
    {
        slot = new Image[5];
        for (int i =0; i< 5; i++)
        {
            slot[i] = transform.GetChild(i).GetComponent<Image>();
        }
        
    }

    public void UpdateUICombination()
    {
        possibleRecipe = CombinationManager.Instance.FindPossibleRecipe();

        foreach(Image image in slot)
        {
            image.gameObject.SetActive(false);
        }
        for (int i = 0; i < possibleRecipe.Count; i++) 
        {
            slot[i].sprite = possibleRecipe[i].combinationItem.GetComponent<Item>().itemSO.icon;
            
            slot[i].gameObject.SetActive(true);
        }
    }

    public void Combination(int index)
    {
        CombinationManager.Instance.Combination(possibleRecipe[index]);
    }

}