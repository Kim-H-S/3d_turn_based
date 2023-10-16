using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Canvas")]
    [SerializeField] public GameObject canvasMap;

    //[Header("Buttons")]
    // 셋팅 버튼


    private void Awake()
    {
        Instance = this;
    }

    
}
