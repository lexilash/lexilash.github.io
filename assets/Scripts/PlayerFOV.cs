using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFOV : MonoBehaviour
{
 public float radius;
 [Range(0,360)]
 public float angle;
 public GameObject ScarecrowRef;

 public LayerMask targetMask;
 public LayerMask obstructionMask;
 public bool canSeeScarecrow;

 private void Start()
 {
    ScarecrowRef = GameObject.FindGameObjectWithTag("Cornelius");
    StartCoroutine(FOVRoutine());
 }

 private IEnumerator FOVRoutine()
 {
    WaitForSeconds wait = new WaitForSeconds(0.4f);

    while(true)
    {
        yield return wait;
        FOVCheck();

    }
 }
 private void FOVCheck()
 {
    //sphere starts from center position of player
    Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

    if(rangeChecks.Length != 0)
    {
        Transform target = rangeChecks[0].transform;
        //find direction from where player is looking to where the enemy is
        Vector3 directionToTarget = (target.position - transform.position).normalized;
        if(Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            if(!Physics.Raycast(transform.position,directionToTarget, distanceToTarget, obstructionMask))
            {
                canSeeScarecrow = true;
            }
            else
            {
                canSeeScarecrow = false;
            }

        }
        else
        {
            canSeeScarecrow = false;
        }
    }
    else if(canSeeScarecrow) //if you could see the enemy and now you cant, change to false
    {
        canSeeScarecrow = false;
    }
 }

}
