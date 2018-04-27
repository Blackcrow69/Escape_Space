using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour {

    
    Slider slider;

	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	public void SetHealthSlider (float hp) //min:0 - max:100
    {
        slider.value = hp;
    }
}
