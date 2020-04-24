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
using UnityEngine.Networking;
using System.IO;


public class LoadImageScript : MonoBehaviour
{
    public int numOfPNGs = 0;   // Used to load the last PNG in the folder (loads "SavedImage" + numOfPNGs)

    //Texture2D myTexture;

    public string url;

    // Start is called before the first frame update
    IEnumerator Start()
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


        string individualFilePath = "file://" + Application.dataPath + "/Resources/Images/SavedImage" + numOfPNGs + ".png";
        Debug.Log(individualFilePath);
        Texture loadedTexture;

        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(individualFilePath))
        {
            yield return uwr.SendWebRequest();

            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log("Error loading texture.");
                Debug.Log(uwr.error);
                loadedTexture = null; //Maybe should be a placeholder texture here
            }
            else
            {
                loadedTexture = DownloadHandlerTexture.GetContent(uwr);
                Debug.Log("Succesfully loaded texture!");
            }

        }

        /*         WWW www = new WWW(url);
                while (!www.isDone)
                    yield return null;
                //GameObject image = GameObject.Find("RawImage");
                //image.GetComponent<RawImage>().texture = www.texture; */

        //Renderer renderer = GetComponent<Renderer>();
        //renderer.material.mainTexture = loadedTexture;

        //Debug.Log(url);

        RawImage image = GetComponent<RawImage>();
        image.texture = loadedTexture;

        //string imageToLoad = ("SavedImage" + numOfPNGs);  // Stores the name of the folder to be opened as a string

        //LoadImage(imageToLoad);
    }


    void LoadImage(string a_ImageToLoad)
    {
        //myTexture = Resources.Load("Images/" + a_ImageToLoad) as Texture2D;   // Finds the file that contains the specified name

        //// Changes the texture of the image GameObject to be the SavedImage
        //GameObject rawImage = GameObject.Find("RawImage");
        //rawImage.GetComponent<RawImage>().texture = myTexture;
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
