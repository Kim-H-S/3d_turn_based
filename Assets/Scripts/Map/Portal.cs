using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject UIMap; // UIManager를 통해서 참조
 
    private void OnTriggerEnter(Collider other)
    {
        UIMap.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        UIMap.SetActive(false);
    }
}
