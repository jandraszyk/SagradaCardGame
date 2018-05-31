using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeDifficulty : MonoBehaviour {

    static public int currentDifficulty = 1;
    private int maxLevel = 5;
    private int minLevel = 1;
    public Text lvlDifficulty;

	public void changeDifficulty(string arrow)
    {
        if(arrow.Equals("left"))
        {
            if( currentDifficulty > minLevel)
            {
                currentDifficulty--;
                lvlDifficulty.text = currentDifficulty.ToString();
            }
        }
        else if (arrow.Equals("right"))
        {
            if(currentDifficulty < maxLevel)
            {
                currentDifficulty++;
                lvlDifficulty.text = currentDifficulty.ToString();
            }
        }
    }
}
