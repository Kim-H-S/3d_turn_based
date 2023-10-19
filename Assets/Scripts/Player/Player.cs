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

    }

    [SerializeField] private Rigidbody   m_rigidbody;

    //Movement
    [SerializeField] private float  m_moveSpeed;
    [SerializeField] private float  m_rotationSpeed;
    private Vector2                 m_direction;


    //Animation
    [SerializeField] Animator m_animator;

}
