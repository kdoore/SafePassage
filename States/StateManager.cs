using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 


public enum GameScene{

	Start = 0,

	End = 1,

	Game = 2,

	Final = 3,

	BattleGame = 4,

	BattleGameEnd = 5,

	BattleGameWin = 6,

	StoryDev = 7,

    Intro = 8,

    Dialog1 = 9

}

public class StateManager : MonoBehaviour {//inhertis from MonoDevelop 

	public static StateManager instanceRef; //creating a reference to itself //static: associated w/ class 
	private IStateBase activeState; //type of activeState is IStateBase 
	public GameScene curScene; 

	public GameData gameData;
	public GameSceneManager gameManager; 

	void Awake(){//always called before any game object 
		if(instanceRef == null){
			instanceRef = this; //equals itself (is the instanceRef pointing at anything? no, so point at itself
			Debug.Log ("Create Me"); 
			DontDestroyOnLoad(gameObject); //now it will not be destroyed during the exdecution of the game 
		}
		else {
		Debug.Log ("Destroy Me"); 
		DestroyImmediate(gameObject); //of the gameObject is not the special one, DESTROY IT!
		}
	}

	// Use this for initialization
	void Start () {
		activeState = new StartState(); 
		curScene = GameScene.Start; 
		Debug.Log ("in StateManager Start() ");
        activeState.InitializedObjectRefs();
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}

	public void SwitchState(IStateBase newState){//calling the constructor and changes the activeState 
		activeState=newState; //cannot use cases because that is used to switch states in one scene not multiple 
		curScene = newState.Scene;
		Debug.Log ("Add Debug Info");
		//this of places that will help you debug 

	}

	void OnLevelFinishedLoading (Scene scene, LoadSceneMode mode){

		int sceneID = scene.buildIndex;
		if(sceneID == (int)curScene){
			activeState.InitializedObjectRefs();
		}else{
			Debug.Log("Big Problems - Scene & State Mismatch");
			Debug.Log("LevelFinished Loading: scene" + sceneID + "ActiveState Scene Enum:" + activeState.Scene);
		}
	}
}
