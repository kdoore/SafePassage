using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class GameState : IStateBase{//usnig state base for methods and activeState 
	
	
	public Button gameButton1,gameButton2,situationButton,option1Button,option2Button,opPanel1Button, 
	opPanel2Button,opPanel2ContButton,option3Button,opPanel3Button, opPanel3ContButton; 

	public CanvasGroup cg1,cg2,cg3,cg4,cg5,cg6,cg7,cg8,cg9; 
	
	
	private GameScene scene; 
	
	public GameScene Scene{
		get{return scene;}
	}
	
	public GameState(  ){//allows us to pass messages back and forth 
        scene = GameScene.Game;
		Debug.Log("GameState Constructor");
		
	}
	
	public void InitializedObjectRefs(){ 
		//Panels
         
        cg1=GameObject.Find("GamePanel1").GetComponent<CanvasGroup>();
        cg2=GameObject.Find("GamePanel2").GetComponent<CanvasGroup>();
        cg3=GameObject.Find("SituationPanel").GetComponent<CanvasGroup>();
        cg4=GameObject.Find("GamePanel3").GetComponent<CanvasGroup>();
        cg5=GameObject.Find("OptionPanel1").GetComponent<CanvasGroup>();
        cg6=GameObject.Find("OptionPanel2").GetComponent<CanvasGroup>();
		cg7=GameObject.Find("OptionPanel3").GetComponent<CanvasGroup>();
		cg9=GameObject.Find("OptionPanel3Cont").GetComponent<CanvasGroup>();
			
		//Buttons
		
		//find the GameObject and 
		//add the function 'do________Things' to the list of listeners
		//so when button is clicked, doStoryThings() is executed
		
		gameButton1=GameObject.Find("GameButton1").GetComponent<Button>();
		gameButton1.onClick.AddListener(DoGame1Things); 
		
		gameButton2=GameObject.Find("GameButton2").GetComponent<Button>();
		gameButton2.onClick.AddListener(DoGame2Things);
		
		situationButton=GameObject.Find("SituationButton").GetComponent<Button>();
		situationButton.onClick.AddListener(DoSituationThings);

		option1Button=GameObject.Find("OptionButton1").GetComponent<Button>();
		option1Button.onClick.AddListener(DoOption1Things);
	 		
        option2Button=GameObject.Find("OptionButton2").GetComponent<Button>();
		option2Button.onClick.AddListener(DoOption2Things);
			 
		option3Button=GameObject.Find("OptionButton3").GetComponent<Button>();
		option3Button.onClick.AddListener(DoOption3Things);
		 
		opPanel1Button=GameObject.Find("OpPanel1Button").GetComponent<Button>();
		opPanel1Button.onClick.AddListener(DoOptionPanel1Things);

		opPanel2Button=GameObject.Find("OpPanel2Button").GetComponent<Button>();
		opPanel2Button.onClick.AddListener(DoOpPanel2Things);
	
		opPanel3Button=GameObject.Find("OpPanel3Button").GetComponent<Button>();
		opPanel3Button.onClick.AddListener(DoOpPanel3Things);

		opPanel3ContButton = GameObject.Find("OpPanel3ContButton").GetComponent<Button>();
		opPanel3ContButton.onClick.AddListener(DoOpContPanel3Things);
		
        Utility.ShowCG(cg1);
        Utility.HideCG(cg2);
        Utility.HideCG(cg3);
        Utility.HideCG(cg4);

	}

	
	public void DoGame1Things(){
		Debug.Log ("Game 1 Things are Happening"); // put debugs where it only happens once
        Utility.HideCG(cg1); //set the GamePanel1 to be invisible                                         //hide GamePanel1
        Utility.ShowCG(cg2);//set the GamePanel1 to be invisible	
	}
	
	public void DoGame2Things(){
		Debug.Log ("Game 2 Things are Happening"); // put debugs where it only happens once
		//show SituationPanel
        Utility.ShowCG(cg3);
        Utility.HideCG(cg2);
	}
	
	
    public void DoSituationThings(){
		Debug.Log ("Situation Things are Happening"); // put debugs where it only happens once
		//show the GamePanel3
        Utility.ShowCG(cg4);
        Utility.HideCG(cg2);
	}

    public void DoOption1Things(){
		Debug.Log ("Option1 Things are Happening");// put debugs where it only happens once
		//show OptionPanel1
        Utility.ShowCG(cg5);
	}


    public void DoOption2Things(){
		Debug.Log ("Option 2 - Choose To Fight"); // put debugs where it only happens once
		//show OptionPanel2
        Utility.ShowCG(cg6);
		
	}

    public void DoOption3Things(){
		Debug.Log ("Option 3 Things are Happening"); //only happens once
		//show OptionPanel3
        Utility.ShowCG(cg7);
	
	}

    public void DoOptionPanel1Things(){
		//Switch states and scenes from Game to Final
        SceneManager.LoadScene("Final");//changes scene 
		StateManager.instanceRef.SwitchState(new FinalState( )); //changes state 
	}
	
    public void DoOpPanel2Things(){
		Debug.Log ("Option 2 Panel Things are Happening"); //only happens once

		//Switch states and scenes from Game to Final
		SceneManager.LoadScene ("End");//changes scene
		StateManager.instanceRef.SwitchState(new EndState( ));//changes state 

	}

	//excluded for now 
	/*
	public void doOpPanel2ContThings(){
		Application.LoadLevel ("End");
		manager.SwitchState(new EndState(manager));
	}
	*/


    public void DoOpPanel3Things(){
		Debug.Log ("Option 3 Things are Happening");//only happens once
		//show OpPanel3 (second panel of OptionPanel3 
        Utility.ShowCG(cg9);
		
    } 

	public void DoOpContPanel3Things(){
		//Switch states and scenes from Game to Final
	    SceneManager.LoadScene ("Final");//changes scene //only happens once
		StateManager.instanceRef.SwitchState(new FinalState( ));//changes state	
	} 
		
	
}

