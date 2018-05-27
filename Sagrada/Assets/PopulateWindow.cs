using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateWindow : MonoBehaviour {


    public int numOfTiles;
    public GameObject sprite;
    public string nameOfWindow;

	// Use this for initialization
	void Start () {
        Populate();
	}

    // Update is called once per frame
    void Update () {
		
	}

    private void Populate()
    {

    GameObject newTile;
        for(int i=0; i< numOfTiles; i++)
        {
            newTile = (GameObject)Instantiate(sprite, transform);
            newTile.GetComponent<Image>().sprite = Resources.Load<Sprite>("Okna/aurora_sagradis/8");
        }
    }
}
