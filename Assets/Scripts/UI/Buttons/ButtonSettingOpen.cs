using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSettingOpen : MonoBehaviour
{
    public void OnClick()
    {
        UIManager.Instance.windowSetting.SetActive(true);
    }
}
