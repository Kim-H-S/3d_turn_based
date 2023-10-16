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

    //[Header("Buttons")]
    // 셋팅 버튼


    private void Awake()
    {
        Instance = this;
    }

    
}
