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
        Vector3 increasePos;
        Vector3 decreasePos;
        Vector3 clearPos;
        Rect increaseRect;
        Rect decreaseRect;
        Rect clearRect;
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
