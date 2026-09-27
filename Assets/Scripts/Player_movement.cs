using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_movement : MonoBehaviour
{
    public float forvel=700f;
    public float latvel=700f;
    Quaternion targetrot;
    public Rigidbody rb;
    private float forinp, turninp,latinp;
    private float sensity;
    public GameObject cam;
    private GameObject oldRespawn,respawn;
    private Camera_behaviour camscr;
    public int n=0;
    
   
    private void Start()
    {
        targetrot = transform.rotation;
        rb = GetComponent<Rigidbody>();
        forinp = 0f;
        turninp = 0f;
        latinp = 0f;
        camscr = cam.GetComponent<Camera_behaviour>();
        sensity = camscr.sensity;
       
    }
   
    private void Update()
    {
       forinp = Input.GetAxis("Vertical");
        latinp = Input.GetAxis("Horizontal");
        turninp += Input.GetAxis("Mouse X");
        


    }
    private void FixedUpdate()
    {   
        rb.AddForce(transform.forward * forinp * forvel * Time.fixedDeltaTime, ForceMode.Force);
        rb.AddForce(transform.right*latinp*latvel*Time.fixedDeltaTime,ForceMode.Force);
        targetrot = Quaternion.Euler(0, turninp * sensity, 0);
             transform.rotation = targetrot;      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "New Respawn")
        {
            oldRespawn = GameObject.FindGameObjectWithTag("Respawn");
            oldRespawn.tag = "Old Respawn";
            other.gameObject.tag = "Respawn";

        }
        if (other.gameObject.tag == "Finish")
        {
            rb.linearVelocity = Vector3.zero;
            
        }
        if(other.gameObject.tag =="GoBack")
        {
            respawn = GameObject.FindGameObjectWithTag("Respawn"); 
            transform.position = respawn.transform.position;
            n++;
            
        }
    }
    
}