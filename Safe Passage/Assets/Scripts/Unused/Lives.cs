using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Lives : MonoBehaviour {

	public StateManager manager;
	public GameData gameData;
	public GameSceneManager gameSceneManager;

	public Text LivesTxt;  

	// Use this for initialization
	void Start () {
		gameSceneManager= GetComponent<GameSceneManager>();
		gameData= GameObject.Find ("gameManager").GetComponent<GameData>();


	}
	
	// Update is called once per frame
	void Update () {
		LivesTxt.text= "LIVES: " + gameData.lives;
	}
}
