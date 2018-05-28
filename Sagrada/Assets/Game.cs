using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    private GameObject windowLeftObject;
    private GameObject windowRightObject;
    private Window windowLeft;
    private Window windowRight;
    private Button leftWindowButton;
    private Button rightWindowButton;
    private Text title;
    private Button quitButton;

    private void Awake()
    {
        windowLeftObject = GameObject.Find("WindowLeft");
        windowRightObject = GameObject.Find("WindowRight");
        windowLeft = windowLeftObject.GetComponent<Window>();
        windowRight = windowRightObject.GetComponent<Window>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
