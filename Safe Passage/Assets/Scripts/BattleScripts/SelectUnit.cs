using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


//added to PlayerParty 
public class SelectUnit : MonoBehaviour {

	public GameObject currentUnit;
    public GameObject target;
	private GameObject actionsMenu;

	void Awake() {
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		if (scene.name == "BattleSP") {
			this.actionsMenu = GameObject.Find ("ActionsMenu");
            if(actionsMenu !=  null){ Debug.Log("found actionsMenu");}
           
            this.target = GameObject.Find("EnemyUnit");  //find single enemy
            this.currentUnit = GameObject.Find("PlayerUnit"); //find single player
			//this.enemyUnitsMenu = GameObject.Find ("EnemyUnitsMenu");
		}
	}

	public void selectCurrentUnit(GameObject unit) {
		this.currentUnit = unit;

		this.actionsMenu.SetActive (true);

		this.currentUnit.GetComponent<PlayerUnitAction> ().updateHUD ();
        Debug.Log("Player Unit activating Menu in SelectUnit");
       
	}

	public void selectAttack(bool physical) {
		this.currentUnit.GetComponent<PlayerUnitAction> ().selectAttack (physical);
        Debug.Log("PlayerUnit Selected Attack, now acting on enemy target");
        this.currentUnit.GetComponent<PlayerUnitAction>().act(target);
		this.actionsMenu.SetActive (false);
		//this.enemyUnitsMenu.SetActive (true);
	}

	public void attackEnemyTarget(GameObject target) {
		this.actionsMenu.SetActive (false);
		//this.enemyUnitsMenu.SetActive (false);
		this.currentUnit.GetComponent<PlayerUnitAction>().act (target);
	}
}
