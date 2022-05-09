using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Ai_Test : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;

    private Ai_Test _ally;

    
    public GameObject enemy;
    public GameObject ally;
    public GameObject player;

    public LayerMask whatIsGround, whatIsPlayer, whatIsAlly;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    public float timeBetweenWalkPoints;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public int health;
    public int damage;
    

    //Recon
    public Vector3 reconPoint;
    bool reconPointSet;
    // we will use walkPointRange here and multiply it for the Recon
    // we will use timeBetweenWalkPoints here same as for the patrolling

    //States
    public float sightRange, attackRange;
    public bool allyInSightRange, allyInAttackRange, playerInSightRange, playerInAttackRange;



    private void Awake() 
    {
        //ally = GameObject.Find("ally").transform.position;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //player.GetComponent<CharacterCommands>();
        //_Ally = GetComponent<Ai_Test>();
        _ally = FindObjectOfType<Ai_Test>();

        
    }


    private void Start() 
    {
        
    }


    private void Update()
    {

        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        allyInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsAlly);
        allyInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsAlly);

        

        if (!allyInSightRange && !allyInAttackRange || !playerInSightRange && !playerInAttackRange )
        {
            agent.isStopped = false;
            Patroling();
        } 
        
        if (allyInSightRange && !allyInAttackRange)
        {
            agent.isStopped = false;
            ChaseAlly();
        } 

        if (playerInSightRange && !playerInAttackRange)
        {
            agent.isStopped = false;
            ChasePlayer();
        } 
        
        if (allyInSightRange && allyInAttackRange)
        {
            agent.isStopped = true;
            AttackAlly();
        } 
        
        if (playerInSightRange && playerInAttackRange)
        {
            agent.isStopped = true;
            AttackPlayer();
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

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            // there needs to be a delay
            walkPointSet = false;
        }

    }


    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }

    }

    private void ChasePlayer()
    {
       agent.SetDestination(player.transform.position);
    }

    private void ChaseAlly()
    {
        agent.SetDestination(ally.transform.position); 
    }

    private void AttackPlayer()
    {
        //agent.SetDestination(ally.transform.position);

        transform.LookAt(player.transform.position);

        
        if (!alreadyAttacked)
        {
            alreadyAttacked =true;
            Debug.Log("Player was attacked");
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
        

    }

    private void AttackAlly()
    {
        //agent.SetDestination(ally.transform.position);

        transform.LookAt(ally.transform.position);

        
        if (!alreadyAttacked)
        {
            alreadyAttacked =true;
            Debug.Log("Ally was attacked");
            _ally.AllyTakeDamage();
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
        

    }


    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void EnemyTakeDamage()
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(enemy);
        } 
    }

    

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }


    /*
    //Context Menu
    [ContextMenu("Patrol")] 
    public void _Patrol()
    {
        Patroling();
    }

    [ContextMenu("Chaseally")] 
    public void _Chaseally()
    {
        Chaseally();
    }
    */
}   


