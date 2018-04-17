using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class BattleGameEndState : IStateBase{
	
	private StateManager manager;
	private GameObject battlegameendpanel, youWinPanel; 
	public Button restartbutton1,restartbutton2; 
	public CanvasGroup cg1; 
	private bool initialized=false;   
	 
	private GameScene scene; 
	//public CanvasGroup cg1; 
	//private string newline = System.Environment.NewLine;

	public GameScene Scene{
		get{return scene;}
	}

	public BattleGameEndState( StateManager managerReference){//allows us to pass messages back and forth 
		this.manager = managerReference; // instance variable has been set to the reference 
		Debug.Log("BattleGameEndState Constructor");//only happens once
		
	}

	public void InitializedObjectRefs(){ 
		//Buttons
		initialized=true; 

		if(battlegameendpanel == null && GameObject.Find("GameOverPanel")!=null){
		battlegameendpanel=GameObject.Find ("GameOverPanel");
		cg1=battlegameendpanel.GetComponent<CanvasGroup>();
		}


		if(restartbutton1 == null && GameObject.Find("GameOverRestartButton")!=null){
		restartbutton1=GameObject.Find("GameOverRestartButton").GetComponent<Button>();
		restartbutton1.onClick.AddListener(doGameRestartThings);  
		}
		

	}
		

	public void doGameRestartThings(){

		Debug.Log ("Battle Game Restart Things are Happening");//only happens once 
			//restart the game 
			Application.LoadLevel ("Start"); 
			manager.SwitchState(new StartState()); 
			
	}
	
	public void ShowIt(){
		Debug.Log ("show it battle game end"); //"show it _____" debug will give me another indication of what state i'm in 
		
	}
}

