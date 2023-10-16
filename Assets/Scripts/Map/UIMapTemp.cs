using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMapTemp : MonoBehaviour
{
    Location[,] mapData;

    public GameObject WoodIcon;
    public GameObject StoneIcon;
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
        mapData = MapManager.Instance.Map;
        realMapWidth = (IconWidth + IconPaddingWidth) * MapWidth - IconPaddingWidth;
        realMapHeight = (IconHeight + IconPaddingHeight) * MapHeight - IconPaddingHeight;

        int paddingWidth = (UIMapWidth - realMapWidth) / 2;
        int paddingHeight = (UIMapHeight - realMapHeight) / 2;
        startPosX = -(UIMapWidth) / 2 + (IconWidth + IconPaddingWidth) / 2 + paddingWidth;
        startPosY = -(UIMapHeight) / 2 + (IconHeight + IconPaddingHeight) / 2 + paddingHeight;

        
    }
    public void OnEnable()
    {
        Debug.Log("enable");
        IconSetting();
    }
    public void IconSetting()
    {
        if (isSetting) return;

        for (int i = 0; i < mapData.GetLength(0); i++)
        {
            for (int j = 0; j < mapData.GetLength(1); j++)
            {
                Location loaction = mapData[i, j];
                if (loaction != null)
                {
                    Vector2 IconPos = new Vector2(startPosX + (IconWidth + IconPaddingWidth) * i, startPosY + (IconHeight + IconPaddingHeight) * j);
                    GameObject go;
                    switch (loaction.LocationType)
                    {
                        case LocationType.WoodArea:
                            go = Instantiate(WoodIcon, transform);
                            go.transform.localPosition = (Vector3)IconPos;
                            break;
                        case LocationType.StoneArea:
                            go = Instantiate(StoneIcon, transform);
                            go.transform.localPosition = (Vector3)IconPos;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        isSetting = true;
    }
}
