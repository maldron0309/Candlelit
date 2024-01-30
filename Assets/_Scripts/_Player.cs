using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class _Player : MonoBehaviour
{

    Rigidbody2D rb_;
    Vector2 Player_velocity;

    




    [Header("Movement")]
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    [Space(1)]
    [Header("Rotation")]
    [SerializeField] float RotationDeg;



    [Header("Interaction")]
    [SerializeField]KeyCode InteractionKey = KeyCode.Q;
    [SerializeField]GameObject UI_interaction_Pannel;


    void Awake()
    {
        rb_ = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {

        //For Interaction Input
        if(Input.GetKeyDown(InteractionKey)){
            // print("E");
            InteractionBoolSwitcher();
        }



        //Setting MoveInput
        Player_velocity = Move().normalized;

        //Rotation for faceing move direction
        Rotation();


        //Moving Player
        rb_.velocity = Player_velocity * Time.fixedDeltaTime * MovementSpeed();
    }

    void InteractionBoolSwitcher(){
        // print("E_Out");
        if(!_currentLightInteraction)return;
        // print("E_In");
        _currentLightInteraction.isLighted = !_currentLightInteraction.isLighted;
    }
    void Rotation()
    {
        if (Move().magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward,Move());
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation,targetRotation,RotationDeg * Time.fixedDeltaTime);
            rb_.MoveRotation(rotation);
        }

    }
    float MovementSpeed()
    {
        float mSpeed = 0;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            mSpeed = runSpeed;
        }
        else
        {
            mSpeed = walkSpeed;
        }
        // print(mSpeed);
        return mSpeed;
    }
    Vector2 Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 moveInp = new Vector2(x,y);
        if(moveInp.magnitude > 0.1f){
            return moveInp;
        }
        return Vector2.zero;
    }
    
#region Trigger System
    
    /// <summary>
    /// 
    ///  Triggering System here XD
    ///  
    /// 
    /// </summary>
    /// <param name="collider"></param>
    


    public Light_meUp _currentLightInteraction;
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.GetComponent<Light_meUp>()){
            //Lightable object
            _currentLightInteraction = collider.gameObject.GetComponent<Light_meUp>();
            UI_interaction_Pannel.SetActive(true);


            // print("LightMEUP");
        }
    }
    void OnTriggerExit2D(){
        // print("LightMEUP_exit");
        _currentLightInteraction = null;
        UI_interaction_Pannel.SetActive(false);
    }
#endregion
}
