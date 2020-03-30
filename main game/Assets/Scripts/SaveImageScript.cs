/// <summary>
/// Name:       SaveImageScript.css
/// Purpose:    To save an image to a folder
/// Author:     Kane Adams
/// </summary>

// Namespaces
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SaveImageScript : MonoBehaviour
{
    public RenderTexture SaveTexture;
    string filePath;
    int numOfPNGs = 0;


    public void Start()
    {
        filePath = Application.dataPath + "/Resources/Images";

        DirectoryInfo info = new DirectoryInfo(filePath);
        FileInfo[] fileInfo = info.GetFiles();

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
    /// <returns>Waits until the endd of the rendered frame</returns>
    private IEnumerator CoSave()
    {
        yield return new WaitForEndOfFrame();
        
        var folder = Directory.CreateDirectory(filePath);   // Creates the folder that stores the image

        RenderTexture.active = SaveTexture;

        var texture2D = new Texture2D(SaveTexture.width, SaveTexture.height);
        texture2D.ReadPixels(new Rect(0, 0, SaveTexture.width, SaveTexture.height), 0, 0);
        texture2D.Apply();

        var saveData = texture2D.EncodeToPNG(); // Turns the image seen in the SaveCamera to a PNG

        File.WriteAllBytes(filePath + "/SavedImage"+numOfPNGs+".png", saveData);  // Saves the .PNG to the desired directory
        
        Debug.Log(filePath + "/SavedImage.png");


        SceneManager.LoadScene("PracticeScene2", LoadSceneMode.Single);
    }
}
