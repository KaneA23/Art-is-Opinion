/// <summary>
/// Name:           LoadImageScript.css
/// Purpose:        To load a .PNG image from resource folder in assets into a scene
/// Author:         Kane Adams
/// Date Created:   22/03/2020
/// </summary>

// Namespaces
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class LoadImageScript : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        int numOfPNGs = 0;  // Used to load the last PNG in the folder (loads "SavedImage" + numOfPNGs)
        string filePath = Application.dataPath + "/Resources/Images";   // Where the images are saved

        // Stores the info on what is saved in the filePath to an array
        DirectoryInfo info = new DirectoryInfo(filePath);
        FileInfo[] fileInfo = info.GetFiles();

        // Goes through each file within he array, if the file extension is a '.png', numOfPNGs increments
        foreach (FileInfo file in fileInfo)
        {
            if (file.Extension == ".png")
            {
                numOfPNGs++;
            }
        }

        string individualFilePath = "file://" + Application.dataPath + "/Resources/Images/SavedImage" + numOfPNGs + ".png";
        Texture loadedTexture;

        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(individualFilePath))
        {
            yield return uwr.SendWebRequest();

            if (uwr.isNetworkError || uwr.isHttpError)
            {
                loadedTexture = null;

                Debug.Log("Error loading texture.");
                Debug.Log(uwr.error);
            }
            else
            {
                loadedTexture = DownloadHandlerTexture.GetContent(uwr);

                Debug.Log("Succesfully loaded texture!");
            }

            RawImage image = GetComponent<RawImage>();
            //image.texture = loadedTexture;  // My code
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
