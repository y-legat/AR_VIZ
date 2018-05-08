using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Settings_script : MonoBehaviour {

    private bool active;

	// Use this for initialization
	void Start () {
        active = false;
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    
    public void isClicked()
    {
        active = !active;
    }

    public void hideAllFunctions()
    {        
        foreach (Transform child in transform)
        {
            if (child.name!= "ButtonHolographic_Menu")
            {
                child.gameObject.SetActive(false);
            }

            else
                child.gameObject.SetActive(true);
        }

    }

    public void showAllFunctions()
    {

        
        foreach (Transform child in transform)
        {
                child.gameObject.SetActive(true);
        }

    }
    public void btn_pressed()
    {
        if (active)
        {
            showAllFunctions();
        }
        else
            hideAllFunctions();

        active = !active;
    }
    
}

