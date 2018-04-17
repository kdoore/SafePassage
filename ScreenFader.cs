using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

//Screen Fader Script from NovaSurfer on Github
//https://gist.github.com/NovaSurfer/5f14e9153e7a2a07d7c5
//NovaSurfer on GitHub
//create a UI Image, move it off-screen, give it a black color.
//Attach this script to the main camera in each scene where you want fading
//populate the FadeImage with your UI Image in the inspector

public class ScreenFader : MonoBehaviour
{
    public Image FadeImg;
    public float fadeSpeed = 1.5f;
    public bool sceneStarting = true;
    IStateBase nextState;

    void Awake()
    {
        FadeImg.rectTransform.localScale = new Vector2(Screen.width, Screen.height);
    }

    void Update()
    {
        // If the scene is starting...
        if (sceneStarting)
            // ... call the StartScene function.
            StartScene();
    }


    void FadeToClear()
    {
        // Lerp the colour of the image between itself and transparent.
        FadeImg.color = Color.Lerp(FadeImg.color, Color.clear, fadeSpeed * Time.deltaTime);
    }


    void FadeToBlack()
    {
        // Lerp the colour of the image between itself and black.
        FadeImg.color = Color.Lerp(FadeImg.color, Color.black, fadeSpeed * Time.deltaTime);
    }


    void StartScene()
    {
        // Fade the texture to clear.
        FadeToClear();

        // If the texture is almost clear...
        if (FadeImg.color.a <= 0.05f)
        {
            // ... set the colour to clear and disable the RawImage.
            FadeImg.color = Color.clear;
            FadeImg.enabled = false;

            // The scene is no longer starting.
            sceneStarting = false;
        }
    }


    public IEnumerator EndSceneRoutine(int SceneNumber )
    {
        // Make sure the RawImage is enabled.
        FadeImg.enabled = true;
        do
        {
            // Start fading towards black.
            FadeToBlack();

            // If the screen is almost black...
            if (FadeImg.color.a >= 0.95f)
            {
                // ... reload the level
                SceneManager.LoadScene(SceneNumber);
                StateManager.instanceRef.SwitchState(nextState);
                yield break;
            }
            else
            {
                yield return null;
            }
        } while (true);
    }

    //end current scene, parameter is next scene to load
    public void EndScene(int SceneNumber, IStateBase activeState)
    {
        sceneStarting = false;
        nextState = activeState;
        StartCoroutine("EndSceneRoutine", SceneNumber );
    }
}