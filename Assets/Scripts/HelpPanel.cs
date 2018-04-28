using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpPanel : MonoBehaviour {

    private GameObject helpPanel;

	// Use this for initialization
	void Start () {
        helpPanel = GameObject.Find("Help Panel");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClosePanel()
    {
        helpPanel.SetActive(false);
    }

}
