using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fox_Movement : MonoBehaviour
{
    // variable to store enemy ai script reference
    private Enemy_Ai_Manager _enemy;
    // variable to store character animator component
    Animator animator;

    // variables to store optimized setter/getter parameter IDs
    int isWalkingHash;
    int isRunningHash;

    int isJumpingHash;
    int isDashingHash;

    int isAttackingHash;
    int isDeadHash;

    // variable to store the instance of Test ( Action Input System )
    Fox_Input input;

    // variables to store player input values
    Vector2 currentMovement;
    bool movementPressed;
    bool runPressed;

    bool jumpPressed;
    bool dashPressed;

    bool attackPressed;
    public bool dead;


    // variable to store character controller component
    public CharacterController controller;

    // variable to store camera for character movement
    public Transform cam;

    // variables for character moveset
    public float speed = 3f;
    // multiplier value to use for speed
    public float sprint = 2f;
    float _sspeed = 1;
    // variable used to control when the player can dash
    bool _isRunning;
    // dash value
    public float dashSpeed = 20f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    // variable for attack range and attack delay
    public float attackRange = 5f;
    public float timeBetweenAttacks = 1f;

    // variable for jumping
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    // variables for gravity
    public float gravity = -9.81f;
    Vector3 velocity;

    // Health and Damage Variables
    public float player_Health;
    public float player_Damage;

    // test
    float _targetAngle;

    // attack and death animation float variables
    bool _attacked;
    int attackNum;
    int deadNum;


    
    void Awake()
    {
        _enemy = FindObjectOfType<Enemy_Ai_Manager>();

        input = new Fox_Input();

        input.CharacterControls.Movement.performed += ctx =>
        {
            // set the player input values using listeners
            currentMovement = ctx.ReadValue<Vector2>();
            movementPressed = currentMovement.x !=0 || currentMovement.y !=0; 
        };
        input.CharacterControls.Run.performed       += ctx => runPressed = ctx.ReadValueAsButton();
        
        input.CharacterControls.Jump.performed      += Jump;

        input.CharacterControls.Dodge.performed     += Dash;

        input.CharacterControls.Attack.performed    += Attack;
    }


    // Start is called before the first frame update
    void Start()
    {
        // set the animator reference
        animator = GetComponent<Animator>();

        // set the ID references
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");

        isJumpingHash = Animator.StringToHash("isJumping");
        isDashingHash = Animator.StringToHash("isDashing");

        isAttackingHash = Animator.StringToHash("isAttacking");
        isDeadHash = Animator.StringToHash("isDead");

    }

    // Update is called once per frame
    void Update()
    {
        handleMovement();
        handleJump();
        handleDash();
        handleGravity();
        handleAttack();
        handleHealth();
        handleAnimation ();
    }

    void handleMovement()
    {
        // The variable that controls character movement
        Vector3 direction = new Vector3(currentMovement.x, 0, currentMovement.y).normalized;

        if(direction.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // test
            _targetAngle = targetAngle;

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDir * speed * _sspeed * Time.deltaTime);
            // If run button is not pressed use walk speed else use sprint speed
            if (!runPressed)
            {
                _sspeed = 1;
            }
            else
            {
                _sspeed = sprint;
            }
            
        }
    }

    void handleJump()
    {
        if(jumpPressed)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            //jumpPressed = false;
        }
        
    }

    void handleDash()
    {
        if(dashPressed)
        {
            Vector3 moveDir = Quaternion.Euler(0f, _targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDir * speed * dashSpeed * Time.deltaTime);
            //dashPressed = false;
        }
    }


    void handleGravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); 

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void handleAttack()
    {
        if(attackPressed)
        {
            attackNum = Random.Range(0, 11);
            //Debug.Log("attacked");
            //Debug.Log(attackNum);
            //attackPressed = false;
            
            if (!_attacked)
            {
                _attacked = true;
                //Debug.Log("Attack has occured");
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
            }
        }
    }


    private void ResetAttack()
    {
        attackPressed = false;
        _attacked = false;
    }

    public void handleHealth()
    {
        

        
        if (player_Health <= 0)
        {
            Debug.Log("Killed");
            dead = true;
            //Destroy(this.gameObject);
        }

        if (dead)
        {
            deadNum = Random.Range(0, 11);
            //Debug.Log(deadNum);
        }
         
    }


    [ContextMenu("PlayerTakeDamage")]
    public void playerTakeDamage()
    {
        player_Health -= player_Damage;
        Debug.Log("Player Health:" + " " + player_Health);
    }


    void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            jumpPressed = true;
        }  
    }

    void Dash(InputAction.CallbackContext context)
    {
        if(isGrounded && !_isRunning)
        {
            dashPressed = true;            
        }
        
    }


    void Attack(InputAction.CallbackContext context)
    {
        if (!attackPressed)
        {
            attackPressed = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }


    // This is our function that will trigger the damage onto the enemy
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            //Debug.Log("Enemy in attack range");
        }

        if (_attacked && other.tag == "Enemy")
        {
            Debug.Log("Damage was initiated");
            _enemy._Enemy_TakeDamage();
            _attacked = false;
        }
    }


    void handleAnimation()
    {
        // get parameter values from animator
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);

        bool isDashing = animator.GetBool(isDashingHash);
        bool isJumping = animator.GetBool(isJumpingHash);

        bool isAttacking = animator.GetBool(isAttackingHash);
        bool isDead = animator.GetBool(isDeadHash);


        // isGrounded
        if(isGrounded)
        {
            animator.SetBool("isGrounded", true);
        } 
        else
        {
            animator.SetBool("isGrounded", false);
        }

        // start walking if movement pressed is true and not already walking
        if(movementPressed && !isWalking)
        {
            animator.SetBool(isWalkingHash, true);
        }

        //stop walking if movementPressed is false and already walking
        if(!movementPressed && isWalking)
        {
            animator.SetBool(isWalkingHash, false);
        }

        // start running if movement pressed and run pressed is true and not already running
        if((movementPressed && runPressed) && !isRunning)
        {
            animator.SetBool(isRunningHash, true);
            _isRunning = true;
        }

        // stop running if movement pressed or run pressed is false and currently running
      //if ((!movementPressed && !runPressed) && isRunning)  This is for toggle to run
        if ((movementPressed && !runPressed) && isRunning) //This is for hold to run
        {
            animator.SetBool(isRunningHash, false);
            _isRunning = false;
        }

        // Dash if dash pressed along movement pressed and is walking and is not dashing
        if(dashPressed && !isDashing) 
        {
            animator.SetBool(isDashingHash, true);
            dashPressed = false;
        }

        // stop dash when movement pressed but dash not pressed but is dashing
        if (!dashPressed && isDashing)
        {
            animator.SetBool(isDashingHash, false);
            
        }


        if(jumpPressed && !isJumping)
        {
            animator.SetBool(isJumpingHash, true);
            jumpPressed = false;

        }


        if (!jumpPressed && isJumping)
        {
            animator.SetBool(isJumpingHash, false);
            
        }


        if (attackPressed && !isAttacking)
        {
            animator.SetBool(isAttackingHash, true);
            animator.SetInteger("whatAttack", attackNum);
            //Debug.Log("attacked");
            attackPressed = false;

        }


        if(!attackPressed && isAttacking)
        {
            animator.SetBool(isAttackingHash, false);
        }


        if(dead && !isDead)
        {
            animator.SetBool(isDeadHash, true);
            animator.SetInteger("whatDeath", deadNum);
            dead = false;
        }


        if (!dead && isDead)
        {
            animator.SetBool(isDeadHash, false);
        }

    }

    void OnEnable()
    {
        
        input.CharacterControls.Enable();
    }

    void OnDisable()
    {
        
        input.CharacterControls.Disable();
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
