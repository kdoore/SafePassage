using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialog1State : IStateBase {

    private DialogManager dialogManager;
    private GameScene scene;
    private FadePanel fadePanel;
    private ScreenFader screenFader;
   
    public GameScene Scene
    {
        get { return scene; }
    }

    public Dialog1State()
    {//allows us to pass messages back and forth 
        scene = GameScene.Dialog1;
        Debug.Log("Dialog1State Constructor");
    }

    public void InitializedObjectRefs()
    {
         //find openDialogButton and disable so it's opened when scene opens

        dialogManager = GameObject.Find("ConvPanel").GetComponent<DialogManager>();

        dialogManager.HideButton();
        dialogManager.openDialog();

        fadePanel = Object.FindObjectOfType<FadePanel>();
        fadePanel.onPanelClosing.AddListener(LoadNextScene);

        screenFader = Object.FindObjectOfType<ScreenFader>();
    }

    public void LoadNextScene(){
        IStateBase nextState = new StoryDevState();
        screenFader.EndScene((int)GameScene.StoryDev,nextState );
  
       // SceneManager.LoadScene("StoryDev");
       // StateManager.instanceRef.SwitchState(new StoryDevState());
    }
}
