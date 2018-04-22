using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class BattleGameState: IStateBase{
     
  
	private GameScene scene; 
	//public CanvasGroup cg1; 
	//private string newline = System.Environment.NewLine;

	public GameScene Scene{
		get{return scene;}
	}

	
	public BattleGameState(){
		this.scene = GameScene.BattleGame;
		Debug.Log ("constructor for BattleGameState");
	}
	
	public void InitializedObjectRefs(){ 
			 
		
	}

	
}

