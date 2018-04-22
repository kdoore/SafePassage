using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class BattleGameWinState : IStateBase {
	
	private StateManager manager;
	private GameObject youWinPanel; 
	public Button restartbutton2; 
	public CanvasGroup cg1; 
	private bool initialized=false; 
	 
	private GameScene scene; 
	//public CanvasGroup cg1; 
	//private string newline = System.Environment.NewLine;

	public GameScene Scene{
		get{return scene;}
	}

	
	public BattleGameWinState(  ){//allows us to pass messages back and forth 
	 	Debug.Log("BattleGameWinState Constructor");//only happens once
        scene = GameScene.BattleGameWin;
	}

	public void InitializedObjectRefs(){ 
		 
		 	youWinPanel=GameObject.Find ("YouWinPanel");
			cg1=youWinPanel.GetComponent<CanvasGroup>();
		 

	 	restartbutton2=GameObject.Find("YouWinRestartButton").GetComponent<Button>();
		restartbutton2.onClick.AddListener(doGameRestartThings);  
	}

	 

	public void doGameRestartThings(){

		Debug.Log ("Battle Game Restart Things are Happening");//only happens once 
			//restart the game 
			SceneManager.LoadScene ("Start") ; 
            StateManager.instanceRef.SwitchState(new StartState()); 
			
	}
	
 
}

