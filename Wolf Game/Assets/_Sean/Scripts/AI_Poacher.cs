using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class AI_Poacher : MonoBehaviour
{
    NavMeshAgent agent;
    SpriteRenderer sprite;

    [Space]
    public GameObject player;
    [SerializeField] private LayerMask playerLayer;
    public GameObject[] waypoints;
    Vector3 destination;

    [Space]
    public GameObject bullet;
    public Transform bulletOrigin;
    private Vector3 direction;
    private float lastAttackTime = 0;
    public float bulletSpeed = 100f;

    [Space]
    [SerializeField] float distanceToPlayer;
    [SerializeField] float distanceToCamp;


    [Space]
    Animator anim;//  INT [0] = Idle, [1] = Walk, [2] = Run, [3] = Shoot


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

        distanceToCamp = Vector3.Distance(transform.position, destination);
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        direction = (player.transform.position - bulletOrigin.position);


        if (distanceToPlayer <= 10f) //SHOOT AT PLAYER
        {
            Seek(transform.position);
            Shoot();
            return;
        }
        else if (distanceToPlayer < 15f || distanceToPlayer>10) //CHASE PLAYER
        {
            agent.enabled = true;
            Seek(player.transform.position);                        
        }
        else if (distanceToCamp < 2f)// Go Hunting
        {
            agent.enabled = true;
            PickWayPoint();
        }

        
    }

    void Seek(Vector3 location)
    {
        anim.SetInteger("AnimIndex", 2);

        agent.SetDestination(location);
    }

    void PickWayPoint()
    {
        int randomWPNum;
        randomWPNum = Random.Range(0, waypoints.Length-1);
        destination = waypoints[randomWPNum].transform.position;
        anim.SetInteger("AnimIndex", 1);
        agent.SetDestination(destination);
    }


    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2);
    }

    void Shoot()
    {
        Debug.DrawRay(bulletOrigin.position, transform.forward, Color.green);
        RaycastHit hit;
        if (Physics.Raycast(bulletOrigin.position, transform.forward, out hit))
        {
            transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position, transform.up);
            

            if (Time.time - lastAttackTime >= 2)
            {
                anim.SetInteger("AnimIndex", 3);
                Debug.Log("BANG BANG");
                shootProjectile();
                lastAttackTime = Time.time;
            }

        }
    }
    void shootProjectile() 
    {
        //bulletOrigin.transform.LookAt(player.transform);
        GameObject b =Instantiate(bullet, bulletOrigin.position, bulletOrigin.transform.rotation);
        b.GetComponent<Rigidbody>().AddForce(direction * bulletSpeed);
        Destroy(b, 5);
    }
}