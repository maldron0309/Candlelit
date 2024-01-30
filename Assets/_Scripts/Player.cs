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



        //Check if player trying to move || not
        if (Move().magnitude > 0.1f)
        {
            Player_velocity = Move().normalized;
        }
        else
        {
            Player_velocity = Vector2.zero;
        }

        rb_.velocity = Player_velocity * Time.fixedDeltaTime * MovementSpeed();
    }

    float MovementSpeed()
    {
        float mSpeed = 0;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            mSpeed = runSpeed;
        }else{
            mSpeed = walkSpeed;
        }
        // print(mSpeed);
        return mSpeed;
    }
    Vector2 Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        return new Vector2(x, y);
    }
}
