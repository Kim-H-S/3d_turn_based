using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempScripts : MonoBehaviour
{
    MapGenerator mg;

    private void Awake()
    {
        MapManager.Instance.GenerateNewMap(10, 10);

        Location? location = null; 
        //test

        for(int i =0; i < 10; i++)
        {
            for(int j = 0; j < 10; j++)
            {
                if (MapManager.Instance.Map[i, j] != null) 
                {
                    location = MapManager.Instance.Map[i, j];
                    break;
                }
                    
            }

            if(location != null)
            {
                break;
            }
        }

        MapManager.Instance.EnterMap(location.LocationPos);
    }
}
