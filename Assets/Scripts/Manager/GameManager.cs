using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    public UIInventory InventoryUI;

    public GameObject MapUI;


    public ResourceRepository ResourceRepository = new ResourceRepository();

    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        GameInit();
    }

    public void GameInit()
    {
        MapManager.Instance.EnterLobby();
        Transform tempPos = MapManager.Instance.CurrentMap.transform.GetChild(4).transform;
        Camera.main.transform.position = tempPos.position + new Vector3(0, 10, 0);
        Camera.main.transform.rotation = Quaternion.Euler(45, 0, 0);
        MapManager.Instance.GenerateNewMap(4, 4);
    }

}
