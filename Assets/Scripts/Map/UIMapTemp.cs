using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMapTemp : MonoBehaviour
{
    public bool isDraw = false;
   // UIMap의 크기가 Width 1000, Height 1080
    // Icon들의 크기가 Width 50, Height 50
    // Map 배열이 10 * 10 이라고
    // 이라고 가정하고 테스트

    int MapWidth = 10;
    int MapHeight = 10; 

    int UIMapWidth = 1000;
    int UIMapHeight = 1080;

    int IconWidth = 50;
    int IconHeight = 50;

    int IconPaddingWidth = 20;
    int IconPaddingHeight = 20;

    int realMapWidth;
    int realMapHeight;

    int startPosX;
    int startPosY; 

    public bool isSetting = false;
    private void Awake()
    {
        realMapWidth = (IconWidth + IconPaddingWidth) * MapWidth - IconPaddingWidth;
        realMapHeight = (IconHeight + IconPaddingHeight) * MapHeight - IconPaddingHeight;

        int paddingWidth = (UIMapWidth - realMapWidth) / 2;
        int paddingHeight = (UIMapHeight - realMapHeight) / 2;

        startPosX = -(UIMapWidth) / 2 + (IconWidth + IconPaddingWidth) / 2 + paddingWidth;
        startPosY = -(UIMapHeight) / 2 + (IconHeight + IconPaddingHeight) / 2 + paddingHeight;

        
    }
    public void OnEnable()
    {
        if (isDraw) return;

        MapManager.Instance.DrawMap(transform, startPosX, startPosY, IconWidth + IconPaddingWidth, IconHeight + IconPaddingHeight);
        isDraw = true;  
    }

}
