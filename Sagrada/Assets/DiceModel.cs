using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceModel : MonoBehaviour {

    public Sprite[] redDice;
    public Sprite[] blueDice;
    public Sprite[] greenDice;
    public Sprite[] yellowDice;
    public Sprite[] purpleDice;

    public Sprite getRed(int index)
    {
        return redDice[index];
    }
    public Sprite getGreen(int index)
    {
        return greenDice[index];
    }
    public Sprite getBlue(int index)
    {
        return blueDice[index];
    }
    public Sprite getYellow(int index)
    {
        return yellowDice[index];
    }
    public Sprite getPurple(int index)
    {
        return purpleDice[index];
    }

}
