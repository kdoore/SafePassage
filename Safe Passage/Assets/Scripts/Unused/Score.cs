using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public StateManager manager;
	public GameData gameData;
	public GameSceneManager gameSceneManager;

	public Text FinalScoreTxt;  

	// Use this for initialization
	void Start () {
		gameSceneManager= GetComponent<GameSceneManager>();
		gameData= GameObject.Find ("gameManager").GetComponent<GameData>();


	}
	
	// Update is called once per frame
	void Update () {
		FinalScoreTxt.text= "FINAL SCORE: " + gameData.WarriorScore;
	}
}
