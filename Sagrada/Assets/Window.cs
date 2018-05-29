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

    private static int TILES_NUMBER = 11;

    private void Awake()
    {
        windowTileGameObject = GameObject.Find("WindowTile");
        baseTile = windowTileGameObject.GetComponent<WindowTile>();
    }

    public void createWindow()
    {

        for (int i = 0; i < 20; i++)
        {
            int index = Random.Range(0, TILES_NUMBER);
            WindowTile clone = Instantiate(baseTile) as WindowTile;
            clone.tag = "CloneTile";
            clone.setFront(index);
            windowTiles.Add(clone);
        }
        difficulty = Random.Range(0, 6);
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
        float dir = 3.0f;
        if (direction == 0)
        {

            foreach(WindowTile tile in windowTiles)
            {
                tile.transform.position = new Vector3(tile.transform.position.x + dir * -1, tile.transform.position.y, tile.transform.position.z);
            }
        }
        if(direction == 1)
        {
            foreach (WindowTile tile in windowTiles)
            {
                tile.transform.position = new Vector3(tile.transform.position.x + dir * 1, tile.transform.position.y, tile.transform.position.z);
            }
        }
    }

}
