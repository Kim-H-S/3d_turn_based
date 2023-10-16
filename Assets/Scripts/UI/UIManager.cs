using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Canvas")]
    [SerializeField] public GameObject canvasMap;

    [Header("Buttons")]
    [SerializeField] public GameObject buttonMapOpen;
    [SerializeField] public GameObject buttonMapClose;
    // 셋팅 버튼


    private void Awake()
    {
        Instance = this;


    }
}
