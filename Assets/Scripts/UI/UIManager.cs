using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Canvas")]
    [SerializeField] public GameObject canvasMap;
    [SerializeField] public GameObject canvasDifficulty;    // Difficulty;난이도

    //[Header("Buttons")]
    // 셋팅 버튼


    private void Awake()
    {
        Instance = this;
    }

    
}
