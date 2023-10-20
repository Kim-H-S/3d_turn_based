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
    public Location CurrentLocation { get; private set; }
    public GameObject CurrentMap { get; private set; }

    public List<Pos> selectablePos { get; private set; }

    private Location PrevLocation { get; set; }
    private GameObject PrevMap { get; set; }

    private MapGenerator _mapGenerator = new MapGenerator();
    private Dictionary<LocationType, List<GameObject>> _mapList = new Dictionary<LocationType, List<GameObject>>();
    public Dictionary<LocationType, GameObject> _iconList = new Dictionary<LocationType, GameObject>();


    bool isDrawed;

    public void GenerateNewMap(int xLength, int yLength)
    {
        ClearMap();
        _mapGenerator.Init(xLength, yLength);
        Map = _mapGenerator.Map;
        selectablePos = new List<Pos> { new Pos(0, 0), new Pos(xLength - 1, 0), new Pos(0, yLength - 1), new Pos(xLength - 1, yLength - 1) };
        
    }

    public void ClearMap()
    {
        if (Map == null ) return;
        
        isDrawed = false;
        for (int i =0; i< Map.GetLength(0); i++)
        {
            for(int j =0; j< Map.GetLength(1); j++)
            {
                if (Map[i,j] != null )
                {
                    GameObject.Destroy(Map[i, j].Icon);
                }
            }
        }
    }
    public void DrawMap(Transform parent, int startPosX, int startPosY, int width, int height)
    {
        if (isDrawed) return;
        for (int i = 0; i < Map.GetLength(0); i++)
        {
            for (int j = 0; j < Map.GetLength(1); j++)
            {
                Location loaction = Map[i, j];
                if (loaction != null)
                {
                    Vector2 IconPos = new Vector2(startPosX + width * i, startPosY + height * j);
                    loaction.DrawLocationIcon(parent, IconPos);
                }
            }
        }

        isDrawed = true;
    }
    public void LoadAllMapPrefabs()
    {
        var gameObjects = Resources.LoadAll("Prefabs/Location");

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

        gameObjects = Resources.LoadAll("Prefabs/LocationIcon");

        foreach(GameObject gameObject in gameObjects)
        {
            string goName = gameObject.name;
            if(Enum.TryParse(goName, out LocationType type)) 
            {
                _iconList.Add(type, gameObject);
            }
        }
    }

    public void EnterMap(Pos pos)
    {
        if (Map[pos.Y, pos.X] == null) return;

        // 이동할수 있는 좌표가 맞는지 확인
        
        

        if (PrevLocation != null && pos.Y == PrevLocation.LocationPos.Y && pos.X == PrevLocation.LocationPos.X)
        {
            GameObject temp = CurrentMap;
            Location locationTemp = CurrentLocation;

            CurrentLocation = PrevLocation;
            CurrentMap = PrevMap;

            PrevLocation = locationTemp;
            PrevMap = temp; 

            PrevMap.SetActive(false);
            CurrentMap.SetActive(true);
        }
        else
        {
            Location location = Map[pos.Y, pos.X];
            LocationType type = location.LocationType;
            ExitMap();

            if (_mapList[type].Count == 0)
            {
                Debug.Log("해당 타입의 맵이 존재하지 않습니다");
                return;
            }
            int randInt = UnityEngine.Random.Range(0, _mapList[type].Count);
            CurrentLocation = location;
            CurrentMap = GameObject.Instantiate(_mapList[type][randInt]);
        }

        selectablePos = CurrentLocation.AdjLocations;
        if(PrevMap != null) 
        {
            PrevMap.transform.SetParent(GameManager.Instance.Root);
        }
        
        if (CurrentMap != null) 
        {
            CurrentMap.transform.SetParent(GameManager.Instance.Root);
        }
        
        GameManager.Instance.Player.transform.position = CurrentMap.transform.GetChild(4).position;
        GameManager.Instance.EnterBattleScene();
    }

    public void ExitMap()
    {
        if (CurrentMap == null) return;

        if (PrevMap != null) 
        {
            GameObject.Destroy(PrevMap);
        }

        PrevMap = CurrentMap;
        PrevLocation = CurrentLocation;

        CurrentMap.SetActive(false);
    }

    public void EnterLobby()
    {
        CurrentMap  = GameObject.Instantiate((_mapList[LocationType.Lobby][0]));
        CurrentMap.SetActive(true);
    }
}
