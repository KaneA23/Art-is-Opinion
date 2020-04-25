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

    private Queue<string> sentences;

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
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        startPos = dialogueBox.transform.position;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        Debug.Log("Starting conversation with " + dialogue.name);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
        //    EndDialogue();
            return;
        }
		// coral
		textWait = 1;
		// coral       
    }

	// coral
	private void Update() {
		if (textWait > 0) {
			textWait -= Time.deltaTime;
			if (textWait <= 0) {
				string sentence = sentences.Dequeue();
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

        if (dialogueBox.transform.position.y == startPos.y)
        {
            image.GetComponent<ChangePerson>().ChangeImage();
        }
    }
	// coral

	IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";

		foreach (char letter in sentence.ToCharArray()) {

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
