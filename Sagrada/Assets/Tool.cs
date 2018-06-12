using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour {

    private string toolColorValue;
    private bool wasBought = false;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D toolCollider;

    private GameObject toolModelObject;
    private ToolModel toolModel;

    private void Awake()
    {
        toolModelObject = GameObject.Find("ToolModel");
        toolModel = toolModelObject.GetComponent<ToolModel>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        toolCollider = GetComponent<BoxCollider2D>();
        toolCollider.size = new Vector2();
    }


    public void setFront(int index)
    {
        spriteRenderer.sprite = toolModel.getToolFront(index);
        toolColorValue = toolModel.getColorValue(index);
    }

    public string getcolorValue()
    {
        return toolColorValue;
    }
}
