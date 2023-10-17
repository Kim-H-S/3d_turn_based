using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Canvas")]
    public GameObject canvasMap;
    public GameObject canvasDifficulty;    // Difficulty;난이도
    public GameObject canvasGameClear;
    public GameObject canvasGameOver;

    [Header("Windows")]
    public GameObject windowSetting;
    public GameObject windowEnemyInfo;

    private void Awake()
    {
        Instance = this;
    }

    
}
