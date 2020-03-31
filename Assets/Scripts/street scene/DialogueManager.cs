using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
	public float textWait;

    public Animator animator;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
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
	}
	// coral

	IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";

		foreach (char letter in sentence.ToCharArray()) {
			Debug.Log("htthjtjuk");

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
