using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AnnotationWindow : MonoBehaviour {

    private GameObject gameObj;
    private GameObject textObj;
    private GameObject activeObj;
    private GameObject[] tmp;
    private Text note;
    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void saveAnnotation()
    {

        if (GameObject.Find("Annotation_window") != null)
        {

            note = GameObject.Find("MessageInputField/Text").GetComponent<Text>();
            HoverScript.activeObj.GetComponent<HoverScript>().annotation = note.text;
            HoverScript.activeObj.GetComponent<HoverScript>().gameObjNote.text = note.text;
            //TODO tmp = HoverScript.FindObjectsOfType<GameObject>;
            note.text = "";
           
        }
        else
            Debug.Log("No GameObject with the name 'Text' attached to the gameObject");

       



        //TODO save Annotation to Gameobject -> create Field in InformationPanel for Information messages 

    }

    public void GetAnnotation()
    {
        string note = HoverScript.activeObj.GetComponent<HoverScript>().annotation;
        GameObject.Find("MessageInputField/Text").GetComponent<Text>().text = note;
    }
}
