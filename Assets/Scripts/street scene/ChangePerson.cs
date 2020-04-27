using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePerson : MonoBehaviour {
	public static ChangePerson personInstance;

	public List<Sprite> images;
	public Sprite transparent;
	int numImages;
	public Image myImageComponent;
	public int rand;
	public float changewait;

	// Added by Kane
	private void Awake() {
		personInstance = this;
		DontDestroyOnLoad(gameObject);
	}

	// Start is called before the first frame update
	void Start() {
		myImageComponent = GetComponent<Image>();
		ChangeImage();
	}

	public void ChangeImage() {
		rand = Random.Range(0, images.Count);
		myImageComponent.sprite = images[rand];
	}

	public void Drawclicked() {
		myImageComponent.sprite = transparent;
	}
}