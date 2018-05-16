using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class ImportExportScript : MonoBehaviour, IFocusable, IInputClickHandler
{
    private GameObject child;
    public bool clicked;
    private Material [] highlightMaterials;

    public void OnFocusEnter()
    {
        if (transform.childCount > 0)
        {

            child = gameObject.transform.GetChild(0).gameObject;
            child.SetActive(true);
            
            highlightMaterials[0].SetFloat("_Gloss", 5.0f);
            Debug.Log(highlightMaterials[0].name);
        }
            
 
    }

    public void OnFocusExit()
    {
        if (!clicked && child != null)
        {
            child.SetActive(false);
            clicked = false;
            highlightMaterials[0].SetFloat("_Gloss", 1.0f);
        }

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
        highlightMaterials = GetComponent<Renderer>().materials;

    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
