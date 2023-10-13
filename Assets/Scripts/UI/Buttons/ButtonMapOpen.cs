using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMapOpen : MonoBehaviour
{
    

    public void OnClick()
    {
        UIManagerLobby.Instance.canvasMap.SetActive(true);
    }
}
