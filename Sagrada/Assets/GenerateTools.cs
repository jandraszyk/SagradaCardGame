using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class GenerateTools : MonoBehaviour {
    public static int[] indexes_ = { 12, 12, 12, 12, 12 };


    // Use this for initialization
    void Start ()
    {
    }

    public void generate()
    {
        int amountOfToolCards = 6 - ChangeDifficulty.currentDifficulty;
        System.Random random = new System.Random();
        for (int i = 0; i < amountOfToolCards; i++) {
            indexes_[i] = random.Next(0, 12);
        }

    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
