using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolModel : MonoBehaviour
{

    public Sprite[] toolFronts;
    public string[] colorValues;
    
    public Sprite getToolFront(int index)
    {
        return toolFronts[index];
    }

    public string getColorValue(int index)
    {
        return colorValues[index];
    }

}
