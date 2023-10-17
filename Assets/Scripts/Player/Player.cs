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

        m_rigidbody = GetComponent<Rigidbody>();
        Debug.Assert(m_rigidbody != null);

    }


    private void Move(Vector2 direction)
    {
        m_direction = new Vector3(direction.x, 0.0f, direction.y);
    }

    private void FixedUpdate()
    {
        m_rigidbody.velocity = m_direction * m_speed * Time.fixedDeltaTime;
    }

    private Rigidbody   m_rigidbody;

    //Movement
    [SerializeField] private float  m_speed;
    private Vector3                 m_direction;

}
