using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ai_Test : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;

    private Enemy_Ai_Test _enemy;

    public GameObject ally;
    public GameObject enemy;
    public GameObject player;

    public LayerMask whatIsGround, whatIsEnemy;

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
    public bool enemyInSightRange, enemyInAttackRange, playerFollow;

    float _distance;
    public float followDistance = 5;


    private void Awake() 
    {
        //enemy = GameObject.Find("enemy").transform.position;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //player.GetComponent<CharacterCommands>();
        //_Enemy = GetComponent<Enemy_Ai_Test>();
        _enemy = FindObjectOfType<Enemy_Ai_Test>();
        

        
    }


    private void Start() 
    {
        playerFollow = false;
    }


    private void Update()
    {
        // Inputs
        /*
        if ( Input.GetButtonDown("Command1") )
        {
            playerFollow = true;
    
            //print("e was pressed");

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            playerFollow = false;
            //print("r was pressed");
        }
        */

        /*
        if(player.GetComponent<CharacterCommands>().followPlayer == true)
        {
            playerFollow = true;
        }
        else
        {
            playerFollow = false;
        }
        */

        //Check for sight and attack range
        enemyInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsEnemy);
        enemyInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsEnemy);

        //Check for ally and enemy distance
        float _distance = Vector3.Distance(enemy.transform.position, transform.position);
        //print("Distance to other: " + _distance);

        if (!enemyInSightRange || !enemyInAttackRange  && !playerFollow)
        {
            agent.isStopped = false;
            Patroling();
        } 
        // if _distance is bigger than followDistance, follow player
        if (playerFollow && _distance > followDistance)
        {
            agent.isStopped = false;
            FollowPlayer();
        }
        // if distance is less, stop ally
        else if (playerFollow && _distance < followDistance)
        {
            agent.isStopped = true;
        }
        
        if (enemyInSightRange && !enemyInAttackRange)
        {
            agent.isStopped = false;
            ChaseEnemy();
        } 
        
        if (enemyInSightRange && enemyInAttackRange)
        {
            agent.isStopped = true;
            AttackEnemy();
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


    private void ChaseEnemy()
    {
        agent.SetDestination(enemy.transform.position); 
    }

    private void FollowPlayer()
    {
       agent.SetDestination(player.transform.position);
    }


    private void AttackEnemy()
    {
        //agent.SetDestination(enemy.transform.position);

        transform.LookAt(enemy.transform.position);

        
        if (!alreadyAttacked)
        {
            alreadyAttacked =true;
            Debug.Log("Enemy was attacked");
            _enemy.EnemyTakeDamage();
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
        

    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void AllyTakeDamage()
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(ally);
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

    [ContextMenu("Chaseenemy")] 
    public void _Chaseenemy()
    {
        Chaseenemy();
    }
    */
}   
