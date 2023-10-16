using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITemp : MonoBehaviour
{
    public GameObject UIMap;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OpenMap);
    }

    private void OpenMap()
    {
        UIMap.SetActive(true);
    }
}
