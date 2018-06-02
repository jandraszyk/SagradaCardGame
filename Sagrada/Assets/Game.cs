using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    private GameObject windowLeftObject;
    private GameObject windowRightObject;
    private GameObject tableObject;
    private GameObject playerWindowObject;
    private GameObject diceObject;
    
    private Window windowLeft;
    private Window windowRight;
    private Table table;
    private Window playerWindow;
    private WindowTile selectedTile;
    private Dice dice;
    private List<Dice> draftedDices = new List<Dice>();
    private Dice selectedDice;

    private GameObject titleObject;
    private Text title;

    private GameObject playerObject;
    private Player player;

    private Button leftWindowButton;
    private Button rightWindowButton;

    private string[] diceColors = { "red", "blue", "green", "yellow", "purple" };

    private void Awake()
    {
        windowLeftObject = GameObject.Find("WindowLeft");
        windowRightObject = GameObject.Find("WindowRight");
        playerWindowObject = GameObject.Find("Player1Window");
        diceObject = GameObject.Find("Dice");
        playerWindow = playerWindowObject.GetComponent<Window>();
        windowLeft = windowLeftObject.GetComponent<Window>();
        windowRight = windowRightObject.GetComponent<Window>();
        dice = diceObject.GetComponent<Dice>();

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
        Debug.Log("Left window name: " + windowLeft.getWindowName());
        Debug.Log("Right window name: " + windowRight.getWindowName());

        windowLeft.moveWindow(0);
        windowRight.moveWindow(1);
	}
	
	// Update is called once per frame
	void Update () {
        //Selecting Tile

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0.1f;

        if(Input.GetMouseButtonDown(0))
        {
           
            foreach(Dice d in draftedDices)
            {
                if(d.getBounds().Contains(mousePosition))
                {
                    selectedDice = d;
                    Debug.Log("Selected dice value: " + selectedDice.getDiceValue() + " and color: " + selectedDice.getDiceColorName());
                }
            }

            foreach (WindowTile tile in windowLeft.getWindowTiles())
            {
                if (tile.getBounds().Contains(mousePosition))
                {
                    selectedTile = tile;
                    Debug.Log("Selected tile value: " + selectedTile.getTileValue());
                    if(selectedTile.getTileValue() == selectedDice.getDiceColorName() || selectedTile.getTileValue() == selectedDice.getDiceValue() || selectedTile.getTileValue() == "white")
                    {
                        Debug.Log("You can put that dice in here");
                        selectedDice.tag = "placed";
                        moveDice();
                    }
                    else
                    {
                        Debug.Log("Try somewhere else");
                    }
                } 
            }

        }
	}

    private void moveDice()
    {
        selectedDice.transform.position = selectedTile.transform.position;
        selectedTile.transform.position = new Vector3(-10.0f, -10.0f, 0.0f);
        
    }

    public void draftDice()
    {
       
        draftedDices.Clear();
        var clones = GameObject.FindGameObjectsWithTag("clone");
        foreach(var clone in clones)
        {
            Destroy(clone);
        }
        for (int i = 0; i < 4; i++) 
        {
            int index = UnityEngine.Random.Range(0,6);
            int colorIndex = UnityEngine.Random.Range(0, diceColors.Length);
            string color = diceColors[colorIndex];
            Dice clone = Instantiate(dice) as Dice;
            clone.tag = "clone";
            clone.setFront(color, index);
            Debug.Log("Drafted dice color: " + clone.getDiceColorName() + ", value: " + clone.getDiceValue());
        
            draftedDices.Add(clone);
        }
        showDices();
    }

    public void showDices()
    {
        float dirY = 1.69f;
        float diceSize = 0.69f;

        foreach(Dice d in draftedDices)
        {
            dirY -= diceSize;
            d.transform.position = new Vector3(d.transform.position.x, d.transform.position.y - dirY, d.transform.position.z);
        }
    }
}
