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

    public void createWindow(string side)
    {
        int index = UnityEngine.Random.Range(0, windowNames.Length);
        string window = windowNames[index];
        for (int i = 0; i < 20; i++)
        {
            WindowTile clone = Instantiate(baseTile) as WindowTile;
            clone.setFront(window,i);
            clone.id = i;
            clone.tag = "TileClone"+side;
            clone.tilesPerRow = 5;
            windowTiles.Add(clone);
        }
        foreach(WindowTile win in windowTiles)
        {
            setNeighbours(win);
        }
        difficulty = UnityEngine.Random.Range(0, 6);
        windowName = window;
    }

    private void setNeighbours(WindowTile clone)
    {
        if (inBounds(windowTiles, clone.id - clone.tilesPerRow))
        {
            clone.tileUp = windowTiles[clone.id - clone.tilesPerRow];
            clone.adjacentList.Add(clone.tileUp);
        }
        if (inBounds(windowTiles, clone.id + clone.tilesPerRow))
        {
            clone.tileDown = windowTiles[clone.id + clone.tilesPerRow];
            clone.adjacentList.Add(clone.tileDown);

        }
        if (inBounds(windowTiles, clone.id - 1) && clone.id % clone.tilesPerRow != 0)
        {
            clone.tileLeft = windowTiles[clone.id - 1];
            clone.adjacentList.Add(clone.tileLeft);

        }
        if (inBounds(windowTiles, clone.id + 1) && (clone.id + 1) % clone.tilesPerRow != 0)
        {
            clone.tileRight = windowTiles[clone.id + 1];
            clone.adjacentList.Add(clone.tileRight);

        }
        if (inBounds(windowTiles, clone.id - clone.tilesPerRow - 1) && clone.id % clone.tilesPerRow != 0)
        {
            clone.tileUpLeft = windowTiles[clone.id - clone.tilesPerRow - 1];
            clone.adjacentList.Add(clone.tileUpLeft);

        }
        if (inBounds(windowTiles, clone.id - clone.tilesPerRow + 1) && (clone.id + 1) % clone.tilesPerRow != 0)
        {
            clone.tileUpRight = windowTiles[clone.id - clone.tilesPerRow + 1];
            clone.adjacentList.Add(clone.tileUpRight);

        }
        if (inBounds(windowTiles, clone.id + clone.tilesPerRow - 1) && clone.id % clone.tilesPerRow != 0)
        {
            clone.tileDownLeft = windowTiles[clone.id + clone.tilesPerRow - 1];
            clone.adjacentList.Add(clone.tileDownLeft);

        }
        if (inBounds(windowTiles, clone.id + clone.tilesPerRow + 1) && (clone.id + 1) % clone.tilesPerRow != 0)
        {
            clone.tileDownRight = windowTiles[clone.id + clone.tilesPerRow + 1];
            clone.adjacentList.Add(clone.tileDownRight);

        }

    }

    private bool inBounds(List<WindowTile> list, int tileId)
    {
        if (tileId < 0 || tileId >= list.Count)
        {
            return false;
        } else
        {
            return true;
        }
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

    public void centerWindow()
    {
        float dirX = -1.5f + 0.69f;
        float dirY = -0.85f + 0.69f;
        float tileSize = 0.69f;
        int numOfCols = 5;
        int counter = 0;
        foreach(WindowTile tile in windowTiles)
        {
            dirX += tileSize;
            if (counter % numOfCols == 0) 
            {
                dirY -= tileSize;
                dirX = -1.5f;
            }
            counter++;
            tile.transform.position = new Vector3(dirX, dirY, tile.transform.position.z);
        }
    }

}

