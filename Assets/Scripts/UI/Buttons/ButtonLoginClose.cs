using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLoginClose : MonoBehaviour
{
    public void OnClick()
    {
        UIManager.Instance.windowLogin.SetActive(false);
    }
}
