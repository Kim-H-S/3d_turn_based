using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSettingClose : MonoBehaviour
{
    public void OnClick()
    {
        UIManager.Instance.windowSetting.SetActive(false);
    }
}
