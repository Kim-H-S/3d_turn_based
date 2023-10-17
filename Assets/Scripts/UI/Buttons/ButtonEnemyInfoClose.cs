using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEnemyInfoClose : MonoBehaviour
{
    public void OnClick()
    {
        UIManager.Instance.windowEnemyInfo.SetActive(false);
    }
}
