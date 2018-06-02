using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour {

    public string diceValue;
    public string diceColorName;
    private bool selected;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D diceCollider;

    private DiceModel diceModel;
    private GameObject diceModelGameObject;

    private void Awake()
    {
        diceModelGameObject = GameObject.Find("DiceModel");
        diceModel = diceModelGameObject.GetComponent<DiceModel>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        diceCollider = GetComponent<BoxCollider2D>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public string getDiceValue()
    {
        return this.diceValue;
    }

    public void setDiceValue(string value)
    {
        this.diceValue = value;
    }

    public string getDiceColorName()
    {
        return this.diceColorName;
    }

    public void setDiceColorName(string name)
    {
        this.diceColorName = name;
    }

    public bool isSelected()
    {
        return this.selected;
    }

    public void setSelected(bool selected)
    {
        this.selected = selected;
    }

    public Bounds getBounds()
    {
        return this.diceCollider.bounds;
    }

    public DiceModel getDiceModel()
    {
        return this.diceModel;
    }

    public void setFront(string diceColor,int index)
    {
        switch(diceColor)
        {
            case "red":
                spriteRenderer.sprite = diceModel.getRed(index);
                diceValue = spriteRenderer.sprite.name;
                diceColorName = diceColor;
                break;
            case "blue":
                spriteRenderer.sprite = diceModel.getBlue(index);
                diceValue = spriteRenderer.sprite.name;
                diceColorName = diceColor;
                break;
            case "purple":
                spriteRenderer.sprite = diceModel.getPurple(index);
                diceValue = spriteRenderer.sprite.name;
                diceColorName = diceColor;
                break;
            case "yellow":
                spriteRenderer.sprite = diceModel.getYellow(index);
                diceValue = spriteRenderer.sprite.name;
                diceColorName = diceColor;
                break;
            case "green":
                spriteRenderer.sprite = diceModel.getGreen(index);
                diceValue = spriteRenderer.sprite.name;
                diceColorName = diceColor;
                break;
            default:
                break;
        }
    }
}
