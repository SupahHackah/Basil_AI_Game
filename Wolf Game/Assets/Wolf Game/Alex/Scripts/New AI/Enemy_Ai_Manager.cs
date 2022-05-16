using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Ai_Manager : MonoBehaviour
{
    
    public UnityEngine.AI.NavMeshAgent agent;

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
    public float _enemy_health;
    public float _take_damage;

    //Bools
    //Detection Variables
    public bool isPlayerTarget, isAllyTarget;
    //Makes sure to keep the enemy a certain distance from the target
    public bool tooClose;
    //Patroling
    bool walkPointSet;

    //Attacking
    bool alreadyAttacked;

    //Vector3
    public Vector3 walkPoint;
    

    private void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void Update()
    {
        if (!isPlayerTarget || !isAllyTarget)
        {
            agent.isStopped = false;
            Patroling();
        } 
        else
        {
            agent.isStopped = true;
            agent.ResetPath();
        }
    }

    
    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player" && !isAllyTarget)
        {
            agent.isStopped = false;
            
            isPlayerTarget = true;
            agent.SetDestination(other.transform.position);
            
            Debug.Log("Player entered sight");
        } 


        if (other.tag == "Ally" && !isPlayerTarget)
        {
            agent.isStopped = false;
            
            isAllyTarget = true;
            agent.SetDestination(other.transform.position);
            
            Debug.Log("Ally entered sight");
        } 
        
    }

    void OnTriggerStay(Collider other)
    {

        float distance = Vector3.Distance(transform.position, other.transform.position);
        bool tooClose = distance < minRange;
        bool canAttack = distance < attackRange;

        if (other.tag == "Player" && isPlayerTarget )
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

        if (other.tag == "Ally" && isAllyTarget )
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
                Debug.Log("Enemy attacked Ally");
            }
            */
        }
    }
 
    void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Player" && !isAllyTarget ) 
        {
           
            agent.isStopped = true;
            agent.ResetPath();
            isPlayerTarget = false;

            Debug.Log("Player left sight");
        }
        

        if (other.tag == "Ally" && !isPlayerTarget ) 
        {
           
            agent.isStopped = true;
            agent.ResetPath();
            isAllyTarget = false;

            Debug.Log("Ally left sight");
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

    public void _Enemy_TakeDamage()
    {
        _enemy_health -= _take_damage;

        Debug.Log("Damage was inflicted");
        if (_enemy_health <= 0)
        {
            Debug.Log("Killed");
            Destroy(this.gameObject);
        }
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
