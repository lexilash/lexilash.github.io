using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

//Random patroling script for sub-enemies
public class VooDoo_Patrol : MonoBehaviour
{
   public List<Transform> VooDooWayPoints;

   NavMeshAgent navMeshAgent_VooDoo;
   GameObject player;
    //animator
    public Animator anim;
   //states
   [SerializeField] float chaseRange, attackRange, killRange;
   [SerializeField] LayerMask playerLayer;
   bool iSeePlayer;
   bool inKillRange;
   bool inAttackRange;
   public float jumpscareTime = 5;
   public int currentWayPointIndex = 0;
   public GameObject VooDooJumpScareImg;
    void Start()
    {
        navMeshAgent_VooDoo = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        iSeePlayer = Physics.CheckSphere(transform.position, chaseRange, playerLayer);
        inKillRange = Physics.CheckSphere(transform.position, killRange, playerLayer);
        //if enemy doesn't see player, he will keep patroling
        if(!iSeePlayer && !inKillRange) 
        {
            Walking();
        }
        //if enemy see's player, but isn't close enough to kill them, then he will chase
        if(iSeePlayer && !inKillRange) 
        {
            Chasing();
        }
        if(iSeePlayer && inAttackRange) 
        {
            Attacking();
            
        }
        //if enemy sees player and is in kill range, he will kill the player
        if(iSeePlayer && inKillRange) 
        {
            Killing();
        }
    }
    void Chasing()
    {
        navMeshAgent_VooDoo.SetDestination(player.transform.position);
        anim.SetBool("Running", true);
    }
    void Attacking()
    {
        anim.SetBool("Running", false);
        anim.SetBool("Attacking", true);
    }
    void Killing()
    {
        
        player.gameObject.SetActive(false); //The player object will be set to inactive
        VooDooJumpScareImg.SetActive(true);
        StartCoroutine(killPlayer()); //enemy will catch and kill the player
        
    }

    void Walking()
    {
        anim.SetBool("Running", false);
        if (VooDooWayPoints.Count == 0)
        {
            return;
        }
        float distanceToWayPoint = Vector3.Distance(VooDooWayPoints[currentWayPointIndex].position, transform.position);

        if(distanceToWayPoint <= 3)
        {
            //have enemy choose a random waypoint to walk to
            currentWayPointIndex = Random.Range(0,8);
        }

        navMeshAgent_VooDoo.SetDestination(VooDooWayPoints[currentWayPointIndex].position);
    }
    IEnumerator killPlayer()
    {
        yield return new WaitForSeconds(jumpscareTime); 
        SceneManager.LoadScene(0); 
    }
    
  
}
