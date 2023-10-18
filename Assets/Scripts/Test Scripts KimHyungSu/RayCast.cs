using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RayCast : MonoBehaviour
{
    private LayerMask layerMask_Enemy;

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
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * raycastHit.distance, Color.yellow);
                Debug.Log("Did Hit");
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = new Ray(transform.position, transform.forward);
        //    RaycastHit raycastHit;

        //    int layerMask = 1 << LayerMask.NameToLayer("Enemy");

        //    //if (Physics.Raycast(ray, out raycastHit, 10, layerMask, QueryTriggerInteraction.Ignore))
        //    if (Physics.Raycast(ray, out raycastHit, 10, layerMask))
        //    {
        //        print("레이");
        //    }
        //}
    }

}
