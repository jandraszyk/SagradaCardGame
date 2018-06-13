using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrivateObjective : MonoBehaviour {
    

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D toolCollider;
    public bool isShowing = false;
    private string method;

    private GameObject privateObjectiveModelObject;
    private PrivateObjectiveModel privateObjectiveModel;

    private void Awake()
    {
        privateObjectiveModelObject = GameObject.Find("PrivateObjectiveModel");
        privateObjectiveModel = privateObjectiveModelObject.GetComponent<PrivateObjectiveModel>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        toolCollider = GetComponent<BoxCollider2D>();
        toolCollider.size = new Vector2();
    }


    public void setFront(int index)
    {
        spriteRenderer.sprite = privateObjectiveModel.getPrivateFronts(index);
        method = privateObjectiveModel.getMethodToCalculate(index);
    }

    public string getMethod()
    {
        return method;
    }
}
