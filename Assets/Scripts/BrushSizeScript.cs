using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace unitycoder_MobilePaint
{

    public class BrushSizeScript : MonoBehaviour
    {
        int currentBrushSize;

        // Size boundaries for brush
        int minBrushSize = 10;
        int maxBrushSize = 64;

        MobilePaint mobilePaint;


        // Start is called before the first frame update
        void Start()
        {
            mobilePaint = PaintManager.mobilePaint; // Gets reference to mobilePaint through PaintManager

            // Sets the Default Brush Size
            currentBrushSize = 20;
            mobilePaint.SetBrushSize(currentBrushSize);
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