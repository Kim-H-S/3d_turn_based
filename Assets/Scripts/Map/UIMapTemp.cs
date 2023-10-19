using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMapTemp : MonoBehaviour
{
   // UIMap의 크기가 Width 1000, Height 1080
    // Icon들의 크기가 Width 50, Height 50
    // Map 배열이 10 * 10 이라고
    // 이라고 가정하고 테스트

    //맵 배열의 크기
    int MapWidth;
    int MapHeight; 

    // UIMap의 크기
    int UIMapWidth = 1000;
    int UIMapHeight = 1080;

    // Icon의 크기
    int IconWidth = 50;
    int IconHeight = 50;

    // Icon사이의 간격
    int IconPaddingWidth = 20;
    int IconPaddingHeight = 20;

    //실제 사용할 맵의 크기
    int realMapWidth;
    int realMapHeight;

    // 맵 배열을 UI로 그릴때 시작 좌표
    int startPosX;
    int startPosY;
    

    public void OnEnable()
    {
        MapWidth = MapManager.Instance.Map.GetLength(1);
        MapHeight = MapManager.Instance.Map.GetLength(0);
        // 실제 맵의 크기 == 하나의 아이콘을 그리는데 필요한 공간 * 아이콘의 갯수 - (마지막 아이콘은 간격이 필요없음)
        realMapWidth = (IconWidth + IconPaddingWidth) * MapWidth - IconPaddingWidth;
        realMapHeight = (IconHeight + IconPaddingHeight) * MapHeight - IconPaddingHeight;

        // 맵 가장자리의 비워둘 공간
        int paddingWidth = (UIMapWidth - realMapWidth) / 2;
        int paddingHeight = (UIMapHeight - realMapHeight) / 2;

        // 아이콘의 시작 좌표를 계산.
        startPosX = -(UIMapWidth) / 2 + (IconWidth + IconPaddingWidth) / 2 + paddingWidth;
        startPosY = -(UIMapHeight) / 2 + (IconHeight + IconPaddingHeight) / 2 + paddingHeight;

        MapManager.Instance.DrawMap(transform, startPosX, startPosY, IconWidth + IconPaddingWidth, IconHeight + IconPaddingHeight);
    }

}
