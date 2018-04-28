using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody rigidBody;
    AudioSource audioSource;

    bool rotRight = true;
    bool rotLeft = false;

    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 50f;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        Rotation();
        Thrust();
    }



    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                //do nothing
                break;
            default:
                //Debug.Log("DEATH");
                break;
        }
    }

    private void Thrust()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Z)) // || Input.GetKeyDown(KeyCode.S))
        {
            audioSource.Play();
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.Z))//|| Input.GetKeyUp(KeyCode.S))
        {
            audioSource.Stop();
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Z))
        {
            rigidBody.AddRelativeForce(Vector3.up * mainThrust);

        }
        //if (Input.GetKey(KeyCode.S))
        //{
        //    rigidBody.AddRelativeForce(Vector3.down * mainThrust);

        //}
    }


    private void Rotation()
    {
        rigidBody.freezeRotation = true;   // freeze rotation physics

        
        float rotationSpeed = rcsThrust * Time.deltaTime;
        float zTrans = transform.localRotation.eulerAngles.z;


        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A))
        {
            
            if (!rotLeft)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0-zTrans);
                rotRight = false;
                rotLeft = true;
            }
            transform.Rotate(Vector3.back * rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (!rotRight)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0-zTrans);
                rotRight = true;
                rotLeft = false;
            }
            transform.Rotate(Vector3.back    * rotationSpeed);
        }
        rigidBody.freezeRotation = false;  //resume physics rotation
    }

    
}
