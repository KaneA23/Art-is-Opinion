using UnityEngine;
using UnityEngine.SceneManagement;

public class YesScript : MonoBehaviour {


	public void NoButton() {
		FindObjectOfType<DialogueTrigger>().No();
	}

	public void YesButton() {
		FindObjectOfType<DialogueTrigger>().Yes();
	}
}
