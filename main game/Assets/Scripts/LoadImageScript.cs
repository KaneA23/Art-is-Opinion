using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class LoadImageScript : MonoBehaviour
{
    Texture2D myTexture;


    // Start is called before the first frame update
    void Start()
    {
        //string filePath = Application.dataPath + "/Resources/Images/SavedImage.png";
        //byte[] imageData = File.ReadAllBytes(filePath);

        //myTexture = new Texture2D(1, 1);
        //myTexture.LoadImage(/*imageData*/ConvertToPng(filePath));

        //GetComponent<Renderer>().material.mainTexture = myTexture;

        myTexture = Resources.Load("Images/SavedImage") as Texture2D;

        GameObject rawImage = GameObject.Find("RawImage");
        rawImage.GetComponent<RawImage>().texture = myTexture;
    }


    // Update is called once per frame
    void Update()
    {

    }


    //public static byte[] ConvertToPng(string a_Path)
    //{
    //    byte[] imageData = System.IO.File.ReadAllBytes(a_Path);
    //    var tex = new Texture2D(1, 1, TextureFormat.RGB24, false);
    //    tex.LoadImage(imageData);
    //    tex.Apply();
    //    byte[] imageBytes = tex.EncodeToPNG();
    //    Destroy(tex);

    //    return imageBytes;
    //}
}
