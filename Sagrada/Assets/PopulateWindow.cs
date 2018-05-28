using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PopulateWindow : MonoBehaviour {


    public GameObject sprite;
    private SpriteRenderer spriteRenderer;
    public Window mWindow;
    public GameObject windowObject;
    System.Random random = new System.Random();
    private string[] windowNames ={ "aurora_sagradis", "bellesguard", "broken_tiles"
                                    ,"chromatic", "fractal_drops", "industria", "luz_celestial", "shades_of_glass"
                                    ,"shadow_thief", "shattered", "sun_catcher", "symphony_of_light"};
    string window;

	// Use this for initialization
	void Start () {
        windowObject = GameObject.Find("Player1Window");
        mWindow = windowObject.GetComponent<Window>();
        Populate();
	}

    // Update is called once per frame
    void Update () {
		
	}

    private void Populate()
    {
        window = drawWindow();
        
        Sprite[] sprites = Resources.LoadAll<Sprite>("Okna/Colors");
        System.Random random = new System.Random();

        for (int i = 0; i < 20; i++)
        {
           var newTile = Instantiate(sprite, transform);
            newTile.GetComponent<Image>().sprite = sprites[random.Next(0,sprites.Length)];
            //allTiles[i] = newTile;
        }

        mWindow.createWindow();
        foreach(WindowTile tile in mWindow.getWindowTiles())
        {
            Debug.Log("Tiles: " + tile.getTileValue());
        }
    }


    private string drawWindow()
    {
        string selectedWindow = "";
        selectedWindow = windowNames[random.Next(0, windowNames.Length)];
        return selectedWindow;
    }
}
