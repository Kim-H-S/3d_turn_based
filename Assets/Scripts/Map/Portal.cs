using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public GameObject MapUI;
    string SceneName;
    private void Start()
    {
        MapUI = GameManager.Instance.MapUI;
        SceneName = SceneManager.GetActiveScene().name;
    }
  
    private void OnTriggerEnter(Collider other)
    {
        switch (SceneName)
        {
            case "Lobby Scene":
                UIManager.Instance.canvasDifficulty.SetActive(true);
                break;
            case "Game Scene":
                MapUI.SetActive(true);
                break;
            default:
                break;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        switch (SceneName)
        {
            case "Lobby Scene":
                UIManager.Instance.canvasDifficulty.SetActive(false);
                MapUI.SetActive(false);
                break;
            case "Game Scene":
                MapUI.SetActive(false);
                break;
            default:
                break;
        }
        
    }
}
