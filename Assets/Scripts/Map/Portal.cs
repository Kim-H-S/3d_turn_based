using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Portal : MonoBehaviour
{
    public GameObject MapUI;
    private void Start()
    {
        MapUI = GameManager.Instance.MapUI;
    }
    private void Update()
    {
        // 임시로 레이캐스트로 작동
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    MapManager.Instance.ExitLobby();
                    MapUI.SetActive(true);
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        MapUI.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        MapUI.SetActive(false);
    }
}
