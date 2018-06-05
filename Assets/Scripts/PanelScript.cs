using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HoloToolkit.UI.Keyboard;

public class PanelScript : MonoBehaviour
{

    public Keyboard keyboard;

    // Use this for initialization
    void Awake()
    {

        HoverScript.informationPanel = GameObject.Find("InformationPanel");
        HoverScript.buttonSettings = GameObject.Find("btn_InformationPanel_Settings");
        HoverScript.buttonExtended = GameObject.Find("menu_InformationPanel_Settings_extended");
        HoverScript.buttonDeveloper = GameObject.Find("menu_InformationPanel_Settings_developer");
        HoverScript.annotationWindow = GameObject.Find("Annotation_window");
        HoverScript.ToolTip_frame = GameObject.Find("Tooltip2");

        HoverScript.buttonSettings.SetActive(true);
        HoverScript.buttonSettings.SetActive(false);
        HoverScript.buttonSettings.SetActive(false);
        HoverScript.annotationWindow.SetActive(false);
        HoverScript.informationPanel.SetActive(false);

        Debug.Log("Set Panel inactive");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
