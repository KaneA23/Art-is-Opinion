using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tobii.Gaming;

public class GazeMenuUI : MonoBehaviour
{
    public Button PlayButton;
    public Button DrawButton;
    public Button GalleryButton;
    public Button ExitButton;
    public Button MenuButton;
    public Camera mainCam;
    public GameObject dialogueManager;
    Vector3 PlayPos;
    Vector3 DrawPos;
    Vector3 GalleryPos;
    Vector3 ExitPos;
    Vector3 MenuPos;
    Rect PlayRect;
    Rect DrawRect;
    Rect GalleryRect;
    Rect ExitRect;
    Rect MenuRect;
    float PlayXMin;
    float PlayXMax;
    float PlayYMin;
    float PlayYMax;
    float DrawXMin;
    float DrawXMax;
    float DrawYMin;
    float DrawYMax;

    float GalleryXMin;
    float GalleryXMax;
    float GalleryYMin;
    float GalleryYMax;

    float ExitXMin;
    float ExitXMax;
    float ExitYMin;
    float ExitYMax;

    float MenuXMin;
    float MenuXMax;
    float MenuYMin;
    float MenuYMax;

    float timeBeforeClick;
    float timeBetweenClicks = 1;

    Vector2 filteredPoint;

    // Start is called before the first frame update
    void Start()
    {
        timeBeforeClick = timeBetweenClicks;
    }

    private void Update()
    {
        timeBetweenClicks -= Time.deltaTime;

        PlayPos = PlayButton.transform.position;
        DrawPos = DrawButton.transform.position;
        PlayRect = PlayButton.GetComponent<RectTransform>().rect;
        DrawRect = DrawButton.GetComponent<RectTransform>().rect;
        GalleryRect = GalleryButton.GetComponent<RectTransform>().rect;
        ExitRect = ExitButton.GetComponent<RectTransform>().rect;
        MenuRect = MenuButton.GetComponent<RectTransform>().rect;

        PlayXMin = PlayRect.xMin;
        PlayXMax = PlayRect.xMax;
        PlayYMin = PlayRect.yMin;
        PlayYMax = PlayRect.yMax;

        DrawXMin = DrawRect.xMin;
        DrawXMax = DrawRect.xMax;
        DrawYMin = DrawRect.yMin;
        DrawYMax = DrawRect.yMax;

        GalleryXMin = GalleryRect.xMin;
        GalleryXMax = GalleryRect.xMax;
        GalleryYMin = GalleryRect.yMin;
        GalleryYMax = GalleryRect.yMax;

        ExitXMin = ExitRect.xMin;
        ExitXMax = ExitRect.xMax;
        ExitYMin = ExitRect.yMin;
        ExitYMax = ExitRect.yMax;

        MenuXMin = MenuRect.xMin;
        MenuXMax = MenuRect.xMax;
        MenuYMin = MenuRect.yMin;
        MenuYMax = MenuRect.yMax;


        Vector2 gazePoint = TobiiAPI.GetGazePoint().Screen;  // Fetches the current co-ordinates on the screen that the player is looking at via the eye-tracker           
        filteredPoint = Vector2.Lerp(filteredPoint, gazePoint, 0.5f);

        if ((PlayPos.x + PlayXMin) < filteredPoint.x && filteredPoint.x < (PlayPos.x + PlayXMax) && (PlayPos.y + PlayYMin) < filteredPoint.y && filteredPoint.y < (PlayPos.y + PlayYMax) && timeBetweenClicks <= 0)
        {
            PlayButton.GetComponent<PlayButtonScript>().ButtonClicked();
            dialogueManager.GetComponent<DialogueTrigger>().StartDialog();
            timeBeforeClick = timeBetweenClicks;
        }

        if ((DrawPos.x + DrawXMin) < filteredPoint.x && filteredPoint.x < (DrawPos.x + DrawXMax) && (DrawPos.y + DrawYMin) < filteredPoint.y && filteredPoint.y < (DrawPos.y + DrawYMax) && timeBetweenClicks <= 0)
        {
            timeBeforeClick = timeBetweenClicks;
        }

        if ((GalleryPos.x + GalleryXMin) < filteredPoint.x && filteredPoint.x < (GalleryPos.x + GalleryXMax) && (GalleryPos.y + GalleryYMin) < filteredPoint.y && filteredPoint.y < (GalleryPos.y + GalleryYMax) && timeBetweenClicks <= 0)
        {
            mainCam.GetComponent<CameraScript>().Gallery();
            timeBeforeClick = timeBetweenClicks;
        }

        if ((ExitPos.x + ExitXMin) < filteredPoint.x && filteredPoint.x < (ExitPos.x + ExitXMax) && (ExitPos.y + ExitYMin) < filteredPoint.y && filteredPoint.y < (ExitPos.y + ExitYMax) && timeBetweenClicks <= 0)
        {
            timeBeforeClick = timeBetweenClicks;
        }

        if ((MenuPos.x + MenuXMin) < filteredPoint.x && filteredPoint.x < (MenuPos.x + MenuXMax) && (MenuPos.y + MenuYMin) < filteredPoint.y && filteredPoint.y < (MenuPos.y + MenuYMax) && timeBetweenClicks <= 0)
        {
            mainCam.GetComponent<CameraScript>().Menu();
            timeBeforeClick = timeBetweenClicks;
        }

    }

}

