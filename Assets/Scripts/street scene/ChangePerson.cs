using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePerson : MonoBehaviour
{
    public static ChangePerson personInstance;

    public Sprite[] images;
    int numImages;
    public Image myImageComponent;
    public int rand;


    /// <summary>
    /// Allows the script to be accessable in other scenes.
    /// To allow the character to be the same in both scenes.
    /// Added by Kane
    /// </summary>
    private void Awake()
    {
        personInstance = this;

        DontDestroyOnLoad(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        myImageComponent = GetComponent<Image>();
    }

    public void ChangeImage()
    {
        numImages = images.Length;
        rand = Random.Range(0, numImages - 1);
        myImageComponent.sprite = images[rand];
    }
}
