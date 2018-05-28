using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowModel : MonoBehaviour {

    public Sprite[] windows;
    public Sprite getWindow(int index)
    {
        return windows[index];
    }
}
