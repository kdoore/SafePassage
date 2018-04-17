using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class StartState : IStateBase{//usnig state base for methods and activeState 

    public GameObject titleText; 
	private Text title; //refering to the text itself 
	private Button button1,button2; 
	private GameScene scene; 
	
	public GameScene Scene{
		get{return scene;}
	}

	public StartState(){//allows us to pass messages back and forth 
		Debug.Log("StartState Constructor");//only happens once
		scene = GameScene.Start; 
	}
	
	public void InitializedObjectRefs(){
		titleText = GameObject.Find("Title"); //we need the component that is type text 
		title = titleText.GetComponent<Text>(); //Text refers to unity engine.UI include//this is a method

		Debug.Log ("initializing"); //only happens once

		//button1 = GameObject.Find("Battle Game Button").GetComponent<Button>(); //Text refers to unity engine.UI include//this is a method
		//button1.onClick.AddListener(doBattleGameThings); 

		button2 = GameObject.Find("StartButton").GetComponent<Button>(); //Text refers to unity engine.UI include//this is a method
		button2.onClick.AddListener(doStartThings);
        	  
	}
		
	
	public void doBattleGameThings (){
		Debug.Log ("Battle Game Things are Happening");//only happens once 
		SceneManager.LoadScene ("Battle Game");
        StateManager.instanceRef.SwitchState(new BattleGameState());//changes state to StoryState 
        }

	public void doStartThings (){
		Debug.Log ("Start Things are Happening");//only happens once 
		SceneManager.LoadScene("Intro");
        StateManager.instanceRef.SwitchState(new IntroState());//changes state to StoryState 
	}
		
	
}


