/// <summary>
/// Name:           LoadImageScript.css
/// Purpose:        To load a .PNG image from resource folder in assets into a scene
/// Author:         Kane Adams
/// Date Created:   22/03/2020
/// </summary>

// Namespaces
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class LoadImageScript : MonoBehaviour
{
    public int numOfPNGs = 0;   // Used to load the last PNG in the folder (loads "SavedImage" + numOfPNGs)

    Texture2D myTexture;


    // Start is called before the first frame update
    void Start()
    {
        string filePath = Application.dataPath + "/Resources/Images";   // Where the images are saved

        // Stores the info on what is saved in the filepath to an array
        DirectoryInfo info = new DirectoryInfo(filePath);
        FileInfo[] fileInfo = info.GetFiles();

        // Goes through each file within the array, if the file is a .png, numOfPNGs increments
        foreach (FileInfo file in fileInfo)
        {
            Debug.Log("all folders:" + file);
            if (file.Extension == ".png")
            {
                numOfPNGs++;
                Debug.Log(file);
            }
        }

        string imageToLoad = ("SavedImage" + numOfPNGs);  // Stores the name of the folder to be opened as a string
        Debug.Log(imageToLoad);

        LoadImage(imageToLoad);
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


    void LoadImage(string a_ImageToLoad)
    {
        myTexture = Resources.Load("Images/" + a_ImageToLoad) as Texture2D;   // Finds the file that contains the specified name

        // Changes the texture of the image GameObject to be the SavedImage
        GameObject rawImage = GameObject.Find("RawImage");
        rawImage.GetComponent<RawImage>().texture = myTexture;
        Debug.Log("Loaded Image");
    }
}
