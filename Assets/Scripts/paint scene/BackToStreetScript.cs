using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToStreetScript : MonoBehaviour {
	public void LoadScene(string Menu) {
		SceneManager.LoadScene("StreetScene");
	}
}
