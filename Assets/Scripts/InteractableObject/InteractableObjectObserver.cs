using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableObjectObserver : MonoBehaviour
{

    public InteractableObject NearestInteractableObjectScript => m_nearestInteractableObjectScript;

    private void Update()
    {


        var interactableObjectScriptList            = GameManager.Instance.ResourceRepository.InteractableObjectScriptList;
        m_nearestInteractableObjectDistance         = m_detectionRange;
        m_nearestInteractableObjectScript           = null;
        for (int i = 0; i < interactableObjectScriptList.Count; ++i)
        {

            //게임 오브젝트가 파괴되었으면 리스트에서 제거합니다.
            if (interactableObjectScriptList[i] == null)
            {
                interactableObjectScriptList.Remove(interactableObjectScriptList[i]);
                continue;
            }

            var interactableObject = interactableObjectScriptList[i].gameObject;

            //가장 가까운 객체를 찾습니다.
            float distance = Vector3.Distance(transform.position, interactableObject.transform.position);
            if(distance < m_nearestInteractableObjectDistance)
            {

                var InteractableObjectScript = interactableObject.GetComponent<InteractableObject>();

                m_nearestInteractableObjectDistance = distance;
                m_nearestInteractableObjectScript   = InteractableObjectScript;

            }

        }


    }

    [SerializeField] private float      m_detectionRange;


    private float               m_nearestInteractableObjectDistance;
    private InteractableObject  m_nearestInteractableObjectScript;

}
