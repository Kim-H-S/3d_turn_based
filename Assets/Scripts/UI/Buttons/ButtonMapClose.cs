using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMapClose : MonoBehaviour
{
    public void OnClick()
    {
        UIManagerLobby.Instance.canvasMap.SetActive(false);
    }
}
