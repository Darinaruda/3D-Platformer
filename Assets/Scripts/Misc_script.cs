using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misc_script : MonoBehaviour {

    public GameObject finish;
	void Start () {
		
	}
	
	
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            finish.SetActive(true);     
                    
     }
}
