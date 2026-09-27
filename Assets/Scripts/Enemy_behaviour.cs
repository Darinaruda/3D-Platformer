using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy_behaviour : MonoBehaviour
{

    public GameObject Player,Enemy,Loot;
    private float MoveSpeed = 4f;
    private float MinDist = 25f;//distanta minima pentru ca ennemy-ul sa sesizeze playerul
    public Player_skills playerScript;
    private Rigidbody rBody;
    private Vector3 posInit;
    private Vector3 search;
    private GameObject respawn;
    private int x = 0;

    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
        playerScript = Player.GetComponent<Player_skills>();
        posInit = Enemy.transform.position;
       
    }

    private void Update()
    { search = Player.transform.position - transform.position;
        if (search.magnitude < MinDist)
        { 
            transform.LookAt(playerScript.rb.transform);
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
               
        }
        else
        {
               if(rBody.linearVelocity.y>=0)
                Enemy.transform.position = posInit;
        }

        if (Player.GetComponent<Player_movement>().n > x)
        {
            Enemy.transform.position = posInit;
            Enemy.SetActive(true);
            x = Player.GetComponent<Player_movement>().n;
        }
        }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            respawn = GameObject.FindGameObjectWithTag("Respawn");
            Player.transform.position = respawn.transform.position;
            Enemy.transform.position = posInit;
            rBody.linearVelocity = Vector3.zero;
        }
        if(collision.gameObject.tag =="GoBack")
        {
            Enemy.SetActive(false);
           
        }
    }

}