using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrivateObjectiveModel : MonoBehaviour
{
    public Sprite[] privateFronts;
    
    public Sprite getPrivateFronts(int index)
    {
        return privateFronts[index];
    }
    
}
