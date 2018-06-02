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

    public void setFront(int index)
    {
        spriteRenderer.sprite = windowModel.getWindow(index);
        tileValue = spriteRenderer.sprite.name;
    }

    public void moveTiles()
    {

    }

}
