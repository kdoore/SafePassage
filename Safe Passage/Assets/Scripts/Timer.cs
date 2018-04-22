using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    GameSceneManager gameSceneManager;
	public float seconds,minutes; 

	public Text levelTxt; 

	void Start(){
        	levelTxt.text= "LEVEL 1";
        gameSceneManager = GameObject.Find("GameManager").GetComponent<GameSceneManager>();
	}


    // Update is called once per frame
    void Update()
    {   minutes = (int)(Time.timeSinceLevelLoad / 60f);
        seconds = (int)(Time.timeSinceLevelLoad % 60f);

        if (GameData.instanceRef.lives > 0) { 
            if (seconds == 20f)
            {
                levelUp();
             }else if (seconds == 40f)
            {
            Debug.Log("winnner!"); //new level is created 
            Winner();
            }
        }

	}

	public void levelUp(){
		gameSceneManager.currentMode = GameMode.level2;
		Debug.Log ("level 2 activated"); 
		levelTxt.text = "LEVEL 2" ; 	
	}

	public void Winner(){ 
		Debug.Log ("begin state end activated"); 
		SceneManager.LoadScene ("Battle Game Win");
		StateManager.instanceRef.SwitchState(new BattleGameWinState( ));	
		
	}

}
