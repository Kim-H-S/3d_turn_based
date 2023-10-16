using System;
using System.Collections.Generic;
using UnityEngine;

public class MapManager
{
    private static MapManager _instance;
    public static MapManager Instance 
    {
        get
        {
            if(_instance == null)
            {
                _instance = new MapManager();
            }
            return _instance;
        }
    }

    public MapManager()
    {
        LoadAllMapPrefabs();
    }

    public Location[,] Map { get; private set; }
    public GameObject CurrentLocation { get; private set; }
    
    private Pos PrevLocationPos { get; set; }
    private GameObject PrevLocation { get; set; }

    private MapGenerator _mapGenerator = new MapGenerator();
    private Dictionary<LocationType, List<GameObject>> _mapList = new Dictionary<LocationType, List<GameObject>>();

    public void GenerateNewMap(int xLength, int yLength)
    {
        _mapGenerator.Init(xLength, yLength);
        Map = _mapGenerator.Map;
    }

    public void LoadAllMapPrefabs()
    {
        var gameObjects = Resources.LoadAll("Prefabs/Map");

        foreach(GameObject gameObject in gameObjects) 
        {
            string goName = gameObject.name.Substring(0, gameObject.name.Length - 1);
            if (Enum.TryParse(goName, out LocationType type))
            {
                if (_mapList.ContainsKey(type))
                {
                    _mapList[type].Add(gameObject);
                }
                else
                {
                    _mapList.Add(type, new List<GameObject>());
                    _mapList[type].Add(gameObject);
                }
            }
        }
    }

    public void EnterMap(Pos pos)
    {
        if (Map[pos.Y, pos.X] == null) return;

        if (PrevLocation != null && pos.Y == PrevLocationPos.Y && pos.X == PrevLocationPos.X) 
        {
            GameObject temp = CurrentLocation;
            CurrentLocation = PrevLocation;
            PrevLocation = temp;

            PrevLocation.SetActive(false);
            CurrentLocation.SetActive(true);
        }
        else
        {
            LocationType type = Map[pos.Y, pos.X].LocationType;
            ExitMap();

            if (_mapList[type].Count == 0)
            {
                Debug.Log("해당 타입의 맵이 존재하지 않습니다");
                return;
            }
            int randInt = UnityEngine.Random.Range(0, _mapList[type].Count);
            CurrentLocation = GameObject.Instantiate(_mapList[type][randInt]);
        }
        
    }

    public void ExitMap()
    {
        if (CurrentLocation == null) return;

        if (PrevLocation != null) 
        {
            GameObject.Destroy(PrevLocation);
        }

        PrevLocation = CurrentLocation;
        CurrentLocation.SetActive(false);
    }
}
