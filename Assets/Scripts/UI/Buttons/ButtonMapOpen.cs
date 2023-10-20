using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMapOpen : MonoBehaviour
{
    bool isOpen = false;

    public void OnClick()
    {
        isOpen = !isOpen;
        UIManager.Instance.canvasMap.SetActive(isOpen);
    }
}
