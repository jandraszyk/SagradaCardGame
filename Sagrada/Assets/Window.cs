using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour {

    public string windowName;
    public int difficulty;
    public bool selected;
    private GameObject windowTileGameObject;
    private WindowTile baseTile;
    public List<WindowTile> windowTiles;

    private string[] windowNames = { "aurora_sagradis", "bellesguard", "broken_tiles", "chromatic", "industria", "fractal_drops" };

    private static int TILES_NUMBER = 11;

    private void Awake()
    {
        windowTileGameObject = GameObject.Find("WindowTile");
        baseTile = windowTileGameObject.GetComponent<WindowTile>();
    }

    public void createWindow()
    {
        int index = UnityEngine.Random.Range(0, windowNames.Length);
        string window = windowNames[index];
        for (int i = 0; i < 20; i++)
        {
            WindowTile clone = Instantiate(baseTile) as WindowTile;
            clone.setFront(window,i);
            windowTiles.Add(clone);
        }
        difficulty = UnityEngine.Random.Range(0, 6);
        windowName = window;
    }

    public List<WindowTile> getWindowTiles()
    {
        return this.windowTiles;
    }

    public void setWindowTiles(WindowTile windowTile)
    {
        this.windowTiles.Add(windowTile);
    }

    public string getWindowName()
    {
        return windowName;
    }

    public void setWindowName(string windowName)
    {
        this.windowName = windowName;
    }

    public int getDifficulty()
    {
        return difficulty;
    }

    public void setDifficulty(int difficulty)
    {
        this.difficulty = difficulty;
    }

    

    public bool isSelected()
    {
        return selected;
    }

    public void setSelected(bool selected)
    {
        this.selected = selected;
    }

    // [0] - left [1] - right
    public void moveWindow(int direction)
    {
        float dirX = 5.69f;
        float dirY = 1.69f;
        float tileSize = 0.69f;
        int numOfCols = 5;
        int counter = 0;
        if (direction == 0)
        {

            foreach(WindowTile tile in windowTiles)
            {
                dirX -= tileSize;
                if(counter % numOfCols == 0)
                {
                    dirY -= tileSize;
                    dirX = 5.0f;
                }
                counter++;
                tile.transform.position = new Vector3(tile.transform.position.x - dirX, tile.transform.position.y + dirY, tile.transform.position.z);
            }
        }
        if(direction == 1)
        {
            dirX = 5.0f;
            foreach (WindowTile tile in windowTiles)
            {
                dirX += tileSize;
                if (counter % numOfCols == 0)
                {
                    dirY -= tileSize;
                    dirX = 5.0f;
                }
                counter++;
                tile.transform.position = new Vector3(tile.transform.position.x + dirX-numOfCols*tileSize, tile.transform.position.y + dirY, tile.transform.position.z);
            }
        }
    }

}
