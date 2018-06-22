using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallMenuMain : MonoBehaviour {


    //necessary: otherwise InformationPanel not found

	// Use this for initialization
	void Awake () {
        HoverScript.informationPanel = GameObject.Find("InformationPanel");
        HoverScript.informationPanel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
