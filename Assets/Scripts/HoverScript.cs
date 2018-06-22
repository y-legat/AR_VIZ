using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine.UI;
using UnityEngine;

using HoloToolkit.UI.Keyboard;
using HoloToolkit.Unity.UX;
using HoloToolkit.Unity.InputModule.Utilities.Interactions;

public class HoverScript : MonoBehaviour, IFocusable, IInputClickHandler
{
    public static GameObject boundingBox;
    public static GameObject informationPanel;
    public static GameObject buttonSettings;
    public static GameObject buttonExtended;
    public static GameObject buttonDeveloper;
    public static GameObject annotationWindow;

    public static GameObject activeObj;
    public static AppBar appBarScript;

    private Material[] defaultMaterials;
    private Material tmp;
    public GameObject gameobj;
    private Text gameObjName;
    private Text gameObjtype;
    private Text gameObjPackage;
    public Text gameObjNote;
    private InputManager inputManager;

    public Text Tooltip_txt;
    public static GameObject ToolTip_frame;

    public string annotation;
    public float bbMagnitude;

    public TwoHandManipulatable twohandScript;

    private void Start()
    {
        annotation = "";
        bbMagnitude = GameObject.Find("City").transform.localScale.magnitude;
        twohandScript = GameObject.Find("City").GetComponent<TwoHandManipulatable>();
    }

    private void Awake()
    {        
        defaultMaterials = GetComponent<Renderer>().materials;
        if (GameObject.Find("InformationPanel") != null)
        {
            //find text elements, which will be overwritten:
            gameObjName = GameObject.Find("InformationPanel/TextContent/Subtitle01/Subtitle01.1").GetComponent<Text>();
            gameObjtype = GameObject.Find("InformationPanel/TextContent/Subtitle02/Subtitle02.1").GetComponent<Text>();
            gameObjPackage = GameObject.Find("InformationPanel/TextContent/Subtitle03/Subtitle03.1").GetComponent<Text>();
            gameObjNote = GameObject.Find("InformationPanel/TextContent/Subtitle04/Subtitle04.1").GetComponent<Text>();
        }
        defaultMaterials = GetComponent<Renderer>().materials;

        if (boundingBox == null)
        { 
            boundingBox = new GameObject("BuildingBoundingBox");
            Mesh wireframe = Resources.Load<Mesh>("wireframe");
            MeshFilter filter = boundingBox.AddComponent<MeshFilter>();
            filter.mesh = wireframe;

            MeshRenderer renderer = boundingBox.AddComponent<MeshRenderer>();
            Material mat = Resources.Load<Material>("WireframeMaterial");
            renderer.material = mat;

            boundingBox.SetActive(false);
        }
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

        if (!(activeObj == gameObject))
        {
            ToolTip_frame.SetActive(true);
            ToolTip_frame.transform.position = gameObject.transform.position;
            ToolTip_frame.transform.position += (gameObject.GetComponent<BoxCollider>().extents.y / 4) * gameObject.transform.up;
            GameObject.Find("ToolTip_txt").GetComponent<Text>().text = gameObject.transform.name;
        }
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

        ToolTip_frame.SetActive(false);
    }

    private void OnDestroy()
    {
        foreach (var material in defaultMaterials)
        {
            Destroy(material);
        }
    }

    // set wireframe, set InformationPanel active and set position, fill informations with components, check annotation 
    public void OnInputClicked(InputClickedEventData eventData)
    {
        if(!(appBarScript.State == AppBar.AppBarStateEnum.Manipulation))
        {
            activeObj = gameObject;
            Vector3 center = gameObject.GetComponent<BoxCollider>().center;
            center.x -= center.x * 0.5f;
            boundingBox.transform.position = gameObject.transform.TransformPoint(center);
            boundingBox.transform.rotation = GameObject.Find("City").transform.rotation;

            Vector3 buildingScale = gameObject.GetComponent<BoxCollider>().size;
            buildingScale.x = buildingScale.x * 9;
            buildingScale.y = buildingScale.y * 3.0f;
            buildingScale.z = buildingScale.z * 2.5f;

            buildingScale = buildingScale * (GameObject.Find("City").transform.localScale.magnitude / bbMagnitude);

            informationPanel.SetActive(true);
            buttonSettings.SetActive(true);
            buttonExtended.SetActive(false);
            buttonDeveloper.SetActive(false);
            annotationWindow.SetActive(false);

            GameObject.Find("Holograms").GetComponent<PanelScript>().keyboard.Close();
            boundingBox.transform.localScale = buildingScale;
            boundingBox.SetActive(true);
            ToolTip_frame.SetActive(false);

            if (informationPanel != null)
            {

                informationPanel.SetActive(true);
                Vector3 tmp = gameObject.transform.TransformPoint(this.transform.up * gameObject.GetComponent<BoxCollider>().size.y);
                //add small offset for y.position
                informationPanel.transform.position = new Vector3(tmp.x, (tmp.y + 0.5f), tmp.z);
                gameObjName = GameObject.Find("InformationPanel/TextContent/Subtitle01/Subtitle01.1").GetComponent<Text>();
                gameObjtype = GameObject.Find("InformationPanel/TextContent/Subtitle02/Subtitle02.1").GetComponent<Text>();
                gameObjPackage = GameObject.Find("InformationPanel/TextContent/Subtitle03/Subtitle03.1").GetComponent<Text>();
                gameObjNote = GameObject.Find("InformationPanel/TextContent/Subtitle04/Subtitle04.1").GetComponent<Text>();


                //set Text 
                gameObjName.text = gameObject.name;
                gameObjPackage.text = gameObject.transform.parent.name;
                gameObjNote.text = annotation;

                if (gameObject.name.Contains("Service"))
                {
                    gameObjtype.text = "Service";
                }
                if (gameObject.name.Contains("Class"))
                {
                    gameObjtype.text = "Class";
                }
                if (gameObject.name.Contains("Enum"))
                {
                    gameObjtype.text = "Enum";
                }
            }
        }
    }

    //TwoHandManipulation is only allowed, if Adjust Mode is active:
    void Update()
    {
        if(appBarScript != null)
        {
            if (!(appBarScript.State == AppBar.AppBarStateEnum.Manipulation))
            {
                twohandScript.enabled = false;

            }
            else
            {
                twohandScript.enabled = true;
                informationPanel.SetActive(false);
                boundingBox.SetActive(false);
            }
        }
    }
}
