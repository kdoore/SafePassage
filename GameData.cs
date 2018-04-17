using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

//An instance of this object is attached to the GameManager Object, so this is also uses singleton pattern
public class GameData : MonoBehaviour {

	public static GameData instanceRef;  //singleton reference
    public UnityEvent onPlayerDataUpdate;

    public int WarriorScore=0;  //total SpaceGirl game score
    public int WarriorHighScore;    //previous HighScore
	
	public int lives;
	public int arrows;
	public string playerName;
	 
	public Character activeCharacter; 
	public Dictionary<PickUpType, int> inventory = new Dictionary<PickUpType, int>();
    
    //dictionary is a 'generic' collection - we must specify the data-type of both the key and the value.
	/// <summary>
	/// inventory Dictionary   ///public enum PickUpType { Star, Key, Heart, Snowflake}
	/// This dictionary will store the total point value: (sum) for each type of pickup.  Since each pickup
	/// can vary in value, we access the PickUp Object's .value property to determine how many points to add to the
	/// that pickup sum total
	/// when a collision occurs.
	/// we also add this to the total player score
	/// </summary>
	
	void Awake(){  
        
		if(instanceRef == null){
            instanceRef=this;
			Debug.Log ("Create gameDataInstance");
		}
		else{
			Debug.Log ("New Instance of GameData Singleton Created");
		}

        if(onPlayerDataUpdate == null){
            onPlayerDataUpdate = new UnityEvent();
        }
		//store SpaceGirlHighScore in PlayerPrefs dictionary
	 if(PlayerPrefs.HasKey("WarriorHighScore")){ //testing for the key: does the key already exist
	         WarriorHighScore = PlayerPrefs.GetInt("WarriorHighScore"); //getting the value
	         Debug.Log ("get player prefs high score " + WarriorHighScore);
	   } else {
			WarriorHighScore = 0;
	         PlayerPrefs.SetInt("WarriorHighScore", WarriorHighScore);  //set initial value
	   }
	}
	

	public void UpdateWarriorData(){
		if(WarriorScore > WarriorHighScore){
			PlayerPrefs.SetInt("WarriorHighScore", WarriorScore);
			Debug.Log ("reset high score");
		}
	}

	public void Add(PickUp pickup){
		PickUpType type = pickup.type;
		int oldTotal = 0;

		if(inventory.TryGetValue(type, out oldTotal))
            inventory[type] = oldTotal + pickup.value ;  //use key as index
		else
            inventory.Add (type, pickup.value);  //how much does each pickup count for
		
		WarriorScore += pickup.value;
        UpdateWarriorData(); //see if this is now the high score to reset Player Prefs 

        if (onPlayerDataUpdate != null)
        {
            onPlayerDataUpdate.Invoke();
        }
     }

    public int GetPeachCount(){
        int count = 0;
        inventory.TryGetValue(PickUpType.Peach, out count);
        return count;
    }

} //end GameData
