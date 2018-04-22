using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class BattleGameEndState : IStateBase{
	
	
    public Button restartbutton1;
 
	 
	private GameScene scene; 
	 

	public GameScene Scene{
		get{return scene;}
	}

	public BattleGameEndState(  ){//allows us to pass messages back and forth 
	 	Debug.Log("BattleGameEndState Constructor");//only happens once
        scene = GameScene.BattleGameEnd;
	}

	public void InitializedObjectRefs(){ 
	    restartbutton1=GameObject.Find("GameOverRestartButton").GetComponent<Button>();
		restartbutton1.onClick.AddListener(doGameRestartThings);  
	}
		

	public void doGameRestartThings(){

		Debug.Log ("Battle Game Restart Things are Happening");//only happens once 
		 
			SceneManager.LoadScene ("Start"); 
			StateManager.instanceRef.SwitchState(new StartState()); 
			
	}
	
	 
}

