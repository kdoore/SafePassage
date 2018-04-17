using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

//Panel that transitions to visible, then closed by a button, that
//triggers an event
public class FadePanel : MonoBehaviour {

    CanvasGroup cg;
    Button nextBtn;
    Image FadePanelImg;

    public float fadeSpeed = 1.5f;
  
    public UnityEvent onPanelClosing; //define the custom event


	void Start () {
        FadePanelImg = GetComponent<Image>();
        nextBtn = GetComponentInChildren<Button>();
        nextBtn.onClick.AddListener(ClosePanel);

        cg = GetComponentInChildren<CanvasGroup>();

        if (onPanelClosing == null)
        {
            onPanelClosing = new UnityEvent();
        }

        InitializePanel();
	}

    public void OpenPanel(){
        PanelVisibleRoutine();
        StartCoroutine("PanelVisibleRoutine" );
       
    }

  
    void InitializePanel()
    {
        // ... set the colour to clear and disable the RawImage.
        FadePanelImg.color = Color.clear;
        FadePanelImg.enabled = false;
        Utility.HideCG(cg); //hide quote panel
    }

    void FadeToVisible()
    {
        // Lerp the colour of the image between itself and black.
        FadePanelImg.color = Color.Lerp(FadePanelImg.color, Color.black, fadeSpeed * Time.deltaTime);
    }



    public IEnumerator PanelVisibleRoutine()
    {
        // Make sure the RawImage is enabled.
        FadePanelImg.enabled = true;
        do
        {
            // Start fading towards black.
            FadeToVisible();

            // If the screen is almost black...
            if (FadePanelImg.color.a >= 0.95f)
            {
                Utility.ShowCG(cg);
                 yield break;
            }
            else
            {
                yield return null;
            }
        } while (true);
    }

    //

    public void ClosePanel(){
        if(onPanelClosing != null){  //we have listeners
            onPanelClosing.Invoke();
        }
    }
}
