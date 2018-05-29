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
            tile.transform.position = new Vector3(tile.transform.position.x, -5.35f, tile.transform.position.z);
            Debug.Log("Tiles: " + tile.getTileValue());
        }
    }
}
