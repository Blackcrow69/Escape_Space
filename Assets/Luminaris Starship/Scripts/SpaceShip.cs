using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour {

    AudioSource audioSource;
    LevelManager levelmanager;


	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void TakeOffSound()
    {
        audioSource.Play();
    }

    public void Win()
    {
        levelmanager.LoadNextLevel();
    }
}
