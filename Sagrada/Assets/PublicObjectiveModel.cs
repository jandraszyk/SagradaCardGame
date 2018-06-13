using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicObjectiveModel : MonoBehaviour
{
    public Sprite[] publicFronts;

    public Sprite getPublicFront(int index)
    {
        return publicFronts[index];
    }
}
