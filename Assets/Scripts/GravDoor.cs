using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravDoor : MonoBehaviour {

    AudioSource audiosource;

    // Use this for initialization
    void Start() {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void OpenDoorSound()
    {
        audiosource.Play();
    }
}
