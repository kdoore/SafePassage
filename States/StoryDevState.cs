using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryDevState : IStateBase {//using state base for methods and activeState 

	 
	private Button button2,button3,button4,button5,button6,button7,button8,button9; 
    private CanvasGroup cgStoryPanel,cgInvitePanel,cgAltEndingPanel1,cgAltEndingPanel2,cgAltEndingPanel3,cgPlayerPanel,cgCharacterPanel; 
   
	//private bool selectcharacter = false, goback = false;
	

	private GameScene scene; 

	public GameScene Scene{
		get{return scene;}
	}

	public StoryDevState( ){//allows us to pass messages back and forth 
		scene = GameScene.StoryDev;
		Debug.Log("StoryDevState Constructor");//only happens once 

	}

	public void InitializedObjectRefs(){ 
		//Panels
		//find the MainPanel Canvas Group

		cgStoryPanel=GameObject.Find("StoryDevPanel").GetComponent<CanvasGroup>();

        cgInvitePanel=GameObject.Find("InvitationPanel").GetComponent<CanvasGroup>();

        cgAltEndingPanel1=GameObject.Find("AltEndingPanel1").GetComponent<CanvasGroup>();

        cgAltEndingPanel2=GameObject.Find("AltEndingPanel2").GetComponent<CanvasGroup>();

        cgAltEndingPanel3=GameObject.Find("AltEndingPanel3").GetComponent<CanvasGroup>();

        cgPlayerPanel=GameObject.Find("PlayerPanel").GetComponent<CanvasGroup>();

	    cgCharacterPanel=GameObject.Find("CharacterPanel").GetComponent<CanvasGroup>();
		
        //Buttons
		button2=GameObject.Find("LeftButton").GetComponent<Button>();
		button2.onClick.AddListener(doStoryThings); 

		button3=GameObject.Find("Choice1Button").GetComponent<Button>();
		button3.onClick.AddListener(doChoice1Things);

		button4=GameObject.Find("Choice2Button").GetComponent<Button>();
		button4.onClick.AddListener(doChoice2Things);

		button5=GameObject.Find("AltButton1").GetComponent<Button>();
		button5.onClick.AddListener(doAltEnd1Things);

		button6=GameObject.Find("AltButton2").GetComponent<Button>();
		button6.onClick.AddListener(doAltEnd2Things);

		button7=GameObject.Find("AltButton3").GetComponent<Button>();
		button7.onClick.AddListener(doAltEnd3Things);

		button8=GameObject.Find("BackButton").GetComponent<Button>();
		button8.onClick.AddListener(doBackButtonThings);

        button9= GameObject.Find("SelectButton").GetComponent<Button>();
        button9.onClick.AddListener(SelectPlayer);


        Utility.HideCG(cgPlayerPanel);
        Utility.HideCG(cgCharacterPanel);
        Utility.ShowCG(cgStoryPanel);
        Utility.HideCG(cgInvitePanel);
	}
		

	public void doStoryThings(){
		Debug.Log ("Story Dev Things are Happening");//only happens once
        Utility.HideCG(cgStoryPanel);
        Utility.ShowCG(cgInvitePanel);
	
	}

	public void doChoice1Things(){
		Debug.Log ("Choice 1 Things are Happening"); //only happens once
        Utility.HideCG(cgCharacterPanel);                                            //hide invitationPanel
        Utility.ShowCG(cgPlayerPanel);
		
	}


	public void doChoice2Things(){
		Debug.Log ("Choice 2 Things are Happening"); //only happens once
        //Utility.ShowCG(cgCharacterPanel);
        doAltEnd3Things();//chose not to play? change scenes?
	}

	public void doBackButtonThings(){
		Debug.Log ("Back Button Things are Happening");//only happens once
                                                       //hide storyPanel
        Utility.ShowCG(cgStoryPanel);
        Utility.HideCG(cgInvitePanel);
	}

	public void doAltEnd1Things(){
		Debug.Log ("AltEnd1 Things are Happening");//only happens once
 
         Utility.HideCG(cgPlayerPanel); //hide storyPanel
		 Utility.ShowCG(cgAltEndingPanel1);


	}

	public void doAltEnd2Things(){
		Debug.Log ("AltEnd2 Things are Happening");//only happens once
		//hide invitationPanel

		Utility.ShowCG(cgAltEndingPanel2);

	}

	public void doAltEnd3Things(){
		Debug.Log ("AltEnd3 Things are Happening");//only happens once
		SceneManager.LoadScene ("End");
		StateManager.instanceRef.SwitchState(new EndState( ));

	}


	public void SelectPlayer(){
        
		SceneManager.LoadScene ("Game");
		StateManager.instanceRef.SwitchState(new GameState( ));//changes state to StoryState 
       
	}
	

	}//end class


	

