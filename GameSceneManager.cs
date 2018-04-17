using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public enum GameMode {
	preGame, level1, level2

}

public class GameSceneManager : MonoBehaviour {

	public GameMode currentMode; 
	//public GameObject pickups, level1GameObjects,level2GameObjects, startBkg, startButton,introaudio;  
    public GameObject introaudio;
	
	// Use this for initialization
	void Start () {
		currentMode = GameMode.preGame; 
        introaudio= GameObject.Find("introAudio"); 
	}

	
	public void StartGame(){
		GameData.instanceRef.WarriorScore  = 0; 
        GameData.instanceRef.lives = 2; 
		//startBkg.SetActive (false);
		//startButton.SetActive(false); 
		currentMode = GameMode.level1; 
	   //level1GameObjects.SetActive (true); 
		Debug.Log ("level 1 is active"); 
		introaudio.SetActive (false); 

	}

	public void PlayMainGame(){
		StartGame();
        SceneManager.LoadScene ("Start");
		StateManager.instanceRef.SwitchState(new StartState());

		//StartGame(); 
	}

}
