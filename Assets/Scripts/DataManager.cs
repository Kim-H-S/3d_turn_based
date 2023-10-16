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

    PlayerData currentPlayerData = new PlayerData();

    string path;
    string filename = "save";

    private void Awake()
    {
        Instance = this;

        DontDestroyOnLoad(this.gameObject);

        path = Application.persistentDataPath + '/';
    }

    private void Start()
    {
        
    }

    public void SaveData()
    {
        string playerdata = JsonUtility.ToJson(currentPlayerData);

        File.WriteAllText(path + filename, playerdata);
    }

    public void LoadData()
    {
        string data = File.ReadAllText(path + filename);

        currentPlayerData = JsonUtility.FromJson<PlayerData>(data);
    }
}
