using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace unitycoder_MobilePaint
{
    public class BrushSizeScript : MonoBehaviour
    {
        int currentBrushSize;
        float brushPreviewSize;

        // Size boundaries for brush
        int minBrushSize = 10;
        int maxBrushSize = 64;

        // Size boundaries for brush preview
        float maxPreviewSize = 2f;
        float minPreviewSize = 0.2f;

        [SerializeField]
        GameObject brushPreview;

        MobilePaint mobilePaint;


        // Start is called before the first frame update
        void Start()
        {
            mobilePaint = PaintManager.mobilePaint; // Gets reference to mobilePaint through PaintManager

            // Sets the default Brush Size
            currentBrushSize = 20;
            mobilePaint.SetBrushSize(currentBrushSize);

            // sets the default for brush preview
            brushPreviewSize = 0.3f;
            brushPreview.transform.localScale = new Vector2(brushPreviewSize, brushPreviewSize);
        }


        // Changes the size of the brush by 5
        public void IncreaseBrushSize()
        {
            // If the new size is bigger than the maxBrushSize, it won't change size
            if (currentBrushSize <= maxBrushSize - 5 && brushPreviewSize <= maxPreviewSize)
            {
                // Increase brush size
                currentBrushSize += 5;
                mobilePaint.SetBrushSize(currentBrushSize);

                // Increase preview
                brushPreviewSize += 0.05f;
                brushPreview.transform.localScale = new Vector2(brushPreviewSize, brushPreviewSize);
            }
        }


        // Changes the size of the brush by -5
        public void DecreaseBrushSize()
        {
            // If the new size is smaller than the minBrushSize, it won't change size
            if (currentBrushSize >= minBrushSize + 5 && brushPreviewSize >= minPreviewSize)
            {
                // Decrease brush size
                currentBrushSize -= 5;
                mobilePaint.SetBrushSize(currentBrushSize);

                // Decrease preview
                brushPreviewSize -= 0.05f;
                brushPreview.transform.localScale = new Vector2(brushPreviewSize, brushPreviewSize);
            }
        }
    }
}
