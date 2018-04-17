using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class EndState : IStateBase{
	
	private StateManager manager;
	private GameObject endpanel; 
	public Button restartbutton; 
	public CanvasGroup cg1; 

	private bool initialized=false, rsb = false; 
	 
	private GameScene scene; 
	//public CanvasGroup cg1; 
	//private string newline = System.Environment.NewLine;

	public GameScene Scene{
		get{return scene;}
	}

	public EndState(  ){//allows us to pass messages back and forth 
		Debug.Log("EndState Constructor");//only happens once
        scene = GameScene.End;
	}

	public void InitializedObjectRefs(){ 
		//Buttons

		if(endpanel == null && GameObject.Find("EndPanel")!=null){
		endpanel=GameObject.Find ("EndPanel");
		cg1=endpanel.GetComponent<CanvasGroup>();
		}

		if(restartbutton == null && GameObject.Find("RestartButton")!=null){
		restartbutton=GameObject.Find("RestartButton").GetComponent<Button>();
		restartbutton.onClick.AddListener(doRestartThings); 
		rsb = true; 
		}
		
		//initialized=true;
	}

	public void StateUpdate(){
		if(initialized==false && GameObject.Find ("EndPanel")!=null){
			InitializedObjectRefs();
			if(rsb){
				initialized=true; 
			}
		}
	}

	public void doRestartThings(){

		Debug.Log ("Restart Things are Happening");//only happens once 
			//restart the game 
			Application.LoadLevel ("Start") ; 
			manager.SwitchState(new StartState()); 
			
	}
	
	public void ShowIt(){
		Debug.Log ("show it end"); //"show it _____" debug will give me another indication of what state i'm in 
		
	}
}

