using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

  

    void OnTriggerEnter2D(Collider2D hit){
        if(hit.CompareTag("PickUp")){
                PickUp item = hit.GetComponent<PickUp>();
			    GameData.instanceRef.Add(item);
                Debug.Log ("on trigger pickup"  + item.type );
                GameData.instanceRef.UpdateWarriorData();
                Destroy(hit.gameObject);
        
        }else if(hit.CompareTag ("Arrow")){
                GameData.instanceRef.lives--;
                GameData.instanceRef.arrows++;
                Debug.Log ("on trigger " + GameData.instanceRef.lives);
        		Destroy(hit.gameObject);

            if (GameData.instanceRef.lives ==0 ){
				Debug.Log ("Battle Game Over"); //new level is created 
				Debug.Log ("begin state end activated"); 
				SceneManager.LoadScene ("Battle Game End");
				StateManager.instanceRef.SwitchState(new BattleGameEndState( ));
			}
				
        
        }
    }

}