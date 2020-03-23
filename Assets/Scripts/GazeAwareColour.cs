using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tobii.Gaming;

public class GazeAwareColour : MonoBehaviour
{
    public static Color newColor { get; private set; }

    public GameObject colourPanel;
    Vector3 panelPos;
    Rect panelRect;

    float panelXMin;
    float panelXMax;
    float panelYMin;
    float panelYMax;

    float timeBeforeClick;
    float timeBetweenClicks = 1;
    Vector2 filteredPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeBetweenClicks -= Time.deltaTime;

        panelPos = colourPanel.transform.position;
        panelRect = colourPanel.GetComponent<RectTransform>().rect;

       panelXMin = panelRect.xMin;
       panelXMax = panelRect.xMax;
       panelYMin = panelRect.yMin;
       panelYMax = panelRect.yMax;


        Vector2 gazePoint = TobiiAPI.GetGazePoint().Screen;  // Fetches the current co-ordinates on the screen that the player is looking at via the eye-tracker           
        filteredPoint = Vector2.Lerp(filteredPoint, gazePoint, 0.5f);

        if ((panelPos.x + panelXMin) < filteredPoint.x && filteredPoint.x < (panelPos.x + panelXMax) && (panelPos.y + panelYMin) < filteredPoint.y && filteredPoint.y < (panelPos.y + panelYMax) && timeBetweenClicks <= 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                var picker = hit.collider.GetComponent<ColorPicker>();

                if (picker != null)
                {
                    Renderer rend = hit.transform.GetComponent<Renderer>();
                    MeshCollider meshCollider = hit.collider as MeshCollider;

                    if (rend == null || rend.sharedMaterial == null || rend.sharedMaterial.mainTexture == null || meshCollider == null)
                        return;

                    Texture2D tex = rend.material.mainTexture as Texture2D;
                    Vector2 pixelUV = hit.textureCoord;
                    pixelUV.x *= tex.width;
                    pixelUV.y *= tex.height;
                    newColor = tex.GetPixel((int)pixelUV.x, (int)pixelUV.y);

                    //                  selectedColorPreview.material.color = SelectedColor;
                }
            }
            timeBeforeClick = timeBetweenClicks;
        }
    }
}
