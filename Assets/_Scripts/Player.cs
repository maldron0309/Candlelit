using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class _Player : MonoBehaviour
{

    Rigidbody2D rb_;
    Vector2 Player_velocity;


    [Header("Movement")]
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;

    void Start()
    {
        rb_ = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        Vector2 movement = Move();
        if (movement.magnitude > 0.1f)
        {
            Player_velocity = movement.normalized;
        }
        else
        {
            Player_velocity = Vector2.zero;
        }
        rb_.velocity = Player_velocity * MovementSpeed();
    }


    float MovementSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            return runSpeed;
        }
        else
        {
            return walkSpeed;
        }
    }

    Vector2 Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // If moving diagonally, prioritize horizontal movement.
        if (Mathf.Abs(x) > 0.5f && Mathf.Abs(y) > 0.5f)
        {
            y = 0;
        }

        return new Vector2(x, y);
    }
}
