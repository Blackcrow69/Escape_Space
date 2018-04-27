using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDamage : MonoBehaviour {

    public float damage = 20f;
    Player player;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.transform.parent.tag == "Player")
        {
            Debug.Log("triggered laser");
            player.ReceiveDamage(damage);
        }
    }
}
