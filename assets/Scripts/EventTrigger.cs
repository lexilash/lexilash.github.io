using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    public Animator myAnimator;
    public GameObject Sasquatch;
    /*// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
    private void OnTriggerEnter(Collider other)
    {
        myAnimator.SetTrigger("Go");
        StartCoroutine(KillPatrick());
        
    }

    IEnumerator KillPatrick()
    {
        yield return new WaitForSeconds(12);
        Sasquatch.SetActive(false);
    }
}
