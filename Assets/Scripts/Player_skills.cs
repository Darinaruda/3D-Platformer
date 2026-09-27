using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_skills : MonoBehaviour
{

    public Rigidbody rb;
    public bool onGround = true;
    private bool doubleJumpPickUp = false, wallWalkPickUp = false;
    public int n = 0;
    private float bonusJump=1f;
    public int maxJumps = 1;
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
    }

    void doubleJump()
    {


        if (Input.GetButtonDown("Jump") && onGround == true && n<maxJumps) //if grounded
        {
            rb.AddForce(Vector3.up *1000f * bonusJump * Time.fixedDeltaTime, ForceMode.VelocityChange);
            n++;

           

        }
            if (rb.linearVelocity.y < 0)
                Physics.gravity = new Vector3(0f, -80f, 0f);
            else
                Physics.gravity = new Vector3(0f, -9.81f, 0f);

        
    }
  void FixedUpdate()
    {
        doubleJump();

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Ground")
        {
            onGround = true;
            n = 0;
            
        }
       
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag!="Ground")
        {
            onGround = false;
            n++;
        }
        if (collision.gameObject.tag != "Wall")
        {
            rb.useGravity = true;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    { if (other.tag == "1st_Skill")
        {
            Destroy(other.gameObject);
            maxJumps = 2;
            bonusJump = 1.25f;
        }
        if (other.tag == "2nd_Skill")
        {
            GameObject.FindGameObjectsWithTag("Wall");
            
            Destroy(other.gameObject);
        }
        
        }  
    
}