using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockBuilding : MonoBehaviour {

    public GameObject playerShip;

    private Animator animator;
    private GameObject player;

	// Use this for initialization
	void Start () {
        animator = playerShip.GetComponent<Animator>();
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("isDeparting", true);
        player.SetActive(false);
    }
}
