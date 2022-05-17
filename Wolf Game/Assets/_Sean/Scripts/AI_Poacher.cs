using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class AI_Poacher : MonoBehaviour
{
    NavMeshAgent agent;
    SpriteRenderer sprite;

    [Space]
    public GameObject player;
    public GameObject[] waypoints;

    [Space]
    [SerializeField] float distanceToPlayer;

    [Space]
    public bool isIdle;
    public bool isChasing;

    [Space]
    Animator anim;
    int animState = 0; // 0 = Idle, 1 = Walk, 2 = Run, 3 = Shoot


    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.Find("Player_Fox");
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        PickWayPoint();
    }

    void Update()
    {

        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer < 10f) //SHOOT AT PLAYER
        {
            Shoot();
        }
        else if(distanceToPlayer >= 10f &&  distanceToPlayer < 15f) //CHASE PLAYER
        {
            isChasing = true;
            sprite.enabled = true;
            Seek(player.transform.position);
        }
        else // Go Hunting
        {
            sprite.enabled = false;
            isChasing = false;
            PickWayPoint();
        }

        if (agent.remainingDistance < .25f)
        {
            anim.SetInteger("AnimIndex", 0);
            StartCoroutine("Delay");
            anim.SetInteger("AnimIndex", 1);
            PickWayPoint();
        }

    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2);
    }

    void Shoot()
    {
        anim.SetInteger("AnimIndex", 3);
        Debug.Log("BANG BANG");
    }

    void Seek(Vector3 location)
    {
        isChasing = true;
        anim.SetInteger("AnimIndex", 2);

        agent.SetDestination(location);
    }

    void PickWayPoint()
    {
        int randomWPNum;
        randomWPNum = Random.Range(0, waypoints.Length);

        anim.SetInteger("AnimIndex", 1);

        agent.SetDestination(waypoints[randomWPNum].transform.position);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player" || other.collider.tag == "Ally")
        {
            Debug.Log(this + " HIT");
        }
    }
}