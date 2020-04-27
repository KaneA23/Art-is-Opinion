using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tobii.Gaming;

public class DialogueManager : MonoBehaviour
{
	public Text nameText;
	public Text dialogueText;
	public float textWait;

	public Animator animator;

	private Queue<string> speech;

	//MattP
	public Button continueButton;
	Vector3 continuePos;
	Rect continueRect;

	float continueXMin;
	float continueXMax;
	float continueYMin;
	float continueYMax;

	float timeBeforeClick;
	float timeBetweenClicks = 1;
	Vector2 filteredPoint;

	public GameObject dialogueBox;
	public GameObject image;
	Vector3 startPos;
	public ChangePerson changePerson;

	public List<Sprite> images;
	int numImages;
	public Image myImageComponent;
	int rand;
	public float changewait;
	public static DialogueManager personInstance;

	public List<string> dogNames;
	public List<string> femaleFirstNames;
	public List<string> maleFirstNames;
	public List<string> surnames;
	public List<string> sentenses;
	int randomNameNumber;
	int randomSurnameNumber;
	int randomSentenceNumber;
	string randomName;
	string randomSurname;
	string randomSentence;


	bool down = false;


	///// <summary>
	///// Allows the script to be accessable in other scenes.
	///// To allow the character to be the same in both scenes.
	///// Added by Kane
	///// </summary>
	//private void Awake() {
	//	personInstance = this;

	//	DontDestroyOnLoad(gameObject);
	//}

	// Start is called before the first frame update

	void Start()
	{
		speech = new Queue<string>();
		startPos = dialogueBox.transform.position;


		//myImageComponent = GetComponent<Image>();
		//ChangeImage();
	}

	//public void ChangeImage() {
	//	rand = Random.Range(0, images.Count);
	//	myImageComponent.sprite = images[rand];
	//	Debug.Log(rand);
	//}

	public void StartDialogue(Dialogue dialogue)
	{
		animator.SetBool("IsOpen", true);
		speech.Clear();
		dialogueText.text = " ";
		nameText.text = " ";

		randomSentenceNumber = Random.Range(0, sentenses.Count);
		randomSentence = sentenses[randomSentenceNumber];
		//dialogue.request = randomSentence;

		if (changePerson.rand == 0)
		{
			randomNameNumber = Random.Range(0, dogNames.Count);
			randomName = dogNames[randomNameNumber];
			dialogue.name = randomName;
			//dialogue.request = "Woof woof ruff";
			speech.Enqueue("Woof Woof ruff");

		}
		else if (changePerson.rand == 1)
		{
			dialogue.name = "Polly Collins";
		}
		else if (changePerson.rand == 2)
		{
			dialogue.name = "Gretta McGee";
		}
		else if (changePerson.rand == 6)
		{
			dialogue.name = "Kane Adams";
		}
		else if (changePerson.rand == 7)
		{
			dialogue.name = "Jade West";
		}
		else if (changePerson.rand == 8)
		{
			dialogue.name = "Yung Gregg";
		}
		else if (changePerson.rand == 9 || changePerson.rand == 10)
		{
			randomNameNumber = Random.Range(0, surnames.Count);
			randomSurname = surnames[randomSurnameNumber];
			dialogue.name = "Mr. " + randomSurname;
		}
		else if (changePerson.rand == 13)
		{
			randomNameNumber = Random.Range(0, surnames.Count);
			randomSurname = surnames[randomSurnameNumber];
			dialogue.name = "Ms. " + randomSurname;

		}
		else if (changePerson.rand == 3 || changePerson.rand == 5 || changePerson.rand == 12)
		{
			randomNameNumber = Random.Range(0, femaleFirstNames.Count);
			randomSurnameNumber = Random.Range(0, surnames.Count);
			randomName = femaleFirstNames[randomNameNumber];
			randomSurname = surnames[randomSurnameNumber];
			dialogue.name = randomName + " " + randomSurname;
		}
		else if (changePerson.rand == 4 || changePerson.rand == 11 || changePerson.rand <= 14)
		{
			randomNameNumber = Random.Range(0, maleFirstNames.Count);
			randomNameNumber = Random.Range(0, surnames.Count);
			randomName = maleFirstNames[randomNameNumber];
			randomSurname = surnames[randomSurnameNumber];
			dialogue.name = randomName + " " + randomSurname;

		}


		nameText.text = dialogue.name;


		if (changePerson.rand != 0)
		{
			speech.Enqueue(randomSentence);
		}



		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		if (speech.Count == 0)
		{
			//    EndDialogue();
			return;
		}
		// coral
		textWait = 1;
		// coral       
	}

	// coral
	private void Update()
	{
		if (textWait > 0)
		{
			textWait -= Time.deltaTime;
			if (textWait <= 0)
			{
				string sentence = speech.Dequeue();
				StopAllCoroutines();
				StartCoroutine(TypeSentence(sentence));
				Debug.Log(sentence);
			}
		}

		//MattP
		timeBetweenClicks -= Time.deltaTime;

		continuePos = continueButton.transform.position;
		continueRect = continueButton.GetComponent<RectTransform>().rect;

		continueXMin = continueRect.xMin;
		continueXMax = continueRect.xMax;
		continueYMin = continueRect.yMin;
		continueYMax = continueRect.yMax;

		Vector2 gazePoint = TobiiAPI.GetGazePoint().Screen;  // Fetches the current co-ordinates on the screen that the player is looking at via the eye-tracker           
		filteredPoint = Vector2.Lerp(filteredPoint, gazePoint, 0.5f);

		if ((continuePos.x + continueXMin) < filteredPoint.x && filteredPoint.x < (continuePos.x + continueXMax) && (continuePos.y + continueYMin) < filteredPoint.y && filteredPoint.y < (continuePos.y + continueYMax) && timeBetweenClicks <= 0)
		{
			DisplayNextSentence();
			timeBeforeClick = timeBetweenClicks;
		}

		// coral
		if (dialogueBox.transform.position.y == startPos.y && down == false)
		{
			down = true;
			Debug.Log("ifykyflofyu");

			//   image.GetComponent<ChangePerson>().ChangeImage();
			changePerson.ChangeImage();

		}
		else if (dialogueBox.transform.position.y != startPos.y && down == true)
		{
			down = false;
		}
	}


	IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";

		foreach (char letter in sentence.ToCharArray())
		{

			dialogueText.text += letter;
			yield return null;
		}

	}

	public void EndDialogue()
	{
		animator.SetBool("IsOpen", false);
		Debug.Log("End of conversation");
	}
}
