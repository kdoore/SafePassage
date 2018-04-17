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

	
	public BattleGameWinState( StateManager managerReference){//allows us to pass messages back and forth 
		this.manager = managerReference; // instance variable has been set to the reference 
		Debug.Log("BattleGameWinState Constructor");//only happens once
		
	}

	public void InitializedObjectRefs(){ 
		//Buttons
		initialized=true; 

		if(youWinPanel == null && GameObject.Find("YouWinPanel")!=null){
			youWinPanel=GameObject.Find ("YouWinPanel");
			cg1=youWinPanel.GetComponent<CanvasGroup>();
		}

		if(restartbutton2 == null && GameObject.Find("YouWinRestartButton")!=null){
		restartbutton2=GameObject.Find("YouWinRestartButton").GetComponent<Button>();
		restartbutton2.onClick.AddListener(doGameRestartThings);  
		}
		

	}

	public void StateUpdate(){
		if(initialized==false && GameObject.Find ("Battle Game EndPanel")!=null){
			InitializedObjectRefs();
		}
	}

	public void doGameRestartThings(){

		Debug.Log ("Battle Game Restart Things are Happening");//only happens once 
			//restart the game 
			Application.LoadLevel ("Start") ; 
			manager.SwitchState(new StartState()); 
			
	}
	
	public void ShowIt(){
		Debug.Log ("show it battle game end"); //"show it _____" debug will give me another indication of what state i'm in 
		
	}
}

