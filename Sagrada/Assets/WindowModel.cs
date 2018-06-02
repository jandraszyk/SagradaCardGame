using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowModel : MonoBehaviour {

    public Sprite[] windowsAurora;
    public Sprite[] windowsBellesguard;
    public Sprite[] windowsBroken;
    public Sprite[] windowsChromatic;
    public Sprite[] windowsFractal;
    public Sprite[] windowsIndustria;

    public Sprite getWindowAurora(int index)
    {
        return windowsAurora[index];
    }
    public Sprite getWindowIndustria(int index)
    {
        return windowsIndustria[index];
    }
    public Sprite getWindowBroken(int index)
    {
        return windowsBroken[index];
    }
    public Sprite getWindowBellesguard(int index)
    {
        return windowsBellesguard[index];
    }
    public Sprite getWindowChromatic(int index)
    {
        return windowsChromatic[index];
    }
    public Sprite getWindowFractal(int index)
    {
        return windowsFractal[index];
    }
}
