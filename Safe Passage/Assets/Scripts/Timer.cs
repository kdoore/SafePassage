using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	 
	public StateManager manager;
	public GameData gameData;
	public GameSceneManager gameSceneManager; 

	private bool initialized=false; 

	public float seconds,minutes; 

	public Text levelTxt; 

	void Start(){

	gameSceneManager= GetComponent<GameSceneManager>();
	gameData= GameObject.Find ("gameManager").GetComponent<GameData>();
	
	
	levelTxt.text= "LEVEL 1"; 
	
	}

	public void initializeObjectRef(){
		if(manager ==null && GameObject.Find ("gameManager") !=null){
			manager=GameObject.Find ("gameManager").GetComponent<StateManager>();
			gameData=GameObject.Find ("gameManager").GetComponent<GameData>();
			
			initialized=true;
		}
	}

	// Update is called once per frame
	void Update () {

	Debug.Log("it's time" + Time.timeSinceLevelLoad);
	minutes = (int)(Time.timeSinceLevelLoad/60f);
	seconds = (int)(Time.timeSinceLevelLoad % 60f);

		if(!initialized){
			initializeObjectRef();
		} 

	//levelTxt.text = "LEVEL 1"; 

	if (seconds == 20 && gameData.lives > 0){
		Debug.Log ("level up"); //new level is created 
		levelUp();
	}

	if (seconds == 40 && gameData.lives > 0){
			Debug.Log ("winnner!"); //new level is created 
			Winner();
		}

		if(!initialized){
			initializeObjectRef();
		} 

	}

	public void levelUp(){
		gameSceneManager.currentMode = GameMode.level2;
		Debug.Log ("level 2 activated"); 
		//gameSceneManager.level1GameObjects.SetActive (false); 
		//GameObject.Find ("Level2GameObjects");
		//gameSceneManager.level2GameObjects.SetActive (true);
		levelTxt.text = "LEVEL 2" ; 

		
	}

	public void Winner(){ 
		Debug.Log ("begin state end activated"); 
		Application.LoadLevel ("Battle Game Win");
		manager.SwitchState(new BattleGameWinState(manager));
		
		
	}

}
