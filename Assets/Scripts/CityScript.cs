using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HoloToolkit.Unity.UX;

public class CityScript : MonoBehaviour {

    private Vector3 initialPos;
    private GameObject city;
    private GameObject appBar;
    
    // Use this for initialization
	void Start ()
    {
        GameObject.Find("SzeneContent/Holograms/City");
        // save inital position for resetCity() / voice command 'reset city' 
        initialPos = GameObject.Find("SzeneContent/Holograms/City").transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (appBar == null)
        {
            appBar = GameObject.Find("AppBar(Clone)");
            if (appBar != null)
            {
                //Debug.Log("Found AppBar");
                HoverScript.appBarScript = appBar.GetComponent<AppBar>();
            }
        }
    }

    public void showCityButton()
    {
        //set main menu inactive
        GameObject.Find("Menu_main").SetActive(false);
        //set City active
        GameObject.Find("SzeneContent/Holograms/City").SetActive(true);        
    }

    public void resetCity()
    {
        //back to origin
        GameObject.Find("SzeneContent/Holograms/City").transform.position = initialPos;

    }
}
