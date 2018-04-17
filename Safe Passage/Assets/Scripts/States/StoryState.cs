using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class StoryState : IStateBase{//usnig state base for methods and activeState 
	 
		private StateManager manager; 
		private GameObject storyPanel, invitePanel, playerPanel, altEndingPanel1, altEndingPanel2,altEndingPanel3;
		private Button button2,button3,button4,button5,button6,button7,button8,button9; 
		private CanvasGroup cg1,cg2,cg3,cg4,cg5,cg6; 

		private bool initialized=false; 
		
	private GameScene scene; 
	//public CanvasGroup cg1; 
	//private string newline = System.Environment.NewLine;

	public GameScene Scene{
		get{return scene;}
	}
		
		public StoryState( StateManager managerReference){//allows us to pass messages back and forth 
			this.manager = managerReference; // instance variable has been set to the reference 
			
		Debug.Log("StoryState Constructor");//only happens once
			
		}

	public void InitializedObjectRefs(){ 
		//Panels
		//find the MainPanel Canvas Group


		storyPanel=GameObject.Find ("StoryPanel");
		cg1=storyPanel.GetComponent<CanvasGroup>();
		
		invitePanel=GameObject.Find ("InvitationPanel");
		cg2=invitePanel.GetComponent<CanvasGroup>();
		 
		altEndingPanel1=GameObject.Find ("AltEndingPanel1");
		cg3=altEndingPanel1.GetComponent<CanvasGroup>();

		altEndingPanel2=GameObject.Find ("AltEndingPanel2");
		cg4=altEndingPanel2.GetComponent<CanvasGroup>();

		altEndingPanel3=GameObject.Find ("AltEndingPanel3");
		cg5=altEndingPanel3.GetComponent<CanvasGroup>();
		
		playerPanel=GameObject.Find ("PlayerPanel");
		cg6=playerPanel.GetComponent<CanvasGroup>();


		//Buttons

		//find the LeftButton GameObject and 
		//add the function 'doStoryThings' to the list of listeners
		//so when button2 is clicked, doStoryThings() is executed

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

		button9=GameObject.Find("Player1Button").GetComponent<Button>();
		button9.onClick.AddListener(doPlayerButtonThings);


		initialized=true;
	}
		
		
		public void doStoryThings(){
		Debug.Log ("Story Things are Happening");//only happens once
			//hide storyPanel

				cg1.alpha=0;  //set the storyPanel to be invisible
				cg1.interactable=false;  //turn off interactivity for the invisible mainPanel
				cg1.blocksRaycasts=false;

				cg2.alpha=1;  //set the storyPanel to be invisible
				cg2.interactable=true;  //turn off interactivity for the invisible mainPanel
				cg2.blocksRaycasts=true;
			
			
		}

		public void doChoice1Things(){
		Debug.Log ("Choice 1 Things are Happening"); //only happens once
				//hide invitationPanel
	
					cg3.alpha=1;  //set the Choice 1 Panel  to be invisible
					cg3.interactable=true;  //turn off interactivity for the invisible mainPanel
					cg3.blocksRaycasts=true;
			
			//data.text="Player Data: " + manager.somePlayerData;

			}
		

		public void doChoice2Things(){
		Debug.Log ("Choice 2 Things are Happening"); //only happens once
			//hide invitationPanel
			
			cg4.alpha=1;  //set the Choice 2 Panel to be invisible
			cg4.interactable=true;  //turn off interactivity for the invisible mainPanel
			cg4.blocksRaycasts=true;
			
			
		}

		public void doBackButtonThings(){
		Debug.Log ("Back Button Things are Happening");//only happens once
			//hide storyPanel
			
			cg1.alpha=1;  //set the storyPanel to be invisible
			cg1.interactable=true;  //turn off interactivity for the invisible mainPanel
			cg1.blocksRaycasts=true;

			cg2.alpha=0;  //set the storyPanel to be invisible
			cg2.interactable=false;  //turn off interactivity for the invisible mainPanel
			cg2.blocksRaycasts=false;
		
	}
	
	public void doAltEnd1Things(){
		Debug.Log ("AltEnd1 Things are Happening");//only happens once

		cg3.alpha=0;  //set the storyPanel to be invisible
		cg3.interactable=false;  //turn off interactivity for the invisible mainPanel
		cg3.blocksRaycasts=false;

		cg6.alpha=1;  //set the storyPanel to be invisible
		cg6.interactable=true;  //turn off interactivity for the invisible mainPanel
		cg6.blocksRaycasts=true;



		}

		public void doAltEnd2Things(){
		Debug.Log ("AltEnd2 Things are Happening");//only happens once
			//hide invitationPanel
			
			cg5.alpha=1;  //set the Choice 2 Panel to be visible
			cg5.interactable=true;  //turn on interactivity for the visible Choice 2 Panel
			cg5.blocksRaycasts=true;
			
		}

		public void doAltEnd3Things(){
		Debug.Log ("AltEnd3 Things are Happening");//only happens once
			SceneManager.LoadScene ("End");
        StateManager.instanceRef.SwitchState(new EndState( ));
			
		}

		public void doPlayerButtonThings(){
		Debug.Log ("PlayerButton Things are Happening");//only happens once
		//Switch states and scenes from Story to Game
        SceneManager.LoadScene("Game");//changes scene
        StateManager.instanceRef.SwitchState(new GameState( )); //changes state
			
		}


		public void ShowIt(){
		Debug.Log ("show it story"); //"show it _____" debug will give me another indication of what state i'm in
			

		}
}
