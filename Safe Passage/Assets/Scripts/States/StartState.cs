using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class StartState : IStateBase{//usnig state base for methods and activeState 

    public GameObject titleText; 
	private Text title; //refering to the text itself 
	private Button  button2; 
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
         
		button2 = GameObject.Find("StartButton").GetComponent<Button>(); //Text refers to unity engine.UI include//this is a method
		button2.onClick.AddListener(doStartThings);
        	  
	}

	public void doStartThings (){
		Debug.Log ("Start Things are Happening");//only happens once 
		SceneManager.LoadScene("Intro");
        StateManager.instanceRef.SwitchState(new IntroState());//changes state to StoryState 
	}
		
	
}


