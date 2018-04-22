using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class FinalState : IStateBase{//using state base for methods and activeState 
	
	private GameObject finalPanel1,finalPanel2;
	public Button finalbutton, restartbutton2; 
	public CanvasGroup cg1,cg2; 

	private GameScene scene; 
	
	public GameScene Scene{
		get{return scene;}
	}

	
	public FinalState( ){//allows us to pass messages back and forth 
        scene = GameScene.Final;
		Debug.Log("FinalState Constructor"); //only happens once
		
	}

	public void InitializedObjectRefs(){ 
		//Panels

		//FinalPanel1 Canvas Group 
	 	finalPanel1=GameObject.Find ("FinalPanel1");
		cg1=finalPanel1.GetComponent<CanvasGroup>();
		 

		//FinalPanel2 Canvas Group 
		finalPanel2=GameObject.Find ("FinalPanel2");
		cg2=finalPanel2.GetComponent<CanvasGroup>();

		//Buttons

		//FinalButton1
		finalbutton=GameObject.Find("FinalButton1").GetComponent<Button>();
		finalbutton.onClick.AddListener(doFinalThings);
	 

		//RestartButton2 
		restartbutton2=GameObject.Find("RestartButton2").GetComponent<Button>();
		restartbutton2.onClick.AddListener(doRestart2Things); 

	}
	
	

	public void doFinalThings(){	
		Debug.Log ("Final Things are Happening"); //only happens once
                                                  //hide FinalPanel1
        Utility.HideCG(cg1);
        Utility.ShowCG(cg2);
	}

	public void doRestart2Things(){
		
		Debug.Log ("Restart 2 Things are Happening");//only happens once 

		//restart the game 
		SceneManager.LoadScene ("Start") ; 
        StateManager.instanceRef.SwitchState(new StartState()); 
		
	}

	
}

