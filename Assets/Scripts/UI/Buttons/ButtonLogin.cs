using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLogin : MonoBehaviour
{
    private string lobbyScene = "Lobby Scene";

    public void OnClick()
    {
        SceneManager.LoadScene(lobbyScene);
    }
}
