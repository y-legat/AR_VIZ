using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine.UI;
using UnityEngine;



public class HoverScript : MonoBehaviour, IFocusable, IInputClickHandler
{
    private Material[] defaultMaterials;
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
            defaultMaterials[i].SetFloat("_Gloss", 10.0f);

           
        }
    }

    public void OnFocusExit()
    {
        for (int i = 0; i < defaultMaterials.Length; i++)
        {
            // Remove highlight on material when gaze exits.
            defaultMaterials[i].SetFloat("_Gloss", 1.0f);
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
            gameObjName.text = gameObject.name;
            gameObjPackage.text = gameObject.transform.parent.name;

            gameObjtype.text = "TODO";
        }
        



    }

    public void helper()
    {
        GameObject.Find("InformationPanel").SetActive(true);

        Debug.Log("hi");
    }
}
