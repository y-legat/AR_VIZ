using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class ImportExportScript : MonoBehaviour, IFocusable, IInputClickHandler
{
    private GameObject child;
    public bool clicked;

    public void OnFocusEnter()
    {
        
 
    }

    public void OnFocusExit()
    {
        
        
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (transform.childCount > 0)
        {
                
            child = gameObject.transform.GetChild(0).gameObject;

            if (clicked && child != null)
            {
                child.SetActive(false);
                clicked = false; 
            
            }
            else if(child != null)
            {
                child.SetActive(true);
                clicked = true;
            }

        }


    }

    // Use this for initialization
    void Start () {

        clicked = false; 
        
       
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
