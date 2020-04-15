using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tobii.Gaming;


namespace unitycoder_MobilePaint
{
    public class GazeAwareButtons : MonoBehaviour
    {
        public Button increaseSizeButton;
        public Button decreaseSizeButton;
        public Button clearImageButton;
        public Button saveButton;
        public Camera saveCamera;
        Vector3 increasePos;
        Vector3 decreasePos;
        Vector3 clearPos;
        Vector3 savePos;
        Rect increaseRect;
        Rect decreaseRect;
        Rect clearRect;
        Rect saveRect;
        float increaseXMin;
        float increaseXMax;
        float increaseYMin;
        float increaseYMax;
        float decreaseXMin;
        float decreaseXMax;
        float decreaseYMin;
        float decreaseYMax;
        int currentBrushSize;

        float clearXMin;
        float clearXMax;
        float clearYMin;
        float clearYMax;

        float saveXMin;
        float saveXMax;
        float saveYMin;
        float saveYMax;

        float timeBeforeClick;
        float timeBetweenClicks = 1;

        // Size boundaries for brush
        int minBrushSize = 10;
        int maxBrushSize = 64;
        Vector2 filteredPoint;
        MobilePaint mobilePaint;


        // Start is called before the first frame update
        void Start()
        {
            mobilePaint = PaintManager.mobilePaint; // Gets reference to mobilePaint through PaintManager

            // Sets the Default Brush Size
            currentBrushSize = 20;
            mobilePaint.SetBrushSize(currentBrushSize);

            timeBeforeClick = timeBetweenClicks;
        }


        private void Update()
        {
            timeBetweenClicks -= Time.deltaTime;

            increasePos = increaseSizeButton.transform.position;
            decreasePos = decreaseSizeButton.transform.position;
            increaseRect = increaseSizeButton.GetComponent<RectTransform>().rect;
            decreaseRect = decreaseSizeButton.GetComponent<RectTransform>().rect;
            clearRect = clearImageButton.GetComponent<RectTransform>().rect;
            saveRect = saveButton.GetComponent<RectTransform>().rect;

            increaseXMin = increaseRect.xMin;
            increaseXMax = increaseRect.xMax;
            increaseYMin = increaseRect.yMin;
            increaseYMax = increaseRect.yMax;

            decreaseXMin = decreaseRect.xMin;
            decreaseXMax = decreaseRect.xMax;
            decreaseYMin = decreaseRect.yMin;
            decreaseYMax = decreaseRect.yMax;

            clearXMin = clearRect.xMin;
            clearXMax = clearRect.xMax;
            clearYMin = clearRect.yMin;
            clearYMax = clearRect.yMax;

            saveXMin = saveRect.xMin;
            saveXMax = saveRect.xMax;
            saveYMin = saveRect.yMin;
            saveYMax = saveRect.yMax;


            Vector2 gazePoint = TobiiAPI.GetGazePoint().Screen;  // Fetches the current co-ordinates on the screen that the player is looking at via the eye-tracker           
            filteredPoint = Vector2.Lerp(filteredPoint, gazePoint, 0.5f);

            if ((increasePos.x + increaseXMin) < filteredPoint.x && filteredPoint.x < (increasePos.x + increaseXMax) && (increasePos.y + increaseYMin) < filteredPoint.y && filteredPoint.y < (increasePos.y + increaseYMax) && timeBetweenClicks <= 0)
            {
                IncreaseBrushSize();
                timeBeforeClick = timeBetweenClicks;
            }

            if ((decreasePos.x + decreaseXMin) < filteredPoint.x && filteredPoint.x < (decreasePos.x + decreaseXMax) && (decreasePos.y + decreaseYMin) < filteredPoint.y && filteredPoint.y < (decreasePos.y + decreaseYMax) && timeBetweenClicks <= 0)
            {
                DecreaseBrushSize();
                timeBeforeClick = timeBetweenClicks;
            }

            if ((clearPos.x + clearXMin) < filteredPoint.x && filteredPoint.x < (clearPos.x + clearXMax) && (clearPos.y + clearYMin) < filteredPoint.y && filteredPoint.y < (clearPos.y + clearYMax) && timeBetweenClicks <= 0)
            {
                mobilePaint.ClearImage();
                timeBeforeClick = timeBetweenClicks;
            }

            if ((savePos.x + saveXMin) < filteredPoint.x && filteredPoint.x < (savePos.x + saveXMax) && (savePos.y + saveYMin) < filteredPoint.y && filteredPoint.y < (savePos.y + saveYMax) && timeBetweenClicks <= 0)
            {
                saveCamera.GetComponent<SaveImageScript>().Save();
                timeBeforeClick = timeBetweenClicks;
            }

        }


        // Changes the size of the brush by 5
        public void IncreaseBrushSize()
        {
            // If the new size is bigger than the maxBrushSize, it won't change size
            if (currentBrushSize <= maxBrushSize - 5)
            {
                currentBrushSize += 5;
                mobilePaint.SetBrushSize(currentBrushSize);
            }
        }


        // Changes the size of the brush by -5
        public void DecreaseBrushSize()
        {
            // If the new size is smaller than the minBrushSize, it won't change size
            if (currentBrushSize >= minBrushSize + 5)
            {
                currentBrushSize -= 5;
                mobilePaint.SetBrushSize(currentBrushSize);
            }
        }
    }
}
