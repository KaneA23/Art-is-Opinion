using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePerson : MonoBehaviour
{
    public Sprite[] images;
    int numImages;
    Image myImageComponent;

    // Start is called before the first frame update
    void Start()
    {
        myImageComponent = GetComponent<Image>();
    }

    public void ChangeImage()
    {
        numImages = images.Length;
        int rand = Random.Range(0, numImages - 1);
        myImageComponent.sprite = images[rand];
    }
}
