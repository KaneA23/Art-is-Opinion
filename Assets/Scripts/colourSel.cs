using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colourSel : MonoBehaviour {

    //void OnMouseDown()
    //{
    //    // get mouse hit position, inside non-scaled guitexture
    //    Vector3 hitPos = Input.mousePosition;// - corner;
    //    Color hitColor = tex.GetPixel((int)((hitPos.x - guiRect.x) / ratio), (int)((hitPos.y - guiRect.y) / ratio));
    //    hitColor.a = alpha; // take alpha from slider

    //    // send color to canvas
    //    canvas.paintColor = hitColor;
    //    selectedColor.GetComponent<GUITexture>().color = hitColor * 0.5f; // half the color, otherwise too bright..unity feature?
    //    previewColor.GetComponent<GUITexture>().color = hitColor * 0.5f;

    //    // close palette dialog slowly (to avoid accidental drawing after palette click)
    //    if (closeAfterPick)
    //    {
    //        GetComponent<GUITexture>().enabled = false; // hide guitexture just to show something is happening
    //        Invoke("DelayedToggle", 0.5f);
    //    }

    //} // onmousedown}

}