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
    public GameObject bulletPrefab;
    public Transform bulletOrigin;
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
        

       
       if(distanceToPlayer < 15f) //CHASE PLAYER
        {
            Seek(player.transform.position);

            if (distanceToPlayer < 10f) //SHOOT AT PLAYER
            {
                Seek(transform.position);
                Shoot();
                return;
            }
            
        }
        
        else if (distanceToCamp < 2f)// Go Hunting
        {
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
        anim.SetInteger("AnimIndex", 3);
        

        RaycastHit hit;
        if (Physics.Raycast(bulletOrigin.position, transform.forward, out hit, 100))
        {
            transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position, transform.up);


            if (Time.time - lastAttackTime >= 2)
            {
                Debug.Log("BANG BANG");
                shootProjectile();
                lastAttackTime = Time.time;
            }

        }
    }
    void shootProjectile() 
    {
        var bullet = Instantiate(bulletPrefab, bulletOrigin.position, bulletOrigin.transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity += transform.forward * bulletSpeed *Time.deltaTime;
        Destroy(bullet, 2);
    }
}