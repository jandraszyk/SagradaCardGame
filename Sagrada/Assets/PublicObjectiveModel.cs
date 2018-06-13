using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicObjectiveModel : MonoBehaviour
{
    public Sprite[] publicFronts;
    public int[] methodToCalculate;

    public Sprite getPublicFront(int index)
    {
        return publicFronts[index];
    }
    public int getMethodToCalculate(int index)
    {
        return methodToCalculate[index];
    }
}
