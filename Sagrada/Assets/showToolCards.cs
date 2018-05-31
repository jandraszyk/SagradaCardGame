using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showToolCards : MonoBehaviour
{
    public  List<Texture> textures;
    // Use this for initialization
    void Start()
    {
        Texture[] allImages = Resources.LoadAll<Texture>("Tools");
        foreach (int index in GenerateTools.indexes_)
        {
            if (index != 12)
            {
                textures.Add(allImages[index]);
            }
        }

    }
    void OnGUI()
    {
        int i = 0;
        foreach (Texture image in textures)
        {
            GUI.DrawTexture(new Rect(160, 20, 500, 500), image);
            i++;
        }
    }

    public void draft()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
