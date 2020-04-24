/// <summary>
/// Name:           SaveImageScript.css
/// Purpose:        To save an image to a folder as .PNG
/// Author:         Kane Adams
/// Date Created:   06/02/2020
/// </summary>

// Namespaces
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SaveImageScript : MonoBehaviour
{
    int numOfPNGs = 1;  // Used to save the item as last PNG in folder (to allow multiple images)
    string filePath;    // Where the image is going to be saved

    public RenderTexture SaveTexture;   // The texture (connected to camera) of the image to save

    public Texture2D texture2D;

    //public void Awake()
    //{
    //    DontDestroyOnLoad(gameObject);
    //}


    // Start is called before the first frame update
    public void Start()
    {
        filePath = Application.dataPath + "/Resources/Images";  // Where the image is to be saved

        // Stores the info on what is saved in the filePath to an array
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
    }


    /// <summary>
    /// Calls the co-routine that saves the image that has been drawn (when save button is clicked)
    /// </summary>
    public void Save()
    {
        StartCoroutine(CoSave());
    }


    /// <summary>
    /// Once the current frame ends, the SaveCamera's image is saved to Assets folder
    /// </summary>
    /// <returns>Waits until the end of the rendered frame</returns>
    private IEnumerator CoSave()
    {
        yield return new WaitForEndOfFrame();

        DirectoryInfo folder = Directory.CreateDirectory(filePath); // Creates the folder that stores the image

        RenderTexture.active = SaveTexture;

        texture2D = new Texture2D(SaveTexture.width, SaveTexture.height);
        texture2D.ReadPixels(new Rect(0, 0, SaveTexture.width, SaveTexture.height), 0, 0);
        texture2D.Apply();

        byte[] saveData = texture2D.EncodeToPNG();  // Turns the image seen in the SaveCamera to a PNG

        File.WriteAllBytes(filePath + "/SavedImage" + numOfPNGs + ".png", saveData);  // Saves the .PNG to the desired directory

        Debug.Log(filePath + "/SavedImage" + numOfPNGs + ".png");

        //using (var fileStream = new FileStream(filePath + "/SavedImage" + numOfPNGs + ".png", FileMode.Open, FileAccess.Write))
        //{
        //    Debug.Log("I am here");

        //    StreamWriter writer = new StreamWriter(fileStream);
        //    writer.Write("I'm saving this");
        //    writer.Close();
        //}


        SceneManager.LoadScene("PracticeScene2", LoadSceneMode.Single); // Loads the second scene to view image
    }
}
