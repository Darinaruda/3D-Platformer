using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_behaviour : MonoBehaviour {

    public Rigidbody rb;
    private float t,tt;
	void Start () {
        rb = GetComponent<Rigidbody>();	
	}
	
	
	void Update () {
        if (rb.mass == 2)
        {
            t = Time.time;
            tag = "Untagged";
            if (Time.time == t + 3)
                rb.mass = 1;
        }
        else
            tag = "Ground";
	}
   private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody>().useGravity = false;
            collision.gameObject.GetComponent<Player_skills>().onGround = true;
            tt = Time.time;
        }

    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            if (Time.time >= tt + 3f)
            {
                collision.gameObject.GetComponent<Rigidbody>().useGravity = true;             
               rb.mass = 2;
            }
    }
   
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {          
            collision.gameObject.GetComponent<Rigidbody>().useGravity = true;
            collision.gameObject.GetComponent<Player_skills>().onGround=false;
        }
    }
}
