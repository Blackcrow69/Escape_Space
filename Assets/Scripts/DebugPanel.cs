using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugPanel : MonoBehaviour {

    public Text debugGravityText;

	// Use this for initialization
	void Start () {
		//debugGravityText = GetComponents<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        ShowGravity();
    }

    private void ShowGravity()
    {
        string gravity = GetGravity().ToString();
        debugGravityText.text = gravity;
    }

    float GetGravity()
    {
        float gravity = Physics.gravity.y;
        return gravity;
    }

}
