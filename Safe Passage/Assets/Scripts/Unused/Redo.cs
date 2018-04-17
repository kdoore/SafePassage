using UnityEngine;
using System.Collections;

public class Redo : MonoBehaviour {

	public StateManager manager;
	private bool initialized=false;
	
	private GameData gameData;


	public void initializeObjectRef(){
		if(manager ==null && GameObject.Find ("gameManager") !=null){
			manager=GameObject.Find ("gameManager").GetComponent<StateManager>();
			gameData=GameObject.Find ("gameManager").GetComponent<GameData>();
			
			initialized=true;
		}
	} 

	public void Update () {
		if(!initialized){
			initializeObjectRef();
		}
		
	}
	public void PlayMainGame(){
		
		Debug.Log ("Play Safe Passage"); 
		Debug.Log ("MainGame Things are Happening");//only happens once
		Application.LoadLevel ("Start");
		manager.SwitchState(new StartState());
		
		//StartGame(); 
	}
	
}
