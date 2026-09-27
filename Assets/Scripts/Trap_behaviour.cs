using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_behaviour : MonoBehaviour {

    private Rigidbody rb;
    public GameObject player,trap;
    public Player_movement playerScript;
    private Vector3 dir;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerScript = player.GetComponent<Player_movement>();
        dir = new Vector3(-rb.transform.position.x, 1f, 0f);
        
    }
	
	
	void Update ()
    {
		
	}
    private void Effect(int x)
    {
        switch(x)
        {
            case 1:
                playerScript.rb.AddForce(Vector3.forward * 20000f * Time.deltaTime, ForceMode.Impulse);
                break;
            case 2:
                Destroy(trap);
                break;
            case 3:
                player.GetComponent<Rigidbody>().linearVelocity = player.GetComponent<Rigidbody>().linearVelocity * 0.85f;

                break;
            case 4:
                rb.transform.Translate(Vector3.left * 15f * Time.deltaTime);
                break;
           
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            Effect((int) rb.mass);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Effect((int)rb.mass);
        }
    }
}
