using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ally_Ai_Manager : MonoBehaviour
{
    
    public UnityEngine.AI.NavMeshAgent agent;

    private CharacterCommands commands;

    public GameObject _Player;

    public LayerMask whatIsGround;

    //Floats
    //Detection Variables
    public float sightRange, attackRange;
    //Makes sure to keep the enemy a certain distance from the target
    public float minRange;
    
    //Patroling
    
    /*
    public float walkPointRange;
    public float timeBetweenWalkPoints;
    */
    
    public int walkPointRange;
    public int timeBetweenWalkPoints;

    //Attacking
    public float timeBetweenAttacks;
    

    //Bools
    //Detection Variables
    public bool isEnemyTarget;
    //Makes sure to keep the enemy a certain distance from the target
    public bool tooClose;
    //Patroling
    bool walkPointSet;

    //Attacking
    bool alreadyAttacked;

    //Commands
    bool isFollowActive;
    bool isSpreadOutActive;
    bool isFallBackActive;
    bool isEngageActive;

    //Vector3
    public Vector3 walkPoint;
    

    private void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        commands = FindObjectOfType<CharacterCommands>();
    }

    private void Update()
    {
        if(commands.isfollowPlayer == true)
        {
            isFollowActive = true;
            _Follow();
        }
        else
        {
            isFollowActive = false;
        }
        

        if(commands.isSpreadOut == true)
        {
            isSpreadOutActive = true;
            _SpreadOut();
        }
        else
        {
            isSpreadOutActive = false;
        }

        
        if(commands.isFallBack == true)
        {
            isFallBackActive = true;
            _FallBack();
        }
        else
        {
            isFallBackActive = false;
        }


        if(commands.isEngage == true)
        {
            isEngageActive = true;
            _Engage();
        }
        else
        {
            isEngageActive = false;
        }


        


        // --------------------------
        if (!isEnemyTarget)
        {
            agent.isStopped = false;

            if(!isFollowActive)
            {
                Patroling();
            }
            
        } 
        else
        {
            agent.isStopped = true;
            agent.ResetPath();
        }
    }

    
    void OnTriggerEnter(Collider other) 
    {
        
        if (other.tag == "Enemy" && !isEnemyTarget && !isFollowActive || other.tag == "Enemy" && !isEnemyTarget && !isSpreadOutActive || other.tag == "Enemy" && !isEnemyTarget && !isFallBackActive )
        {
            agent.isStopped = false;
            
            isEnemyTarget = true;
            agent.SetDestination(other.transform.position);
            
            Debug.Log("Enemy entered sight");
        } 
        
    }

    void OnTriggerStay(Collider other)
    {

        float distance = Vector3.Distance(transform.position, other.transform.position);
        bool tooClose = distance < minRange;
        bool canAttack = distance < attackRange;

        if (other.tag == "Enemy" && isEnemyTarget && isEngageActive )
        {
            // if the enemy is not close to target, close in
            if(!tooClose)
            {
                agent.isStopped = false;
                agent.SetDestination(other.transform.position);    
            }
            else
            {
                agent.isStopped = true;
                //Debug.Log("Too close");
                AttackTarget();
            }

            /*
            // if the enemy is not close to target, do nothing
            if(!canAttack)
            {

            }
            // if the enemy is close to target attack
            else
            {
                Debug.Log("Enemy attacked Player");
            }
            */

        } 

        
    }
 
    void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Enemy" && isEnemyTarget ) 
        {
           
            agent.isStopped = true;
            agent.ResetPath();
            isEnemyTarget = false;

            Debug.Log("Player left sight");
        }
        
    }


    private void Patroling()
    {
        if(!walkPointSet)
        {
            Invoke(nameof(SearchWalkPoint), timeBetweenWalkPoints);
        }

        if(walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }
        float distanceToWalkPoint = Vector3.Distance(transform.position, walkPoint);
        //Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint < 1f)
        {
            // there needs to be a delay
            walkPointSet = false;
            //Debug.Log("walkPointReset");
        }

    }


    private void SearchWalkPoint()
    {
        //Calculate random point in range
        /*
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        */
        int randomZ = Random.Range(-walkPointRange, walkPointRange);
        int randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }

    }


    private void AttackTarget()
    {
        if (!alreadyAttacked)
        {
            alreadyAttacked =true;
            Debug.Log("Attack has occured");
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    // Commands

    private void _Follow()
    {
        //print("Follow Player");
        print(_Player.transform.position);
        agent.SetDestination(_Player.transform.position);
    }

    private void _SpreadOut()
    {

    }

    private void _FallBack()
    {

    }

    private void _Engage()
    {

    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, minRange);
    }
}
