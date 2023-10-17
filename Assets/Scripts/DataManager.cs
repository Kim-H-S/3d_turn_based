using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerData
{
    public int level;
    public int gold;
}

public class DataManager : MonoBehaviour
{
    static public DataManager Instance;

    public PlayerData playerData = new PlayerData();

    [HideInInspector] public string path;
    [HideInInspector] public string filename = "save.txt";

    private void Awake()
    {
        Instance = this;

        DontDestroyOnLoad(this.gameObject);

        path = Application.persistentDataPath + '/';
    }

    private void Start()
    {
        //Debug.Log(path);
    }

    public void DataInit()
    {
        playerData.level = 1;
        playerData.gold = 100;

        DataSave();
    }

    public void DataSave()
    {
        string playerdata = JsonUtility.ToJson(playerData);

        File.WriteAllText(path + filename, playerdata);
    }

    public void DataLoad()
    {
        string data = File.ReadAllText(path + filename);

        playerData = JsonUtility.FromJson<PlayerData>(data);
    }

    public void DataClear()
    {
        playerData = new PlayerData();
    }
}
