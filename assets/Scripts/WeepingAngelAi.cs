using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;



public class WeepingAngelAi : MonoBehaviour
{
    public Animator aiAnimation;
    public NavMeshAgent ai;
    public Transform Player;
    Vector3 dest;
    public GameObject JumpScareImg;
    public float aiSpeed;
    public float jumpscareTime = 5;

    public AudioSource source;
    
    public AudioClip jumpscare;

    public float catchDistance;

    //need to reference bool from PlayerFOV script
    PlayerFOV playerFOV;
    [SerializeField] GameObject player;
    void Awake()
    {
        playerFOV = player.GetComponent<PlayerFOV>();
    }
    
    void Update()
    {
        
        //need to get Cornelius's distance from player
        float distance = Vector3.Distance(transform.position, Player.position);
        
            //If player is looking at Cornelius:
            if(playerFOV.canSeeScarecrow)
            {
                
                ai.speed = 0; //Cornelius speed will be 0
                aiAnimation.speed = 0; //walking animation will be paused
                ai.SetDestination(transform.position); //Cornelius's destination will be set to himself to stop delay from happening

                if(distance <= catchDistance)
                {

                source.volume = 0.3f;
                source.PlayOneShot(jumpscare);
                JumpScareImg.SetActive(true); //Show jumpscare
                Player.gameObject.SetActive(false); //The player object will be set false
                    
                    //aiAnimation.SetTrigger("jumpscare");
                    
                    StartCoroutine(killPlayer()); //Cornelius will catch and kill the player
                }
        
            }
            //If player is NOT looking at Cornelius
            if(!playerFOV.canSeeScarecrow)
            {
                ai.speed = aiSpeed; //Cornelius's speed will be the value of aiSpeed
                aiAnimation.speed = 1;
                dest = Player.position; 
                ai.destination = dest; //Cornelius will walk to the player

                //If the distance between the player and Cornelius is less than or equal to the catchDistance,
                if(distance <= catchDistance)
                {

                source.volume = 0.3f;
                source.PlayOneShot(jumpscare);
                JumpScareImg.SetActive(true); //Show jumpscare
                Player.gameObject.SetActive(false); //The player object will be set false
                    
                    //aiAnimation.SetTrigger("jumpscare");
                    
                    StartCoroutine(killPlayer()); //Cornelius will catch and kill the player
                }
            }
        
    }
    //The killPlayer() coroutine
    IEnumerator killPlayer()
    {
        source.volume = 0.3f;
        source.PlayOneShot(jumpscare);
        yield return new WaitForSeconds(jumpscareTime); //After the amount of time determined by the jumpscareTime,
        SceneManager.LoadScene(0); //The scene after death will load
       
    }
}

 

