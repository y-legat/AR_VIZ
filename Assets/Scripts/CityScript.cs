using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
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
}
