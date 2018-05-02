using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class InteractiveHouses : MonoBehaviour, IFocusable {


    public Color NormalColor;
    public Color HighlightColor;
    private Renderer myRenderer;
    private Material myMaterialInstance;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Awake()
    {
        myRenderer = gameObject.GetComponent<Renderer>();

        myMaterialInstance = myRenderer.material;
    }

    public void OnFocusEnter()
    {
        myMaterialInstance.color = HighlightColor;
    }

   public  void OnFocusExit()
    {
        myMaterialInstance.color = NormalColor;
    }
}
