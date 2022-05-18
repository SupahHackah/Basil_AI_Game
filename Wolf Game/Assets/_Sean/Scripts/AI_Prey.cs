using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class AI_Prey : MonoBehaviour
{
    NavMeshAgent agent;
    SpriteRenderer sprite;
    Health healthScript;

    [Space]
    public GameObject player;
    private Fox_Movement playerScript;
    public GameObject[] waypoints;

    [Space]
    [SerializeField] float distanceToPlayer;

    [Space]
    public bool isAlert;
    public bool isIdle;
    public bool isFleeing;

    [Space]
    Animator anim;  // INT AnimIndex [0] = Idle, [1] = Run, [2] = Dead;

    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.Find("Player_Fox");
        healthScript = GetComponent<Health>();
        healthScript.health = 9;
        healthScript.MAX_HEALTH = 9;
        waypoints = GameObject.FindGameObjectsWithTag("Carrot");
        PickWayPoint();
    }

    void Update()
    {
        sprite.transform.LookAt(Camera.main.transform);

        if (healthScript.health <= 0)
        {
            agent.enabled = false;
            anim.SetInteger("AnimIndex", 2);
            Destroy(gameObject, 1.5f);
            player.GetComponent<Health>().Heal(2);

        }
        else
        {
            distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distanceToPlayer < 10f && agent.enabled == true)
            {
                sprite.enabled = true;
                Flee(player.transform.position);
            }
            else
            {
                sprite.enabled = false;
            }

            if (agent.remainingDistance < .5f && agent.enabled == true)
            {
                anim.SetInteger("AnimIndex", 0);
                StartCoroutine("Delay");
                anim.SetInteger("AnimIndex", 1);
                PickWayPoint();
            }
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2);
    }

    void Flee(Vector3 location)
    {
        Vector3 fleeVector = location - this.transform.position;
        agent.SetDestination(this.transform.position - fleeVector);
        agent.speed = 1;
    }

    void PickWayPoint() 
    {
        int randomWPNum;
        randomWPNum = Random.Range(0, waypoints.Length);

        anim.SetInteger("AnimIndex", 1);
        agent.speed = 3;
        agent.SetDestination(waypoints[randomWPNum].transform.position);
    }

}
