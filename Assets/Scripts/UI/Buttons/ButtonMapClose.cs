using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMapClose : MonoBehaviour
{
    public void OnClick()
    {
        UIManager.Instance.canvasMap.SetActive(false);
    }
}
