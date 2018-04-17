using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class BattleGameState: IStateBase{

	private  StateManager manager;
	private GameData gameData;
	//public float Timer; 
	
	private Text scoreText;
	
	private bool initialized=false;

	private GameScene scene; 
	//public CanvasGroup cg1; 
	//private string newline = System.Environment.NewLine;

	public GameScene Scene{
		get{return scene;}
	}

	
	public BattleGameState(){
		this.scene = GameScene.BattleGame;
		this.gameData=manager.gameData;
		Debug.Log ("constructor for gameState");
	}
	
	public void InitializedObjectRefs(){ 
		if(scoreText ==null && GameObject.Find("ScoreText") !=null){
			scoreText=GameObject.Find("ScoreText").GetComponent<Text>();
			Debug.Log ("found score text");
			initialized=true;
		}
	}

	public void ShowIt(){
		//Debug.Log ("show it battle game");
	}
	
}

