using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
  public Rigidbody player;
  public float playerSpeed; 
  public bool canMove = true;


  void FixedUpdate()
  {
    if(canMove)
    {
      if(Input.GetKey(KeyCode.W))//forward
      {
        player.velocity = transform.forward * playerSpeed * Time.deltaTime;

      }
      if(Input.GetKey(KeyCode.S))//backward
      {
        player.velocity = -transform.forward * playerSpeed * Time.deltaTime;

      }
      if(Input.GetKey(KeyCode.A))//left
      {
        player.velocity = -transform.right * playerSpeed * Time.deltaTime;

      }
      if(Input.GetKey(KeyCode.D))//right
      {
        player.velocity = transform.right * playerSpeed * Time.deltaTime;

      }
    }
    else if(!canMove)
    {
      player.velocity = Vector3.zero;

    }


        
  }
  /*void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotatespeed * Time.deltaTime, 0);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotatespeed * Time.deltaTime, 0);
        }

    }
    */
}

