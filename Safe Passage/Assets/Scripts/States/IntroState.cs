using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroState : IStateBase {

    FadePanel fadePanel;
    ScreenFader screenFader;

    private GameScene scene;

    public GameScene Scene
    {
        get { return scene; }
    }

    public IntroState()
    {//allows us to pass messages back and forth 
        scene = GameScene.Intro;
        Debug.Log("IntroState Constructor");

    }

    public void InitializedObjectRefs()
    {
        fadePanel = Object.FindObjectOfType<FadePanel>();
        fadePanel.onPanelClosing.AddListener(LoadNextScene);

        screenFader = Object.FindObjectOfType<ScreenFader>();
    }

    public void LoadNextScene(){

        IStateBase nextState = new Dialog1State();
        screenFader.EndScene((int)GameScene.Dialog1,nextState );
       
        // SceneManager.LoadScene("Dialog1");
       // StateManager.instanceRef.SwitchState(new Dialog1State());

    }
	
}
