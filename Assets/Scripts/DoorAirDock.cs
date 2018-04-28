using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAirDock : MonoBehaviour {
    GameObject player;
    Animator animator;
    Animator door1Animator;
    Animator door2Animator;
    AudioSource audioSource;
	

    public GameObject targetDoor1;
    public GameObject targetDoor2;
    public AudioClip gravityDisabled;
    public AudioClip gravityEnabled;

    private float timer;
    bool openDoor1 = true;
    bool openDoor2 = false;

    //bool noGravity = false; 

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = GetComponent<AudioSource>();
        door1Animator = targetDoor1.GetComponent<Animator>();
        door2Animator = targetDoor2.GetComponent<Animator>();

        door1Animator.SetBool("character_nearby", true); // open door on start

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }


    private void OnTriggerStay(Collider other)
    {
        animator = player.GetComponent<Animator>();

        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("ButtonTrigger"); //player animation
            Invoke("GravityChanger", 4f);
            if (openDoor1)
            {
                Invoke("OpenDoor1Animation", 1);
                Invoke("OpenDoor2Animation", 5);
            }
            else
            {
                Invoke("OpenDoor1Animation", 5);
                Invoke("OpenDoor2Animation", 1);
            }
            

        }
    }

    private void GravityChanger()
    {
        if (timer > 5f) { ChangeGravity(); }  // timer to prevent function looping;reasons unknown
    }

    private void OpenDoor1Animation()
    {
        //doorAnimator.SetTrigger("open_door_trigger");
        if (!openDoor1)
        {
            door1Animator.SetBool("character_nearby", true);
            openDoor1 = true;
            CancelInvoke("OpenDoor1Animation");
        }
        else if (openDoor1)
        {
            door1Animator.SetBool("character_nearby", false);
            openDoor1 = false;
            CancelInvoke("OpenDoor1Animation");
        }
    }

    private void OpenDoor2Animation()
    {
        //doorAnimator.SetTrigger("open_door_trigger");
        if (!openDoor2)
        {
            door2Animator.SetBool("character_nearby", true);
            openDoor2 = true;
            CancelInvoke("OpenDoor2Animation");
        }
        else if (openDoor2)
        {
            door2Animator.SetBool("character_nearby", false);
            openDoor2 = false;
            CancelInvoke("OpenDoor2Animation");
        }
    }

  
    void ChangeGravity()
    {
        if (Physics.gravity.y >= 0f)
        {
            Physics.gravity = new Vector3(0f, -2f, 0f);
            //noGravity = false;
            audioSource.clip = gravityEnabled;
            audioSource.Play();
        }
        else if (Physics.gravity.y < 0f)
        {
            Physics.gravity = new Vector3(0f, 0f, 0f);
            //noGravity = true;
            audioSource.clip = gravityDisabled;
            audioSource.Play();
        }
        timer = 0;
    }

}
