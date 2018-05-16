using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine.UI;
using UnityEngine;



public class HoverScript : MonoBehaviour, IFocusable, IInputClickHandler
{
    private Material[] defaultMaterials;
    private Material tmp;
    private GameObject gameobj;
    private Text gameObjName;
    private Text gameObjtype;
    private Text gameObjPackage;
    private InputManager inputManager;

    


    private void Start()
    {
        defaultMaterials = GetComponent<Renderer>().materials;
        if (GameObject.Find("InformationPanel") != null)
        {
            //find text elements, which will be overwritten:
            gameObjName = GameObject.Find("InformationPanel/TextContent/Subtitle01/Subtitle01.1").GetComponent<Text>();
            gameObjtype = GameObject.Find("InformationPanel/TextContent/Subtitle02/Subtitle02.1").GetComponent<Text>();
            gameObjPackage = GameObject.Find("InformationPanel/TextContent/Subtitle03/Subtitle03.1").GetComponent<Text>();
        }

    }

    private void Awake()
    {
        defaultMaterials = GetComponent<Renderer>().materials;
    }

    public void OnFocusEnter()
    {
        for (int i = 0; i < defaultMaterials.Length; i++)
        {
            // Highlight the material when gaze enters using the shader property.
            defaultMaterials[i].SetFloat("_Gloss", 5.0f);
            //store original material for OnFocusExit()
            tmp = gameObject.transform.parent.GetComponent<Renderer>().material;
            //set Parent (package) to houseColor 
            gameObject.transform.parent.GetComponent<Renderer>().material = defaultMaterials[i];
            //gameObject.transform.parent.GetComponent<Renderer>().material.SetFloat("_Gloss", 10.0f);
        }
        Debug.Log(gameObject.transform.parent.name);
        
    }

    public void OnFocusExit()
    {
        for (int i = 0; i < defaultMaterials.Length; i++)
        {
            // Remove highlight on material when gaze exits.
            defaultMaterials[i].SetFloat("_Gloss", 1.0f);
            //reset parent matrial 
            gameObject.transform.parent.GetComponent<Renderer>().material = tmp;
        }
    }

    private void OnDestroy()
    {
        foreach (var material in defaultMaterials)
        {
            Destroy(material);
        }
    }
    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (GameObject.Find("InformationPanel") != null)
        {
            //set Text 
            gameObjName.text = gameObject.name;
            gameObjPackage.text = gameObject.transform.parent.name;
            gameObjtype.text = "TODO";
        }
        
    }

}
