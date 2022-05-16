using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    // variable to store character animator component
    Animator animator;

    // variables to store optimized setter/getter parameter IDs
    int isWalkingHash;
    int isRunningHash;

    // variable to store the instance of Test ( Action Input System )
    Fox_Input input;

    // variables to store player input values ( animations )
    Vector2 currentMovement;
    bool movementPressed;
    bool runPressed;

    //-------------------------------------------------------------------
    //-------------------------------------------------------------------


    // Input fields
    //private CharacterActionAsset characterActionAsset;
    private InputAction move;


    // Layer Mask for Jumping
    [SerializeField] private LayerMask groundLayerMask;

    // Movement fields
    private Rigidbody rb;
    [SerializeField] public float movementForce = 1f;
    [SerializeField] public float jumpForce = 5f;
    [SerializeField] public float dodgeForce = 5f;
    [SerializeField] public float sprint = 2f;
    [SerializeField] public float maxSpeed = 5f;
    private Vector3 forceDirection = Vector3.zero;

    private bool isSprinting;

    [SerializeField] private Camera playerCamera;

    [Header("Ground Detection")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundRadius;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private bool isGrounded;




    private void Awake()
    {

        input = new Fox_Input();

        input.CharacterControls.Movement.performed += ctx =>
        {
            // set the player input values using listeners
            currentMovement = ctx.ReadValue<Vector2>();
            movementPressed = currentMovement.x != 0 || currentMovement.y != 0;
        };
        input.CharacterControls.Run.performed += ctx => runPressed = ctx.ReadValueAsButton();

        //--------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------

        // Assign rigidbody and Input Action Asset
        rb = this.GetComponent<Rigidbody>();

        //characterActionAsset = new CharacterActionAsset();

        
    }


    private void Update()
    {
        handleAnimations();
    }


    private void FixedUpdate() 
    {   // Sphere check for isGrounded.
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, (int)whatIsGround);
        isGrounded = Physics.CheckBox(groundCheck.position, new Vector3(1, groundRadius, 1), Quaternion.Euler(0, 0, 0), (int)whatIsGround);

        //Debug.Log(isGrounded);
        //Debug.Log(forceDirection);
        //Debug.Log(maxSpeed);
        

        forceDirection +=  move.ReadValue<Vector2>().x * GetCameraRight(playerCamera);
        forceDirection +=  move.ReadValue<Vector2>().y * GetCameraForward(playerCamera);

        rb.AddForce(forceDirection, ForceMode.Impulse);
        forceDirection = Vector3.zero;

        if(rb.velocity.y < 0f)
            rb.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;
    
        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0;
        if(horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed)
            rb.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * rb.velocity.y;


        if(isSprinting)
        {
            if(maxSpeed < 7)
            {
                maxSpeed = maxSpeed * sprint;
            }
            
        }
        else
        {
            if(maxSpeed > 7)
            {
                maxSpeed = maxSpeed / sprint;
            }
        }

        LookAt();
    }


    private void LookAt()
    {
        Vector3 direction = rb.velocity;
        direction.y = 0f;

        if(move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
            this.rb.rotation = Quaternion.LookRotation(direction, Vector3.up);
        else
            rb.angularVelocity = Vector3.zero;
    }


    private Vector3 GetCameraForward(Camera playerCamera)
    {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera playerCamera)
    {
        Vector3 right = playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }

    // You need to generate a method for DoJump since it is not defined.
    // This needs to be done for all the other actions.

    // Below is for the Jump Action
    private void DoJump(InputAction.CallbackContext obj)
    {
        
        if(isGrounded)
        {
            forceDirection += Vector3.up * jumpForce;
        }
        
    }


    private void DoRun(InputAction.CallbackContext obj)
    {
        Debug.Log("Sprinting");   
        if(!isSprinting)
            isSprinting = true;
        else
            isSprinting = false;
    }


    private void DoAttack(InputAction.CallbackContext obj)
    {
        
        
        
    }


    private void DoDodge(InputAction.CallbackContext obj)
    {
        
        forceDirection +=  move.ReadValue<Vector2>().x * GetCameraRight(playerCamera) * dodgeForce;
        forceDirection +=  move.ReadValue<Vector2>().y * GetCameraForward(playerCamera) * dodgeForce;
        Debug.Log("Dodge was performed");
        

    }


    private void DoInteract(InputAction.CallbackContext obj)
    {
        
        
        
    }

    private void handleAnimations()
    {
        // get parameter values from animator
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);

        // start walking if movement pressed is true and not already walking
        if (movementPressed && !isWalking)
        {
            animator.SetBool(isWalkingHash, true);
        }

        //stop walking if movementPressed is false and not already walking
        if (!movementPressed && isWalking)
        {
            animator.SetBool(isWalkingHash, false);
        }

        // start running if movement pressed and run pressed is true and not already running
        if ((movementPressed && runPressed) && !isRunning)
        {
            animator.SetBool(isRunningHash, true);
        }

        // stop running if movement pressed or run pressed is false and currently running
        //if ((!movementPressed && !runPressed) && isRunning)  This is for toggle to run
        if ((movementPressed && !runPressed) && isRunning) //This is for hold to run
        {
            animator.SetBool(isRunningHash, false);
        }
    }

    // here we have 3 options for calling actions. Either started, cancelled or performed.
    // += to subscribe to an event -= to unsubscribe to an event
    private void OnEnable()
    {
        // Action Asset         >   Action Map    >     Action  >   Action Call     >   Subscription    >   Method
        // characterActionAsset .   BasicMovement .     Jump    .   started                 +=              DoJump;

        // List of actions from Action Map BasicMovement
        input.CharacterControls.Jump.started += DoJump;
        input.CharacterControls.Run.started += DoRun;
        input.CharacterControls.Attack.started += DoAttack;
        input.CharacterControls.Dodge.started += DoDodge;
        input.CharacterControls.Interact.started += DoInteract;

        move = input.CharacterControls.Movement;
        input.CharacterControls.Enable();
    }


    private void OnDisable()
    {
        // List of actions 
        input.CharacterControls.Jump.started -= DoJump;
        input.CharacterControls.Run.started -= DoRun;
        input.CharacterControls.Attack.started -= DoAttack;
        input.CharacterControls.Dodge.started -= DoDodge;
        input.CharacterControls.Interact.started -= DoInteract;

        input.CharacterControls.Disable();
    }

}
