using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Tobii.Gaming;

namespace unitycoder_MobilePaint
{
	public class CustomBrushesUI : MonoBehaviour {

		public MobilePaint mobilePaint;
		public Button buttonTemplate;

        public Button[] brushes;
        Vector3[] Positions;
        Rect[] rects;
        float[] XMin;
        float[] XMax;
        float[] YMin;
        float[] YMax;

        float timeBeforeClick;
        float timeBetweenClicks = 1;

        Vector2 filteredPoint;

        [SerializeField] private int padding = 8;

		void Start () 
		{
            timeBeforeClick = timeBetweenClicks;

            if (mobilePaint==null) Debug.LogError("No MobilePaint assigned at "+transform.name);
			if (buttonTemplate==null) Debug.LogError("No buttonTemplate assigned at "+transform.name);

			// build custom brush buttons for each custom brush
			Vector2 newPos = new Vector2(padding,-padding);

			for(int i=0;i<mobilePaint.customBrushes.Length;i++)
			{
				// instantiate buttons
				var newButton = Instantiate(buttonTemplate,Vector3.zero,Quaternion.identity) as Button;
				newButton.transform.SetParent(transform,false);

				RectTransform rectTrans = newButton.GetComponent<RectTransform>();

				// wrap inside panel width
				if (newPos.x+rectTrans.rect.width>=GetComponent<RectTransform>().rect.width)
				{
					newPos.x=0+padding;
					newPos.y -= rectTrans.rect.height+padding;
					// NOTE: maximum Y is not checked..so dont put too many custom brushes.. would need to add paging or scrolling
				}
				rectTrans.anchoredPosition = newPos;
				newPos.x += rectTrans.rect.width+padding;

				// assign brush image
				// NOTE: have to use rawimage, instead of image (because cannot cast Texture2D into Image)
				// i've read that rawimage causes extra drawcall per drawimage, thats not nice if there are tens of images..
				newButton.GetComponent<RawImage>().texture = mobilePaint.customBrushes[i];
				var index = i;

				// event listener for button clicks, pass custom brush array index number as parameter
				newButton.onClick.AddListener(delegate {this.SetCustomBrush(index);});


                //MattP
                Positions[index] = newButton.transform.position;
                rects[index] = newButton.GetComponent<RectTransform>().rect;
                XMin[index] = rects[index].xMin;
                XMax[index] = rects[index].xMax;
                YMin[index] = rects[index].yMin;
                YMax[index] = rects[index].yMax;

            }
		}

        private void Update()
        {
            Vector2 gazePoint = TobiiAPI.GetGazePoint().Screen;  // Fetches the current co-ordinates on the screen that the er is looking at via the eye-tracker           
            filteredPoint = Vector2.Lerp(filteredPoint, gazePoint, 0.5f);

            int loopPos = 0;
            foreach(Button brush in brushes)
            {
                if ((Positions[loopPos].x + XMin[loopPos]) < filteredPoint.x && filteredPoint.x < (Positions[loopPos].x + XMax[loopPos]) && (Positions[loopPos].y + YMin[loopPos]) < filteredPoint.y && filteredPoint.y < (Positions[loopPos].y + YMax[loopPos]) && timeBetweenClicks <= 0)
                {
                    SetCustomBrush(loopPos);
                    timeBeforeClick = timeBetweenClicks;
                    break;
                }
                loopPos += 1;
            }
        }
        // send current brush index to mobilepaint
        public void SetCustomBrush(int index)
		{
			mobilePaint.selectedBrush = index;
			mobilePaint.ReadCurrentCustomBrush(); // tell mobile paint to read custom brush pixel data
			CloseCustomBrushPanel();
		}

		public void CloseCustomBrushPanel()
		{
			gameObject.SetActive(false);
		}

		public void OpenCustomBrushPanel()
		{
			gameObject.SetActive(true);
		}

	}
}