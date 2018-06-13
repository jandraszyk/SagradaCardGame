using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Game : MonoBehaviour {

    //-------Windows & Dice------------//
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
    private Dice selectedDice;

    //---------Lists of dices----------//
    private List<Dice> draftedDices = new List<Dice>();
    public List<Dice> placedDices = new List<Dice>();
    public List<Dice> discardedDices = new List<Dice>();
    public List<Tool> generatedTools = new List<Tool>();
    public List<PrivateObjective> generatedPrivateObjectives = new List<PrivateObjective>();
    public List<PublicObjective> generatedPublicObjectives = new List<PublicObjective>();

    //----------Text Objects----------//
    private GameObject titleObject;
    private Text title;
    private GameObject roundTrackObject;
    private Text roundTrack;
    private GameObject totalScoreTextObject;
    private GameObject totalScoreObject;
    private Text totalScoreTxt;
    private GameObject textOverObject;
    private Text textOver;
    private GameObject textPlayerObject;
    private Text textPlayerScore;
    private GameObject textGameObject;
    private Text textGameScore;

    //---------Player Object-----------//
    private GameObject playerObject;
    private Player player;

    //-------Tool Objects-----------//
    private GameObject toolObject;
    private Tool tool;
    private Tool showingTool;
    private int currentToolShowing = 0;
    private int currentPublic = 0;
    private int currentPrivate = 0;

    private GameObject privateObjectiveObject;
    private GameObject publicObjectiveObject;
    private PrivateObjective privateObjective;
    private PrivateObjective showingPrivateObjective;
    private PublicObjective publicObjective;
    private PublicObjective showingPublicObjective;

    //------Buttons------------//
    private GameObject leftWindowButton;
    private GameObject rightWindowButton;
    private GameObject draftDiceButton;
    private GameObject showToolsButton;
    private GameObject showPrivateObjectiveButton;
    private GameObject showPublicObjectiveButton;
    private GameObject toolBackground;
    private GameObject publicBackground;
    private GameObject privateBackground;
    private GameObject panelGameOver;

    private int numOfTours = 1;
    private int totalScore = 0;
    private int playerScore = 0;
    private int placedInTurn = 0;


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

        totalScoreTextObject = GameObject.Find("TotalScoreText");
        totalScoreObject = GameObject.Find("TotalScore");
        totalScoreTxt = totalScoreObject.GetComponent<Text>();

        textPlayerObject = GameObject.Find("TextPlayerScore");
        textPlayerScore = textPlayerObject.GetComponent<Text>();

        textGameObject = GameObject.Find("TextGameScore");
        textGameScore = textGameObject.GetComponent<Text>();


        toolObject = GameObject.Find("Tool");
        tool = toolObject.GetComponent<Tool>();

        privateObjectiveObject = GameObject.Find("PrivateObjective");
        privateObjective = privateObjectiveObject.GetComponent<PrivateObjective>();

        publicObjectiveObject = GameObject.Find("PublicObjective");
        publicObjective = publicObjectiveObject.GetComponent<PublicObjective>();


        roundTrackObject = GameObject.Find("RoundTrack");
        roundTrack = roundTrackObject.GetComponent<Text>();

        leftWindowButton = GameObject.Find("ButtonLeft");
        rightWindowButton = GameObject.Find("ButtonRight");
        draftDiceButton = GameObject.Find("ButtonDraft");
        showToolsButton = GameObject.Find("ButtonTools");
        showPrivateObjectiveButton = GameObject.Find("ButtonPrivateObjective");
        showPublicObjectiveButton = GameObject.Find("ButtonPublicObjective");
        toolBackground = GameObject.Find("ToolBackground");
        privateBackground = GameObject.Find("PrivateBackground");
        publicBackground = GameObject.Find("PublicBackground");
        panelGameOver = GameObject.Find("PanelGameOver");


    }

    // Use this for initialization
    void Start () {
        draftDiceButton.SetActive(false);
        showToolsButton.SetActive(false);
        showPrivateObjectiveButton.SetActive(false);
        showPublicObjectiveButton.SetActive(false);
        roundTrackObject.SetActive(false);
        totalScoreTextObject.SetActive(false);
        totalScoreObject.SetActive(false);

        windowLeft.createWindow("Left");
        windowRight.createWindow("Right");

        windowLeft.moveWindow(0);
        windowRight.moveWindow(1);
	}
	
	// Update is called once per frame
	void Update () {
        //Selecting Dice & Tile
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0.1f;

        if(Input.GetMouseButtonDown(0))
        {
           
            foreach(Dice d in draftedDices)
            {
                if(d.getBounds().Contains(mousePosition) && d.CompareTag("clone"))
                {
                    selectedDice = d;
                    //Debug.Log("Selected dice value: " + selectedDice.getDiceValue() + " and color: " + selectedDice.getDiceColorName());
                }
            }

            if(selectedDice != null)
            {
                foreach (WindowTile tile in playerWindow.getWindowTiles())
                {
                    
                    if (tile.getBounds().Contains(mousePosition))
                    {
                        if (placedDices.Count == 0)
                        {
                            if(isOnEdge(tile))
                            {
                                selectedTile = tile;
                            } else
                            {
                                Debug.Log("First dice must be placed on the edge of the window");
                                return;
                            }
                        } else
                        {
                            selectedTile = tile;
                        }
                        
                        //Debug.Log("Selected tile value: " + selectedTile.getTileValue());
                        if (selectedTile.getTileValue() == selectedDice.getDiceColorName() || selectedTile.getTileValue() == selectedDice.getDiceValue() || selectedTile.getTileValue() == "white")
                        {
                            if(canBePlaced(selectedDice, selectedTile.getId()))
                            {
                                if(placedInTurn < 2)
                                {
                                    Debug.Log("You can put that dice in here");
                                    selectedDice.tag = "placed";
                                    selectedDice.placedId = selectedTile.getId();
                                    //Dice placed = selectedDice;
                                    draftedDices.Remove(selectedDice);
                                    placedDices.Add(selectedDice);
                                    placedInTurn++;
                                    moveDice();
                                } else
                                {
                                    Debug.Log("You can't put more dice on the window this turn");
                                }
                                
                            } else
                            {
                                Debug.Log("Can't place dice next to the dice with same value and/or color");
                            }
                            
                        }
                        else
                        {
                            Debug.Log("Try somewhere else");
                        }
                    }
                }
            } else
            {
                Debug.Log("Select the dice first");
            }
            
        }
	}

    private bool isOnEdge(WindowTile tile)
    {
        
        if(tile.getId() % 5 == 0  || tile.getId() == 1 
            || tile.getId() == 2 || tile.getId() == 3 
            || tile.getId() % 5 == 4 || tile.getId() == 16
            || tile.getId() == 17 || tile.getId() == 18)
        {
            return true;
        } else
        {
            return false;
        }
    }

    private bool canBePlaced(Dice dice, int id)
    {
        bool canPlace = false;
        if(placedDices.Count != 0)
        {
            Debug.Log("Selected dice: color & value: " + dice.getDiceColorName() + "," + dice.getDiceValue());

            foreach (Dice d in placedDices)
            {
                Debug.Log("Placed dice: color & value: " + d.getDiceColorName() + "," + d.getDiceValue());

                if ((d.placedId == id + 1 && id % 5 !=4)  || (d.placedId == id - 1 && id % 5 != 0)
                    || d.placedId == id - 5 || d.placedId == id + 5
                    //|| d.placedId == id - 6 || d.placedId == id - 4
                    //|| d.placedId == id + 4 || d.placedId == id + 6
                    )
                {
                    if ((d.placedId == id + 1) && (d.getDiceValue() == dice.getDiceValue() || d.getDiceColorName() == dice.getDiceColorName()))
                    {
                        canPlace = false;
                        //return false;
                    }
                    else if ((d.placedId == id - 1) && (d.getDiceValue() == dice.getDiceValue() || d.getDiceColorName() == dice.getDiceColorName()))
                    {
                        canPlace = false;

                        return false;
                    }
                    else if ((d.placedId == id - 5) && (d.getDiceValue() == dice.getDiceValue() || d.getDiceColorName() == dice.getDiceColorName()))
                    {
                        canPlace = false;

                        return false;
                    }
                    else if ((d.placedId == id + 5) && (d.getDiceValue() == dice.getDiceValue() || d.getDiceColorName() == dice.getDiceColorName()))
                    {
                        canPlace = false;

                        return false;
                    }
                    else
                    {
                        canPlace = true;
                    }
                }
                if ((d.placedId == id - 6) && id % 5 != 0 || (d.placedId == id - 4 && id % 5 != 4)
                    || (d.placedId == id + 4 && id % 5 != 0) || (d.placedId == id + 6 && id % 5 != 4))
                {
                    canPlace = true;
                }

            }
            return canPlace;
        }
        return true;
        
    }

    private void moveDice()
    {
        selectedDice.transform.position = selectedTile.transform.position;
        selectedTile.transform.position = new Vector3(-10.0f, -10.0f, 0.0f);
        selectedDice = null;

    }

    public void draftDice()
    {
        placedInTurn = 0;
        
        Debug.Log("Round number: " + numOfTours);
        foreach(Dice d in draftedDices)
        {
            setTotalScore(Int32.Parse(d.getDiceValue()));
            Debug.Log("Total end score: " + getTotalScore());
        }
        totalScoreTxt.text = getTotalScore().ToString();
        moveToRoundTrack();
        draftedDices.Clear();
        if (numOfTours > 10)
        {
            gameOver();
            Debug.Log("End of the game");
            return;
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
        numOfTours++;
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

    public void moveToRoundTrack()
    {
        float dirY = 2.5f;
        float dirX = -5.69f;
        float tileSize = 0.69f;
        foreach (Dice d in draftedDices)
        {
            d.transform.position = new Vector3(dirX + numOfTours * tileSize, dirY, d.transform.position.z);
        }
    }

    public void pickWindow(string window)
    {
        if(window =="left")
        {
            playerWindow = windowLeft;
            var clones = GameObject.FindGameObjectsWithTag("TileCloneRight");
            foreach (var clone in clones)
            {
                Destroy(clone);
            }
            rightWindowButton.SetActive(false);
            leftWindowButton.SetActive(false);
            draftDiceButton.SetActive(true);
            showToolsButton.SetActive(true);
            showPrivateObjectiveButton.SetActive(true);
            showPublicObjectiveButton.SetActive(true);
            generateToolCards();


            titleObject.SetActive(false);
            playerWindow.centerWindow();
            roundTrackObject.SetActive(true);
            totalScoreTextObject.SetActive(true);
            totalScoreObject.SetActive(true);
        }
        if (window == "right")
        {
            playerWindow = windowRight;
            var clones = GameObject.FindGameObjectsWithTag("TileCloneLeft");
            foreach (var clone in clones)
            {
                Destroy(clone);
            }
            leftWindowButton.SetActive(false);
            rightWindowButton.SetActive(false);
            draftDiceButton.SetActive(true);
            showToolsButton.SetActive(true);
            showPrivateObjectiveButton.SetActive(true);
            showPublicObjectiveButton.SetActive(true);

            titleObject.SetActive(false);
            playerWindow.centerWindow();
            roundTrackObject.SetActive(true);
            totalScoreTextObject.SetActive(true);
            totalScoreObject.SetActive(true);
            generateToolCards();

        }
        generatePrivateObjective();
        generatePublicObjective();
    }

    public void setTotalScore(int score)
    {
        totalScore += score;
    }

    public int getTotalScore()
    {
        return totalScore;
    }

    public void showToolCard(string arrow)
    {
        showToolsButton.SetActive(false);
        showPrivateObjectiveButton.SetActive(false);
        showPublicObjectiveButton.SetActive(false);
        toolBackground.transform.position = new Vector3(0, 0, -1);
        if (arrow.Equals("left"))
        {
            if (currentToolShowing > 0)
            {
                currentToolShowing--;
            }
        }
        else if (arrow.Equals("right"))
        {
            if (currentToolShowing < generatedTools.Count - 1)
            {
                currentToolShowing++;
            }
        }

        for (int i = 0; i < generatedTools.Count; i++)
        {
            if (currentToolShowing == i)
            {
                generatedTools[i].transform.position = new Vector3(0, 0, -1);
                generatedTools[i].isShowing = true;
                showingTool = generatedTools[i];
            }
            else
            {
                generatedTools[i].transform.position = new Vector3(-20, 0, -1);
                generatedTools[i].isShowing = false;
            }
        }


    }

    public void showPrivateObjective(string arrow)
    {
        showToolsButton.SetActive(false);
        showPrivateObjectiveButton.SetActive(false);
        showPublicObjectiveButton.SetActive(false);
        privateBackground.transform.position = new Vector3(0, 0, -1);
        if (arrow.Equals("left"))
        {
            if (currentPrivate > 0)
            {
                currentPrivate--;
            }
        }
        else if (arrow.Equals("right"))
        {
            if (currentPrivate < generatedPrivateObjectives.Count - 1)
            {
                currentPrivate++;
            }
        }

        for (int i = 0; i < generatedPrivateObjectives.Count; i++)
        {
            if (currentPrivate == i)
            {
                generatedPrivateObjectives[i].transform.position = new Vector3(0, 0, -1);
                generatedPrivateObjectives[i].isShowing = true;
                showingPrivateObjective = generatedPrivateObjectives[i];
            }
            else
            {
                generatedPrivateObjectives[i].transform.position = new Vector3(-20, 0, -1);
                generatedPrivateObjectives[i].isShowing = false;
            }
        }


    }

    public void showPublicObiective(string arrow)
    {
        showToolsButton.SetActive(false);
        showPrivateObjectiveButton.SetActive(false);
        showPublicObjectiveButton.SetActive(false);
        publicBackground.transform.position = new Vector3(0, 0, -1);
        if (arrow.Equals("left"))
        {
            if (currentPublic > 0)
            {
                currentPublic--;
            }
        }
        else if (arrow.Equals("right"))
        {
            if (currentPublic < generatedPublicObjectives.Count - 1)
            {
                currentPublic++;
            }
        }

        for (int i = 0; i < generatedPublicObjectives.Count; i++)
        {
            if (currentPublic == i)
            {
                generatedPublicObjectives[i].transform.position = new Vector3(0, 0, -1);
                generatedPublicObjectives[i].isShowing = true;
                showingPublicObjective = generatedPublicObjectives[i];
            }
            else
            {
                generatedPublicObjectives[i].transform.position = new Vector3(-20, 0, -1);
                generatedPublicObjectives[i].isShowing = false;
            }
        }


    }

    public void closeToolCard()
    {
        foreach (Tool clone in generatedTools)
        {
            clone.transform.position = new Vector3(-20, 0, -1);
            clone.isShowing = false;
        }
        var usedObjects = GameObject.FindGameObjectsWithTag("Used");
        foreach (var used in usedObjects)
        {
            Destroy(used);
        }
        toolBackground.transform.position = new Vector3(0, -600, -1);
        showToolsButton.SetActive(true);
        showPrivateObjectiveButton.SetActive(true);
        showPublicObjectiveButton.SetActive(true);
    }

    public void closePrivateObjective()
    {
        foreach (PrivateObjective clone in generatedPrivateObjectives)
        {
            clone.transform.position = new Vector3(-20, 0, -1);
            clone.isShowing = false;
        }
        var usedObjects = GameObject.FindGameObjectsWithTag("Used");
        foreach (var used in usedObjects)
        {
            Destroy(used);
        }
        privateBackground.transform.position = new Vector3(0, -600, -1);
        showToolsButton.SetActive(true);
        showPrivateObjectiveButton.SetActive(true);
        showPublicObjectiveButton.SetActive(true);
    }

    public void closePublicObjective()
    {
        foreach (PublicObjective clone in generatedPublicObjectives)
        {
            clone.transform.position = new Vector3(-20, 0, -1);
            clone.isShowing = false;
        }
        var usedObjects = GameObject.FindGameObjectsWithTag("Used");
        foreach (var used in usedObjects)
        {
            Destroy(used);
        }
        publicBackground.transform.position = new Vector3(0, -600, -1);
        showToolsButton.SetActive(true);
        showPrivateObjectiveButton.SetActive(true);
        showPublicObjectiveButton.SetActive(true);
    }

    public void buyToolCard()
    {
        if (selectedDice == null)
        {
            Debug.Log("You didnt select any dice");
            return;
        } else
        {
            if (selectedDice.getDiceColorName() == showingTool.getcolorValue())
            {
                selectedDice.tag = "Used";
                draftedDices.Remove(selectedDice);
                showingTool.tag = "Used";
                generatedTools.Remove(showingTool);
            }
            else
            {
                Debug.Log("Dice color doesn't match the required tool color value");
            }
        }
    }

    public void generateToolCards()
    {
        int difficultyLevel = ChangeDifficulty.currentDifficulty;

        for (int i = 0; i < difficultyLevel; i++)
        {
            int index = UnityEngine.Random.Range(0, 12);
            Tool createdTool = Instantiate(tool) as Tool;
            createdTool.setFront(index);
            createdTool.tag = "Tool";
            Debug.Log("Generated tool color value: " + createdTool.getcolorValue());
            generatedTools.Add(createdTool);
        }
    }
    public void generatePrivateObjective()
    {
        int numberOfCards = 2;

        for (int i = 0; i < numberOfCards; i++)
        {
            int index = UnityEngine.Random.Range(0, 4);
            PrivateObjective createdTool = Instantiate(privateObjective) as PrivateObjective;
            createdTool.setFront(index);
            createdTool.tag = "PrivateObjective";
            Debug.Log("Generated private objective");
            generatedPrivateObjectives.Add(createdTool);
        }
    }
    public void generatePublicObjective()
    {
        int numberOfCards = 2;

        for (int i = 0; i < numberOfCards; i++)
        {
            int index = UnityEngine.Random.Range(0, 10);
            PublicObjective createdTool = Instantiate(publicObjective) as PublicObjective;
            createdTool.setFront(index);
            createdTool.tag = "PublicObjective";
            Debug.Log("Generated public objective");
            generatedPublicObjectives.Add(createdTool);
        }
    }

    public void gameOver()
    {
        showPlayerScore();
        panelGameOver.transform.position = new Vector3(0, 0, -1);
        textGameScore.text = getTotalScore().ToString();
        draftDiceButton.SetActive(false);
        showToolsButton.SetActive(false);
        showPrivateObjectiveButton.SetActive(false);
        showPublicObjectiveButton.SetActive(false);
    }
    private void showPlayerScore()
    {
        playerScore = privateObjectiveScore() + publicObjectiveScore() - penaltyPoints();
        textPlayerScore.text = playerScore.ToString();
    }

    private int penaltyPoints()
    {
        Debug.Log("Rozmiar planszy: " + placedDices.Count);
        return (20 - placedDices.Count)*3;
    }

    private int privateObjectiveScore()
    {
        int[] score = { 0, 0 };
        int i = 0;
        foreach(PrivateObjective privateObjective in generatedPrivateObjectives)
        {
            
            switch (privateObjective.getMethod())
            {
                case "Blue":
                    score[i] += privateBlue();
                    break;
                case "Red":
                    score[i] += privateRed();
                    break;
                case "Green":
                    score[i] += privateGreen();
                    break;
                case "Yellow":
                    score[i] += privateYellow();
                    break;
                default:
                    break;
            }
            i++;
        }
        Debug.Log("Pierwszy: " + score[0]);
        Debug.Log("Drugi: " + score[1]);
        return score.Max();
    }
    private int privateBlue()
    {
        int score = 0;
        foreach(Dice dice in placedDices){
            if (dice.getDiceColorName().Equals("blue"))
            {
                score += Int32.Parse(dice.getDiceValue());
            }
        }
        return score;
    }

    private int privateRed()
    {
        int score = 0;
        foreach (Dice dice in placedDices){
            if (dice.getDiceColorName().Equals("red"))
            {
                score += Int32.Parse(dice.getDiceValue());
            }
        }
        return score;
    }

    private int privateGreen()
    {
        int score = 0;
        foreach (Dice dice in placedDices){
            if (dice.getDiceColorName().Equals("green"))
            {
                score += Int32.Parse(dice.getDiceValue());
            }
        }
        return score;
    }

    private int privateYellow()
    {
        int score = 0;
        foreach (Dice dice in placedDices){
            if (dice.getDiceColorName().Equals("yellow"))
            {
                score += Int32.Parse(dice.getDiceValue());
            }
        }
        return score;
    }

    private int publicObjectiveScore()
    {
        int score = 0;
        foreach (PublicObjective publicObjective in generatedPublicObjectives)
        {

            switch (publicObjective.getMethod())
            {
                case 1:
                    score += public1();
                    break;
                case 2:
                    score += public2();
                    break;
                case 3:
                    score += public3();
                    break;
                case 4:
                    score += public4();
                    break;
                case 5:
                    score += public5();
                    break;
                case 6:
                    score += public6();
                    break;
                case 7:
                    score += public7();
                    break;
                case 8:
                    score += public8();
                    break;
                case 9:
                    score += public9();
                    break;
                case 10:
                    score += public10();
                    break;
                default:
                    break;
            }
        }
        return score;
    }

    private int public1()
    {

        HashSet<string> row1 = new HashSet<string>();
        HashSet<string> row2 = new HashSet<string>();
        HashSet<string> row3 = new HashSet<string>();
        HashSet<string> row4 = new HashSet<string>();
        foreach (Dice dice in placedDices)
        {
            if (dice.placedId >= 0 && dice.placedId < 5)
            {
                row1.Add(dice.diceColorName);
            }
            if (dice.placedId >= 5 && dice.placedId < 10)
            {
                row2.Add(dice.diceColorName);
            }
            if (dice.placedId >= 10 && dice.placedId < 15)
            {
                row3.Add(dice.diceColorName);
            }
            if (dice.placedId >= 15 && dice.placedId < 20)
            {
                row4.Add(dice.diceColorName);
            }
        }
        int playerScore = 0;
        if (row1.Count == 5)
        {
            playerScore += 6;
        }
        if (row2.Count == 5)
        {
            playerScore += 6;
        }
        if (row3.Count == 5)
        {
            playerScore += 6;
        }
        if (row4.Count == 5)
        {
            playerScore += 6;
        }
        return playerScore;
    }
    private int public2()
    {

        HashSet<string> col1 = new HashSet<string>();
        HashSet<string> col2 = new HashSet<string>();
        HashSet<string> col3 = new HashSet<string>();
        HashSet<string> col4 = new HashSet<string>();
        HashSet<string> col5 = new HashSet<string>();
        foreach (Dice dice in placedDices)
        {
            if (dice.placedId == 0 || dice.placedId == 5 || dice.placedId == 10 || dice.placedId == 15)
            {
                col1.Add(dice.diceColorName);
            }
            if (dice.placedId == 1 || dice.placedId == 6 || dice.placedId == 11 || dice.placedId == 16)
            {
                col2.Add(dice.diceColorName);
            }
            if (dice.placedId == 2 || dice.placedId == 7 || dice.placedId == 12 || dice.placedId == 17)
            {
                col3.Add(dice.diceColorName);
            }
            if (dice.placedId == 3 || dice.placedId == 8 || dice.placedId == 13 || dice.placedId == 18)
            {
                col4.Add(dice.diceColorName);
            }
            if (dice.placedId == 4 || dice.placedId == 9 || dice.placedId == 14 || dice.placedId == 19)
            {
                col5.Add(dice.diceColorName);
            }
        }
        int playerScore = 0;
        if (col1.Count == 4)
        {
            playerScore += 5;
        }
        if (col2.Count == 4)
        {
            playerScore += 5;
        }
        if (col3.Count == 4)
        {
            playerScore += 5;
        }
        if (col4.Count == 4)
        {
            playerScore += 5;
        }
        if (col5.Count == 4)
        {
            playerScore += 5;
        }
        return playerScore;
    }
    private int public3()
    {

        int score = 0;
        /* foreach (Dice dice in placedDices)
         {
             if (dice.placedId
             {
                 score++;
             }
         }*/
        return playerScore;
    }
    private int public4()
    {

        int score = 0;
        /* foreach (Dice dice in placedDices)
         {
             if (dice.placedId
             {
                 score++;
             }
         }*/
        return playerScore;
    }
    private int public5()
    {

        HashSet<int> row1 = new HashSet<int>();
        HashSet<int> row2 = new HashSet<int>();
        HashSet<int> row3 = new HashSet<int>();
        HashSet<int> row4 = new HashSet<int>();
        foreach (Dice dice in placedDices)
        {
            if (dice.placedId >= 0 && dice.placedId < 5)
            {
                row1.Add(dice.placedId);
            }
            if (dice.placedId >= 5 && dice.placedId < 10)
            {
                row2.Add(dice.placedId);
            }
            if (dice.placedId >= 10 && dice.placedId < 15)
            {
                row3.Add(dice.placedId);
            }
            if (dice.placedId >= 15 && dice.placedId < 20)
            {
                row4.Add(dice.placedId);
            }
        }
        int playerScore = 0;
        if (row1.Count == 5)
        {
            playerScore += 5;
        }
        if (row2.Count == 5)
        {
            playerScore += 5;
        }
        if (row3.Count == 5)
        {
            playerScore += 5;
        }
        if (row4.Count == 5)
        {
            playerScore += 5;
        }
        return playerScore;

    }
    private int public6()
    {

        HashSet<int> col1 = new HashSet<int>();
        HashSet<int> col2 = new HashSet<int>();
        HashSet<int> col3 = new HashSet<int>();
        HashSet<int> col4 = new HashSet<int>();
        HashSet<int> col5 = new HashSet<int>();
        foreach (Dice dice in placedDices)
        {
            if (dice.placedId == 0 || dice.placedId == 5 || dice.placedId == 10 || dice.placedId == 15)
            {
                col1.Add(dice.placedId);
            }
            if (dice.placedId == 1 || dice.placedId == 6 || dice.placedId == 11 || dice.placedId == 16)
            {
                col2.Add(dice.placedId);
            }
            if (dice.placedId == 2 || dice.placedId == 7 || dice.placedId == 12 || dice.placedId == 17)
            {
                col3.Add(dice.placedId);
            }
            if (dice.placedId == 3 || dice.placedId == 8 || dice.placedId == 13 || dice.placedId == 18)
            {
                col4.Add(dice.placedId);
            }
            if (dice.placedId == 4 || dice.placedId == 9 || dice.placedId == 14 || dice.placedId == 19)
            {
                col5.Add(dice.placedId);
            }
        }
        int playerScore = 0;
        if (col1.Count == 4)
        {
            playerScore += 4;
        }
        if (col2.Count == 4)
        {
            playerScore += 4;
        }
        if (col3.Count == 4)
        {
            playerScore += 4;
        }
        if (col4.Count == 4)
        {
            playerScore += 4;
        }
        if (col5.Count == 4)
        {
            playerScore += 4;
        }
        return playerScore;
    }
    private int public7()
    {

        int score = 0;
        /* foreach (Dice dice in placedDices)
         {
             if (dice.placedId
             {
                 score++;
             }
         }*/
        return playerScore;
    }
    private int public8()
    {

        int score = 0;
        /* foreach (Dice dice in placedDices)
         {
             if (dice.placedId
             {
                 score++;
             }
         }*/
        return playerScore;
    }
    private int public9()
    {
        int score = 0;
        /* foreach (Dice dice in placedDices)
         {
             if (dice.placedId
             {
                 score++;
             }
         }*/
        return playerScore;
    }
    private int public10()
    {

        int score = 0;
        /* foreach (Dice dice in placedDices)
         {
             if (dice.placedId
             {
                 score++;
             }
         }*/
        return playerScore;
    }
}
