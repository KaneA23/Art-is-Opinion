using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class LoadImageScript : MonoBehaviour
{
    Texture2D myTexture;


    // Start is called before the first frame update
    void Start()
    {
        string filePath = Application.dataPath + "/Resources/Images/SavedImage.png";
        byte[] imageData = File.ReadAllBytes(filePath);

        myTexture = new Texture2D(2, 2);
        myTexture.LoadImage(imageData);

        GetComponent<Renderer>().material.mainTexture = myTexture;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
