using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HoloToolkit.Unity.InputModule;
using HoloToolkit.UI.Keyboard;

public class SceneSettings : MonoBehaviour, IInputClickHandler {

    // Use this for initialization
    void Awake () {
        InputManager.Instance.AddGlobalListener(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnInputClicked(InputClickedEventData eventData)
    {
        GameObject focusedObject = FocusManager.Instance.GetFocusedObject(GazeManager.Instance);
        if(focusedObject == null)
        {
            Debug.Log("Focused Object null");
            if(HoverScript.activeObj != null)
            {
                Debug.Log("Active Object not null");

                HoverScript.informationPanel.SetActive(false);
                HoverScript.buttonSettings.SetActive(true);
                HoverScript.buttonExtended.SetActive(false);
                HoverScript.buttonDeveloper.SetActive(false);
                HoverScript.boundingBox.SetActive(false);

                GameObject.Find("Holograms").GetComponent<PanelScript>().keyboard.Close();
                
                HoverScript activeHover = HoverScript.activeObj.GetComponent<HoverScript>();
                
            }
        }
        
    }
}
