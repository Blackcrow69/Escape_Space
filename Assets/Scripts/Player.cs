using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float Health = 100f;
    public HealthSlider healthSlider;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
	}

    public void ReceiveDamage (float damage)
    {
        Health -= damage;
        healthSlider.SetHealthSlider(Health);
    }
    
}
