using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSave : MonoBehaviour
{
    public void OnClick()
    {
        DataManager.Instance.DataSave();

        UIManager.Instance.textPlayerLevel.text = DataManager.Instance.playerData.level.ToString();
        UIManager.Instance.textPlayerGold.text = DataManager.Instance.playerData.gold.ToString();
    }
}
