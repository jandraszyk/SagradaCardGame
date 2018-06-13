using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicObjective : MonoBehaviour {


    private SpriteRenderer spriteRenderer;
    private BoxCollider2D toolCollider;
    public bool isShowing = false;

    private GameObject publicObjectiveModelObject;
    private PublicObjectiveModel publicObjectiveModel;

    private void Awake()
    {
        publicObjectiveModelObject = GameObject.Find("PublicObjectiveModel");
        publicObjectiveModel = publicObjectiveModelObject.GetComponent<PublicObjectiveModel>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        toolCollider = GetComponent<BoxCollider2D>();
        toolCollider.size = new Vector2();
    }


    public void setFront(int index)
    {
        spriteRenderer.sprite = publicObjectiveModel.getPublicFront(index);
    }
}
