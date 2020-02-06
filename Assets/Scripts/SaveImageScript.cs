using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveImageScript : MonoBehaviour
{
    public RenderTexture SaveTexture;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {

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
        Debug.Log(Application.dataPath + "/SavedImage/savedImage.png");

        var folder = Directory.CreateDirectory(Application.dataPath + "/SavedImage");   // Creates the folder that stores the image

        RenderTexture.active = SaveTexture;

        var texture2D = new Texture2D(SaveTexture.width, SaveTexture.height);
        texture2D.ReadPixels(new Rect(0, 0, SaveTexture.width, SaveTexture.height), 0, 0);
        texture2D.Apply();

        var saveData = texture2D.EncodeToPNG(); // Turns the image seen in the SaveCamera to a PNG

        File.WriteAllBytes(Application.dataPath + "/SavedImage/savedImage.png", saveData);  // Saves the .PNG to the desired directory
    }
}
