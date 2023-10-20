using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHard : MonoBehaviour
{
    public void OnClick()
    {
        GameManager.Instance.EnterGame(2);
        UIManager.Instance.canvasDifficulty.SetActive(false);
    }
}
