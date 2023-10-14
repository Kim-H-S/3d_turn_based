using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempScripts : MonoBehaviour
{
    MapGenerator mg;

    private void Awake()
    {
        mg = new MapGenerator();
        mg.Init(10, 10);
    }
}
