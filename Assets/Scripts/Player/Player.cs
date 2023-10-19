using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public void OnMoveKeyInput(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            Move(context.ReadValue<Vector2>());
        }
        else if(context.canceled)
        {
            Move(context.ReadValue<Vector2>());
        }

    }

    public void OnInteractObject(InputAction.CallbackContext context) 
    {
        if (Range.colldingList.Count > 0)
        {
            Range.colldingList[0].Interact();
            if (Range.colldingList[0] == null)
            {
                Range.colldingList.RemoveAt(0);
            }
        } 
    }

    public void OnPickUpItem(InputAction.CallbackContext context)
    {
        if (Range.colldingItemList.Count > 0)
        {
            Range.colldingItemList[0].PickUp();    
            Range.colldingItemList.RemoveAt(0);
            
        }
    }

    private void Awake()
    {

        Debug.Assert(m_rigidbody != null);

    }


    private void Move(Vector2 direction)
    {
        m_direction = direction;
        m_animator.SetFloat("MoveSpeed", m_direction.magnitude);
    }

    private void FixedUpdate()
    {

        m_rigidbody.velocity = transform.forward * m_direction.y * m_moveSpeed * Time.fixedDeltaTime;

        transform.localRotation = Quaternion.Euler(0.0f, m_direction.x * m_rotationSpeed * Time.fixedDeltaTime, 0.0f) * transform.localRotation;

        if (m_body.localPosition != Vector3.zero)
        {
            m_body.localPosition = Vector3.zero;
        }

    }

    [SerializeField] private Rigidbody   m_rigidbody;
    [SerializeField] private Transform m_body;
    public InteractableRange Range;
    //Movement
    [SerializeField] private float  m_moveSpeed;
    [SerializeField] private float  m_rotationSpeed;
    private Vector2                 m_direction;


    //Animation
    [SerializeField] Animator m_animator;

}
