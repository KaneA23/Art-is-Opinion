/// <summary>
/// Name:           ChangePersonPaintScript.cs
/// Purpose:        Changes the character in the Paint scene to match the person in the street scene
/// Author:         Kane Adams
/// Date Created:   25/04/2020
/// </summary>


// Namespaces
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangePersonPaintScript : MonoBehaviour
{
	public SpriteRenderer personImage;  // The player image that changes


	// Start is called before the first frame update
	void Start() {
		//personImage = GetComponent<Image>();
		personImage.sprite = ChangePerson.personInstance.myImageComponent.sprite;
	}
}
