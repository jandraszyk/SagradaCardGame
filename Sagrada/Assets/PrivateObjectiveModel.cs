using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrivateObjectiveModel : MonoBehaviour
{
    public Sprite[] privateFronts;
    public string[] methodToCalculate;

    public Sprite getPrivateFronts(int index)
    {
        return privateFronts[index];
    }
    public string getMethodToCalculate(int index)
    {
        return methodToCalculate[index];
    }

}
