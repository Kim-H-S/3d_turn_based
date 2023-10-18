using System.Collections.Generic;
using Unity.VisualScripting;
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
    // 조합 가능한 아이템이 있다면 해당 아이템의 아이콘을 띄운다.

    // -> 인벤토리의 아이템 종류를 확인하여 가능한 아이템을 리스트에 추가한다.

    // 인벤토리가 변경 될때마다 호출되면된다.


    // 인벤토리는 현재 인벤토리에있는 아이템의 갯수를 종류별로 Dictionary로 관리한다.

    // UICombination에서는 이 Dictionary를 참조한다.

    // Combinartion Manager는 생성될때 Recipe들을 모두 가져와서 List로 관리한다.

    // RecipeSO 들은 재료아이템 Dictionary와 완성 아이템을 가진다.

    // UICombination에서는 CombinationManager를 참조해서 현재 Dictionary의 아이템 갯수를 Combination Manager에게 보내서

    // 만들수 있는 아이템 목록을 뽑아온다.

    // 만들 수있는 아이템목록을 UI에 버튼으로 보여준다.
}