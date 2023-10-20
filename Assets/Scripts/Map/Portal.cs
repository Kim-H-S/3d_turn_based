using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public GameObject MapUI;
    string SceneName;
    private void Start()
    {
        MapUI = GameManager.Instance.MapUI;
    }


    private void OnTriggerEnter(Collider other)
    {
        SceneName = SceneManager.GetActiveScene().name;
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
