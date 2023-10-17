using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLoginOpen : MonoBehaviour
{
    public void OnClick()
    {
        UIManager.Instance.windowLogin.SetActive(true);
    }
}
