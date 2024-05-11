//this script is attacked to a trigger that will set cornelius to active when the player hits it
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerScarecrow : MonoBehaviour
{
    public GameObject theScarecrow;
  /*  void Start()
    {
        theScarecrow.SetActive(false);
        
    }
   */
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
          if (!theScarecrow.activeSelf)
          {
              theScarecrow.SetActive(true);
          }
        }

    }
    

    
}
