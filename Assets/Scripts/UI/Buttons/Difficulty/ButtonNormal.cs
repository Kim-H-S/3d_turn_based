using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNormal : MonoBehaviour
{
    public void OnClick()
    {
        GameManager.Instance.EnterGame(1);
        UIManager.Instance.canvasDifficulty.SetActive(false);
    }
}
