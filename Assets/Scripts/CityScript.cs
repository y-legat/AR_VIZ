using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityScript : MonoBehaviour {

    private Vector3 initialPos;
    private GameObject city;
	// Use this for initialization
	void Start ()
    {
        GameObject.Find("SzeneContent/Holograms/City");
        initialPos = GameObject.Find("SzeneContent/Holograms/City").transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void showCityButton()
    {
        //set main menu inactive
        GameObject.Find("Menu_main").SetActive(false);
        //set City active
        GameObject.Find("SzeneContent/Holograms/City").SetActive(true);        
        //GameObject.Find("SzeneContent/InformationPanel").SetActive(true);
    }

    public void resetCity()
    {
        //back to origin
        GameObject.Find("SzeneContent/Holograms/City").transform.position = initialPos;

    }
}
