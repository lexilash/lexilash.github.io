using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Blink : MonoBehaviour
{
    public Animator blinkAnim;
  
 
    
    void Start()
    {
        
        blinkAnim.speed = 0.2f;
        blinkAnim.SetTrigger("blink");//play blink animation
        
    }
   
    
}
