using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class TurnSystem : MonoBehaviour {

	private List<UnitStats> unitsStats;

	private GameObject playerParty;

	public GameObject enemyEncounter;

	[SerializeField]
	private GameObject actionsMenu;

	void Start() {
		this.playerParty = GameObject.Find ("PlayerParty");
        if(playerParty == null){
            Debug.Log("turn system, didn't find playerParyt");
        }
		unitsStats = new List<UnitStats> ();
        //find all players, 
		GameObject[] playerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");
		foreach (GameObject playerUnit in playerUnits) {
			UnitStats currentUnitStats = playerUnit.GetComponent<UnitStats> ();
			currentUnitStats.calculateNextActTurn (0);
			unitsStats.Add (currentUnitStats);
           
		} //find enemies
		GameObject[] enemyUnits = GameObject.FindGameObjectsWithTag("EnemyUnit");
		foreach (GameObject enemyUnit in enemyUnits) {
			UnitStats currentUnitStats = enemyUnit.GetComponent<UnitStats> ();
			currentUnitStats.calculateNextActTurn (1);
			unitsStats.Add (currentUnitStats);
          
		}
		unitsStats.Sort (); //sort by who's turn will be next

		this.actionsMenu.SetActive (false);
       
		

		this.nextTurn ();///STARTS GAME
	}

	public void nextTurn() {
		//find enemies
        GameObject[] remainingEnemyUnits = GameObject.FindGameObjectsWithTag ("EnemyUnit");
		if (remainingEnemyUnits.Length == 0) { //if all enemies dead, collectc reward
			this.enemyEncounter.GetComponent<CollectReward> ().collectReward ();
            Debug.Log("No Enemies, player wins, Collect Reward on attack win?");
           // Debug.Log("No Enemies, player wins, now what?");
			//SceneManager.LoadScene ("Town");
		}
        //find players
		GameObject[] remainingPlayerUnits = GameObject.FindGameObjectsWithTag ("PlayerUnit");
		if (remainingPlayerUnits.Length == 0) {
            Debug.Log("No Players, player loses, now what //Change scenes?");
			//SceneManager.LoadScene("Title");
		}

		UnitStats currentUnitStats = unitsStats [0]; //get turn-taker's stats
        Debug.Log("Taking turn ? who's turn? - game not over");
		unitsStats.Remove (currentUnitStats); //as it's currently active, remove from list to act?

		if (!currentUnitStats.isDead ()) { //current is not dead now
			GameObject currentUnit = currentUnitStats.gameObject;

			currentUnitStats.calculateNextActTurn (currentUnitStats.nextActTurn);
			unitsStats.Add (currentUnitStats); //add back to end of list
			unitsStats.Sort (); //sort so we know who's turn is next

			if (currentUnit.tag == "PlayerUnit") {
				this.playerParty.GetComponent<SelectUnit> ().selectCurrentUnit (currentUnit.gameObject);
                Debug.Log("Find ActivePlayer, activate player attack Menus to act on action");
                this.actionsMenu.SetActive(true);
            
            } else { 
                Debug.Log("CurrentUnit - is not PlayerUnit, enemy's turn to take act");
                this.actionsMenu.SetActive(false);
				currentUnit.GetComponent<EnemyUnitAction> ().act ();
			}
		} else {
			this.nextTurn ();
		}
	}

    public void DelayedNextTurn(){
        Invoke("nextTurn", 2);
        Debug.Log("invoked delayed next turn");
    }
}
