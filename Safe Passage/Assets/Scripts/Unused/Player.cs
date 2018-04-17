using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	
	//private bool carryingStar=false;
	private bool initialized=false;
	//public int starScore=0;
	//public int numStars;
    private StateManager manager;
    private GameData gameData;
	//public GameObject level1GameObjects, level2GameObjects; 
	
	
	void Start(){
	    //  UpdateStarText();
	     
	}

    void OnTriggerEnter2D(Collider2D hit){
        if(hit.CompareTag("PickUp")){
                PickUp item = hit.GetComponent<PickUp>();
			    gameData.Add(item);
                Debug.Log ("on trigger pickup"  + item.type );
                gameData.UpdateWarriorData();
                Destroy(hit.gameObject);
        
        }else if(hit.CompareTag ("Arrow")){
        		gameData.lives--;
        		gameData.arrows++;
        		Debug.Log ("on trigger " + gameData.lives);
        		Destroy(hit.gameObject);

			if (gameData.lives ==0 ){
				Debug.Log ("Battle Game Over"); //new level is created 
				Debug.Log ("begin state end activated"); 
				Application.LoadLevel ("Battle Game End");
				manager.SwitchState(new BattleGameEndState(manager));
			}
				
        
        }
    }
    public void initializeObjectRef(){
		if(manager ==null && GameObject.Find ("gameManager") !=null){
		manager=GameObject.Find ("gameManager").GetComponent<StateManager>();
		gameData=GameObject.Find ("gameManager").GetComponent<GameData>();
		
		initialized=true;
		}
    }
    
    public void Update(){
    	if(!initialized){
    	 	initializeObjectRef();
    	}
    }
  

}