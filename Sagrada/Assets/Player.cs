using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    public string playerName;
    public int score;
    public bool playing;
    private GameObject windowObject;
    private Window window;

    private void Awake()
    {
        windowObject = GameObject.Find("Player1Window");
        window = windowObject.GetComponent<Window>();
        score = 0;
        playing = true;
    }

    public void reloadWindow()
    {
        windowObject = GameObject.Find("Player1Window");
        window = windowObject.GetComponent<Window>();
    }

    public string getPlayerName()
    {
        return this.playerName;
    }

    public void setPlayerName(string name)
    {
        this.playerName = name;
    }

    public int getScore()
    {
        return this.score;
    }

    public void setScore(int score)
    {
        this.score = score;
    }

    public Window getWindow()
    {
        return this.window;
    }

    public void showWindow(bool show)
    {
        float value = -3.0f;
        foreach(WindowTile tile in window.getWindowTiles())
        {
            tile.transform.position = new Vector3(value, this.transform.position.y, tile.transform.position.z);
        }
    }
}
