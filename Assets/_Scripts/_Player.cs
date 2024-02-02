using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

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
    [Space(1)]
    [Header("References")]
    [SerializeField] Animator anim;
    [SerializeField] PlayerFootsteps playerFootsteps;


    [Header("Interaction")]
    [SerializeField] KeyCode InteractionKey = KeyCode.E;
    [SerializeField] GameObject UI_interaction_Pannel;
    [SerializeField] TMP_Text Interaction_Text_;
    [SerializeField] float Interactable_Distance_threshold;


    void Awake()
    {
        rb_ = GetComponent<Rigidbody2D>();
        //InvokeRepeating(nameof(checkFor_InteractableDistance),1f,1f);
    }

    private void Start()
    {
        AmbienceController.instance.SetAmbience3DAttributes(gameObject);
    }

    private void Update()
    {
        //For Interaction Input
        if (Input.GetKeyDown(InteractionKey) && interactable != null)
        {
            InteractionBoolSwitcher();
        }
        checkFor_InteractableDistance();
    }

    void FixedUpdate()
    {
        //Setting MoveInput
        Player_velocity = Move().normalized;

        //Rotation for faceing move direction. Has been changed in favor of walk animations.
        //Rotation();

        //Moving Player
        rb_.velocity = Player_velocity * Time.fixedDeltaTime * MovementSpeed();
        SetAnimatorDirection(Player_velocity);
    }

    void SetAnimatorDirection(Vector2 moveDirection)
    {
        if (moveDirection == Vector2.zero)
        {
            anim.CrossFade("Player_still", 0f);
            return;
        }

        if (moveDirection.x > 0)
        {
            anim.CrossFade("Player_walk_right", 0f);
            return;
        }
        else if (moveDirection.x < 0)
        {
            anim.CrossFade("Player_walk_left", 0f);
            return;
        }

        if (moveDirection.y > 0)
        {
            anim.CrossFade("Player_walk_up", 0f);
            return;
        }
        else if (moveDirection.y < 0)
        {
            anim.CrossFade("Player_walk_down", 0f);
            return;
        }
    }

    void InteractionBoolSwitcher()
    {
        interactable.Interact();
    }
    void Rotation()
    {
        if (Move().magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, Move());
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, RotationDeg * Time.fixedDeltaTime);
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
        Vector2 moveInp = new Vector2(x, y);
        if (moveInp.magnitude > 0.1f)
        {
            return moveInp;
        }
        return Vector2.zero;
    }

    public void RequestFootstep()
    {
        playerFootsteps.RequestFootstep();
    }

    #region Trigger System

    /// <summary>
    /// 
    ///  Triggering System here XD
    ///  
    /// 
    /// </summary>
    /// <param name="collider"></param>

    I_interactable interactable;
    Transform interactable_object;
    void checkFor_InteractableDistance()
    {
        if (interactable == null) return;
        float dist = Vector3.Distance(transform.position, interactable_object.position);
        print(dist);
        if (dist >= Interactable_Distance_threshold)
        {
            interactable_object = null;
            UI_interaction_Pannel.SetActive(false);
            interactable = null;

        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.TryGetComponent(out I_interactable closestIteractable))
        {
            UI_interaction_Pannel.SetActive(true);
            print(UI_interaction_Pannel.activeInHierarchy);
            interactable_object = collider.transform;
            interactable = closestIteractable;
            Interaction_Text_.text = "Press E to Interact";
            
        }

    }

    #endregion


    public void RestartGame(){
        SceneManager.LoadSceneAsync("LOADER");
    }
}
