using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_behaviour : MonoBehaviour
{
    private const float Y_ANGLE_MIN = 0f;
    private const float Y_ANGLE_MAX = 35;
    public Transform target;
    private float camDistance = 10f;
    private float currentx = 0f;
    private float currenty = 0f;
    public float sensitx;
    public float sensity;
    private Vector3 dir;

    void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        currentx += Input.GetAxis("Mouse X");
        currenty -= Input.GetAxis("Mouse Y");
        currenty = Mathf.Clamp(currenty, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }
    
    private void LateUpdate()
    {
        
        Quaternion rotation = Quaternion.Euler(currenty*sensity, currentx*sensitx, 0);
       
            dir = Vector3.forward * (-camDistance);
            transform.position = target.position + rotation * dir;
            transform.LookAt(target.position);
    }
  
   
}