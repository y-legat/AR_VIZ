using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class ImportExportScript : MonoBehaviour, IFocusable, IInputClickHandler
{
    private GameObject child;
    public bool clicked;
    private Material [] highlightMaterials;
    public static List<GameObject> activeDependencies;


    void Awake()
    {
        activeDependencies = new List<GameObject>();

    }

    // Use this for initialization
    void Start()
    {

        clicked = false;
        highlightMaterials = GetComponent<Renderer>().materials;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnFocusEnter()
    {
        if (transform.childCount > 0)
        {
            // structure: empty element -> child = dependencies 
            child = gameObject.transform.GetChild(0).gameObject;
            child.SetActive(true);
            
            highlightMaterials[0].SetFloat("_Gloss", 5.0f);
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

            if (!activeDependencies.Contains(child))
            {
                activeDependencies.Add(child);
            }
            
           
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

   
    public void deselectAllDependencies()
    {

        //TODO global List with added Dependencies : 
        foreach (GameObject g in activeDependencies)
        {
            g.SetActive(false);

        }
        activeDependencies.Clear();
    }
}
