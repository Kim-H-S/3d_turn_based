using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMapOpen : MonoBehaviour
{
    

    public void OnClick()
    {
        UIManager.Instance.canvasMap.SetActive(true);
    }
}
