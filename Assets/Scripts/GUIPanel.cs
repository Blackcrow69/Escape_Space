using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// used for the debug menu, display settings with hotkeys

public class GUIPanel : MonoBehaviour {

    private GameObject childObj;
    private GameObject GUI;

    bool debug = false;

	// Use this for initialization
	void Start () {
        childObj = this.transform.GetChild(1).gameObject;
        GUI = GameObject.Find("Player GUI");
        GUI.SetActive(true);

    }

    void OnGUI()
    {
        Event e = Event.current;
        if (e.type == EventType.KeyDown && e.control && e.keyCode == KeyCode.F1)
        {
            if (!debug)
            {
                childObj.SetActive(true);
                debug = true;
            }
            else
            {
                childObj.SetActive(false);
                debug = false;
            }
        }
    }

    // Update is called once per frame
    void Update ()
    {
      
    }

   
}
