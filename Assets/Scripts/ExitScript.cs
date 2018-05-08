using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour {
    // close Aplication store everything



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ExitAndQuit()
    {
        Debug.Log("Exit and Quit!");
        Application.Quit();
    }
}
