using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

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
            MapManager.Instance.GenerateNewMap(Random.Range(3,6), Random.Range(3,6));
        }

        else
        {
            MapManager.Instance.GenerateNewMap(Random.Range(6,11), Random.Range(6,11));
        }

        MapUI.SetActive(true);

        
 
    }

}
