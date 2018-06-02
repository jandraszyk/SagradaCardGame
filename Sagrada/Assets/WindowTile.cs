using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowTile : MonoBehaviour {

    public string tileValue;
    private bool active = false;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D tileCollider;

    private WindowModel windowModel;
    private GameObject windowModelGameObject;

    private void Awake()
    {
        windowModelGameObject = GameObject.Find("WindowModel");
        windowModel = windowModelGameObject.GetComponent<WindowModel>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        tileCollider = GetComponent<BoxCollider2D>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public string getTileValue()
    {
        return tileValue;
    }

    public void setTileValue(string value)
    {
        this.tileValue = value;
    }

    public bool isActive()
    {
        return active;
    }

    public void setActive(bool active)
    {
        this.active = active;
    }

    public Bounds getBounds()
    {
        return this.tileCollider.bounds;
    }

    public WindowModel getWindowModel()
    {
        return this.windowModel;
    }

    public void setFront(string windowName, int index)
    {
        switch (windowName)
        {
            case "aurora_sagradis":
                spriteRenderer.sprite = windowModel.getWindowAurora(index);
                tileValue = spriteRenderer.sprite.name;
                break;
            case "bellesguard":
                spriteRenderer.sprite = windowModel.getWindowBellesguard(index);
                tileValue = spriteRenderer.sprite.name;
                break;
            case "broken_tiles":
                spriteRenderer.sprite = windowModel.getWindowBroken(index);
                tileValue = spriteRenderer.sprite.name;
                break;
            case "chromatic":
                spriteRenderer.sprite = windowModel.getWindowChromatic(index);
                tileValue = spriteRenderer.sprite.name;
                break;
            case "fractal_drops":
                spriteRenderer.sprite = windowModel.getWindowFractal(index);
                tileValue = spriteRenderer.sprite.name;
                break;
            case "inudstria":
                spriteRenderer.sprite = windowModel.getWindowIndustria(index);
                tileValue = spriteRenderer.sprite.name;
                break;
            default:
                spriteRenderer.sprite = windowModel.getWindowChromatic(index);
                tileValue = spriteRenderer.sprite.name;
                break;
        }
        //spriteRenderer.sprite = windowModel.getWindow(index);
        //tileValue = spriteRenderer.sprite.name;
    }

    public void moveTiles()
    {

    }

}
