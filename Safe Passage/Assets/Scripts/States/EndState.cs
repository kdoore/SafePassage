using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndState : IStateBase
{

    private GameObject endpanel;
    public Button restartbutton;
    public CanvasGroup cg1;

    private GameScene scene;


    public GameScene Scene
    {
        get { return scene; }
    }

    public EndState()
    {//allows us to pass messages back and forth 
        Debug.Log("EndState Constructor");//only happens once
        scene = GameScene.End;
    }

    public void InitializedObjectRefs()
    {
        endpanel = GameObject.Find("EndPanel");
        cg1 = endpanel.GetComponent<CanvasGroup>();


        restartbutton = GameObject.Find("RestartButton").GetComponent<Button>();
        restartbutton.onClick.AddListener(doRestartThings);

    }



    public void doRestartThings()
    {
        //restart the game 
        SceneManager.LoadScene("Start");
        StateManager.instanceRef.SwitchState(new StartState());

    }


}

