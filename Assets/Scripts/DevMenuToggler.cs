using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevMenuToggler : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void toggle()
    {

        if (HoverScript.buttonDeveloper.activeSelf)
        {
            HoverScript.buttonDeveloper.SetActive(false);
        }
        else
        {
            HoverScript.buttonDeveloper.SetActive(true);
        }
    }
}
