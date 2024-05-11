using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vanish : MonoBehaviour
{

    public GameObject SC;
    private void OnTriggerEnter(Collider other)
    {
        SC.SetActive(false);
        //StartCoroutine(Disapear());

    }

    /*IEnumerator Disapear()
    {
        
        SC.SetActive(false);
    }*/
}
