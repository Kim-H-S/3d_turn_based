using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RayCast : MonoBehaviour
{
    private LayerMask layerMask_Enemy;
    private bool toggle_EnemyInformation = false;
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        int layerMask = 1 << layerMask_Enemy;

        layerMask = ~layerMask;

        RaycastHit raycastHit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out raycastHit, Mathf.Infinity, layerMask))
            {
                //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * raycastHit.distance, Color.yellow);
                //Debug.Log("Did Hit");

                OnClick();
            }
            else
            {
                //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                //Debug.Log("Did not Hit");

                OnClick();
            }
        }

        
    }

    void OnClick()
    {
        if (toggle_EnemyInformation)
        {
            UIManager.Instance.enemyInformation.SetActive(true);
        }
        else
        {
            UIManager.Instance.enemyInformation.SetActive(false);
        }

        toggle_EnemyInformation = !toggle_EnemyInformation;
    }
}
