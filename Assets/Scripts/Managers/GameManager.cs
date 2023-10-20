using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    public Transform Root;

    public UIInventory InventoryUI;

    public GameObject MapUI;

    public GameObject Player;

    public Camera main;

    Vector3 cameraPosOffset = new Vector3(0, 5, -5);
    Quaternion cameraRotOffset = Quaternion.Euler(30,0,0);

    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        GameInit();
    }

    private void Update()
    {
        ChasingCameraToPlayer();
    }

    public void ChasingCameraToPlayer()
    {
        if (!Player.activeInHierarchy) return;
        if (Player == null) return;

        if (main == null)
        {
            main = Camera.main;
        }
        main.transform.position = Player.transform.position + cameraPosOffset;
        main.transform.rotation = cameraRotOffset;
    }

    public void GameInit()
    {
        MapManager.Instance.EnterLobby();
    } 

    public void EnterGame(int i)
    {
        if ( i == 1) 
        {
            MapManager.Instance.GenerateNewMap(Random.Range(3,5), Random.Range(3,6));
        }

        else
        {
            MapManager.Instance.GenerateNewMap(Random.Range(7,9), Random.Range(6,9));
        }

        MapUI.SetActive(true);

    }

    public void EnterBattleScene()
    {
        Root.gameObject.SetActive(false);
        SceneManager.LoadScene("Battle Test Scene");
    }

    public void ExitBattleScene()
    {
        Root.gameObject.SetActive(true);
        SceneManager.sceneLoaded += WaitSceneLoad;
        SceneManager.LoadScene("Game Scene");
    }

    public void WaitSceneLoad(Scene scene, LoadSceneMode mode)
    {
        Root.gameObject.SetActive(true);
        SceneManager.sceneLoaded -= WaitSceneLoad;
    }

    public void GameOver()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Destroy(SoundManager.Instance.gameObject);
        Destroy(DataManager.Instance.gameObject);  
        SceneManager.LoadScene("Title Scene");
    }
    
}
