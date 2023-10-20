using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLogin : MonoBehaviour
{
    private string lobbyScene = "Lobby Scene";

    bool bHasSaveFile;

    public void OnClick()
    {
        // 저장된 데이터가 존재하는지 판단한다.
        if (File.Exists(DataManager.Instance.path + DataManager.Instance.filename))
        {
            bHasSaveFile = true;
            DataManager.Instance.DataLoad();
            // 버튼 텍스트 입력
            DataManager.Instance.DataClear();
        }

        if (bHasSaveFile)
        {
            DataManager.Instance.DataLoad();
            SceneManager.LoadScene(lobbyScene);
        }
        else
        {
            Debug.Log("저장된 데이터가 없다.");

            //DataManager.Instance.DataInit();
            //DataManager.Instance.DataSave();

            //SceneManager.LoadScene(lobbyScene);
        }
    }
}
