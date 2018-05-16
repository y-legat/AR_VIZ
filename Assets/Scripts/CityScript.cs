using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityScript : MonoBehaviour {

    private Vector3 initialPos;
    private GameObject city;
	// Use this for initialization
	void Start ()
    {
        city = GameObject.Find("SzeneContent/Holograms/City");
        initialPos = city.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void showCityButton()
    {
        //set main menu inactive
        GameObject.Find("Menu_main").SetActive(false);
        //set City active
        city.SetActive(true);        
        //GameObject.Find("SzeneContent/InformationPanel").SetActive(true);
    }

    public void resetCity()
    {
        //back to origin
        city.transform.position = initialPos;

    }
}
