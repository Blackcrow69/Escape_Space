using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour {

    GameObject player;
    Animator animator;
    Animator doorAnimator;
    AudioSource audioSource;

    public GameObject targetDoor;
    public AudioClip gravityDisabled;
    public AudioClip gravityEnabled;

    private float timer;
    bool openedDoor = false;

    //bool noGravity = false; 

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = GetComponent<AudioSource>();
        doorAnimator = targetDoor.GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
    }

    
    private void OnTriggerStay(Collider other)
    {
        animator = player.GetComponent<Animator>();

        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("ButtonTrigger"); //player animation
            Invoke("GravityChanger",2f);  
            Invoke("OpenDoorAnimation", 2f);

        }
    }

    private void GravityChanger()
    {
        if (timer > 5f) { ChangeGravity(); } // timer to prevent function looping;reasons unknown
    }

    private void OpenDoorAnimation()
    {
        //doorAnimator.SetTrigger("open_door_trigger");
        if (!openedDoor)
        {
            doorAnimator.SetBool("character_nearby", true);
            openedDoor = true;
            CancelInvoke("OpenDoorAnimation");
        }
        else if (openedDoor)
        {
            doorAnimator.SetBool("character_nearby", false);
            openedDoor = false;
            CancelInvoke("OpenDoorAnimation");
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
