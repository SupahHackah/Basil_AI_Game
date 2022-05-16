using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class AI_Prey : MonoBehaviour
{
    NavMeshAgent agent;
    SpriteRenderer sprite;

    [Space]
    public GameObject player;
    public GameObject[] waypoints;

    [Space]
    [SerializeField] float distanceToPlayer;

    [Space]
    public bool isAlert;
    public bool isIdle;
    public bool isFleeing;

    [Space]
    Animator anim;
    int animState = 0; // 0 = Idle, 1 = Run, 2 = Dead;


    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.Find("Player");
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        PickWayPoint();
    }

    
    
    void Update()
    {

        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer < 10f)
        {
            sprite.enabled = true;
            Flee(player.transform.position);
        }
        else
        {
            sprite.enabled = false;
        }

        if(agent.remainingDistance < .5f)
        {
            anim.SetInteger("AnimIndex", 0);
            StartCoroutine(Delay());
            anim.SetInteger("AnimIndex", 1);
            PickWayPoint();
        }

    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(10);
    }

    void Flee(Vector3 location)
    {
        Vector3 fleeVector = location - this.transform.position;
        agent.SetDestination(this.transform.position - fleeVector);
    }

    void PickWayPoint() 
    {
        int randomWPNum;
        randomWPNum = Random.Range(0, waypoints.Length);

        anim.SetInteger("AnimIndex", 1);

        agent.SetDestination(waypoints[randomWPNum].transform.position);
    }
}
