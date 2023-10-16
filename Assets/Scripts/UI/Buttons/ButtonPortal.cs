using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPortal : MonoBehaviour
{
    private string lobbyScene = "Lobby Scene";

    public void OnClick()
    {
        SceneManager.LoadScene(lobbyScene);
    }
}
