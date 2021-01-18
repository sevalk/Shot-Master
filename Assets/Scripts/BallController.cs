using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEditor;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody rb;
    
    [SerializeField] private float shootPower=30f;
    

    CameraMov ballSpeedWithCamera;

    public bool isMoving=true;
    public bool canSpawn;
    
    void Start()
    {
        

        rb = GetComponentInParent<Rigidbody>();
        ballSpeedWithCamera = Camera.main.GetComponent<CameraMov>();
        
    }
    void LateUpdate()
    {
        //Ray ray = new Ray(transform.position, Input.mousePosition);


        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Rayi screen ekranında görebilirsin.
        //Debug.DrawRay(ray.origin, ray.direction * 1000, Color.yellow);

        Vector3 ballSpeed = new Vector3(0, 0, ballSpeedWithCamera.cameraSpeed);

        
        if (Input.GetMouseButtonDown(0) && ballSpeedWithCamera.cameraSpeed > 0 )
        {
            isMoving = false;
            RaycastHit hitInfo;

            if (Physics.Raycast(transform.position, transform.forward, out hitInfo))
            {
                rb.AddForce(ray.direction * shootPower, ForceMode.VelocityChange);
               
                canSpawn = true;
                
            }

        }
        else if (isMoving)
        { 
            canSpawn = false;
            rb.velocity = ballSpeed;
            
        }
  
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "FinishLine" || other.gameObject.tag == "SkyLine")
        {
            Destroy(gameObject);
           
        }

        if (other.gameObject.tag == "Crystal")
        {
            Destroy(gameObject);
        }




    }




}
