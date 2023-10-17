using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEnemyInfoOpen : MonoBehaviour
{
    public void OnClick()
    {
        UIManager.Instance.windowEnemyInfo.SetActive(true);
    }
}
