using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonNewStart : MonoBehaviour
{
    private string lobbyScene = "Lobby Scene";

    public void OnClick()
    {
        DataManager.Instance.DataInit();
        DataManager.Instance.DataSave();

        SceneManager.LoadScene(lobbyScene);
    }
}
