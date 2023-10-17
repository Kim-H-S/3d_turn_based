using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    public Inventory Inventory = new Inventory();

    public Transform tempPos;

    public Transform InventoryUI;

    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
        Camera.main.transform.position = tempPos.position + new Vector3(0, 10, 0);
        Camera.main.transform.rotation = Quaternion.Euler(45, 0, 0);
    }

    private void Start()
    {
        GameInit();
    }

    public void GameInit()
    {
        MapManager.Instance.GenerateNewMap(4, 4);
    }

}
