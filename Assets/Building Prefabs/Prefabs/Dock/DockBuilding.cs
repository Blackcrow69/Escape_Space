using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DockBuilding : MonoBehaviour {

    public GameObject playerShip;

    private GameObject vCam1;
    private GameObject vCam2;
    private Animator animator;
    private GameObject player;

	// Use this for initialization
	void Start () {
        animator = playerShip.GetComponent<Animator>();
        player = GameObject.Find("Player");
        vCam1 = GameObject.Find("CM vcam1");
        vCam2 = GameObject.Find("CM vcam2");
        vCam2.SetActive(false);
        vCam1.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("isDeparting", true);
        player.SetActive(false);
        vCam1.SetActive(false);
        vCam2.SetActive(true);
    }
}
