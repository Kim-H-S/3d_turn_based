using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Texts")]
    public TextMeshPro textPlayerLevel;
    public TextMeshPro textPlayerGold;

    [Header("Canvas")]
    public GameObject canvasMap;
    public GameObject canvasDifficulty;    // Difficulty;난이도
    public GameObject canvasGameClear;
    public GameObject canvasGameOver;

    [Header("Windows")]
    public GameObject windowSetting;
    public GameObject windowLogin;
    public GameObject windowEnemyInfo;

    private void Awake()
    {
        Instance = this;
    }

    
}
