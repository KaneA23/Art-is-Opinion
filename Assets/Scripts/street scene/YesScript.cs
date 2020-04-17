using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Tobii.Gaming;

public class YesScript : MonoBehaviour {

    //MattP
    public Button yesButton;
    public Button noButton;
    Vector3 yesPos;
    Vector3 noPos;
    Rect yesRect;
    Rect noRect;

    float yesXMin;
    float yesXMax;
    float yesYMin;
    float yesYMax;
    float noXMin;
    float noXMax;
    float noYMin;
    float noYMax;

    float timeBeforeClick;
    float timeBetweenClicks = 1;
    Vector2 filteredPoint;

    private void Update()
    {
        timeBetweenClicks -= Time.deltaTime;

        yesPos = yesButton.transform.position;
        noPos = noButton.transform.position;
        yesRect = yesButton.GetComponent<RectTransform>().rect;
        noRect = noButton.GetComponent<RectTransform>().rect;;

        yesXMin = yesRect.xMin;
        yesXMax = yesRect.xMax;
        yesYMin = yesRect.yMin;
        yesYMax = yesRect.yMax;

        noXMin = noRect.xMin;
        noXMax = noRect.xMax;
        noYMin = noRect.yMin;
        noYMax = noRect.yMax;

        Vector2 gazePoint = TobiiAPI.GetGazePoint().Screen;  // Fetches the current co-ordinates on the screen that the player is looking at via the eye-tracker           
        filteredPoint = Vector2.Lerp(filteredPoint, gazePoint, 0.5f);

        if ((yesPos.x + yesXMin) < filteredPoint.x && filteredPoint.x < (yesPos.x + yesXMax) && (yesPos.y + yesYMin) < filteredPoint.y && filteredPoint.y < (yesPos.y + yesYMax) && timeBetweenClicks <= 0)
        {
            YesButton();
            timeBeforeClick = timeBetweenClicks;
        }

        if ((noPos.x + noXMin) < filteredPoint.x && filteredPoint.x < (noPos.x + noXMax) && (noPos.y + noYMin) < filteredPoint.y && filteredPoint.y < (noPos.y + noYMax) && timeBetweenClicks <= 0)
        {
            NoButton();
            timeBeforeClick = timeBetweenClicks;
        }
	}
    public void NoButton()
    {
        FindObjectOfType<DialogueTrigger>().No();
    }

	public void YesButton()
    {
		FindObjectOfType<DialogueTrigger>().Yes();
	}
}
