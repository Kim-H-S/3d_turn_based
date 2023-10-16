using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempScripts : MonoBehaviour
{
    MapGenerator mg;

    private void Awake()
    {
        MapManager.Instance.GenerateNewMap(10, 10);
    }
}
