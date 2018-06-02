using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    private GameObject windowLeftObject;
    private GameObject windowRightObject;
    private GameObject tableObject;
    private GameObject playerWindowObject;
    
    private Window windowLeft;
    private Window windowRight;
    private Table table;
    private Window playerWindow;
    private WindowTile selectedTile;

    private GameObject titleObject;
    private Text title;

    private GameObject playerObject;
    private Player player;

    private Button leftWindowButton;
    private Button rightWindowButton;

    private void Awake()
    {
        windowLeftObject = GameObject.Find("WindowLeft");
        windowRightObject = GameObject.Find("WindowRight");
        playerWindowObject = GameObject.Find("Player1Window");
        playerWindow = playerWindowObject.GetComponent<Window>();
        windowLeft = windowLeftObject.GetComponent<Window>();
        windowRight = windowRightObject.GetComponent<Window>();

        playerObject = GameObject.Find("Player1");
        player = playerObject.GetComponent<Player>();

        tableObject = GameObject.Find("Table");
        table = tableObject.GetComponent<Table>();

        titleObject = GameObject.Find("Title");
        title = titleObject.GetComponent<Text>();
    }

    // Use this for initialization
    void Start () {
        windowLeft.createWindow();
        windowRight.createWindow();

        Debug.Log("Left window tiles: " + windowLeft.windowTiles.Count);
        Debug.Log("Right window tiles: " + windowRight.windowTiles.Count);

        windowLeft.moveWindow(0);
        windowRight.moveWindow(1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
