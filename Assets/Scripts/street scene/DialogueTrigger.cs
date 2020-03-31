using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
	float timeWait;

	private void Start() {
		timeWait = Random.Range(2, 4);
	}

	private void Update() {
		if (timeWait > 0) {
			timeWait -= Time.deltaTime;
			if (timeWait <= 0) {
				TriggerDialogue();
			}
		}
	}

	public void No() {
		FindObjectOfType<DialogueManager>().EndDialogue();

		timeWait = Random.Range(2, 4);
	}

	public void Yes() {
		SceneManager.LoadScene("PaintScene");
	}

	public void TriggerDialogue ()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
