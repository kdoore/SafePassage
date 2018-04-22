using UnityEngine;
using System.Collections;

public class EnemyUnitAction : MonoBehaviour {

	[SerializeField]
	private GameObject attack;

	[SerializeField]
	private string targetsTag;


    [SerializeField]
    private HUDController hudController;


	void Awake () {
		this.attack = Instantiate (this.attack);
        this.hudController = GameObject.Find("HUDPanel").GetComponent<HUDController>();
    
		this.attack.GetComponent<AttackTarget> ().owner = this.gameObject;
	}

    void Start()
    {
        UnitStats unitStats = GetComponent<UnitStats>();
        if (unitStats != null)
        {
            int health = (int)unitStats.health;
            hudController.updateEnemyHealthHUD(health);
        }
    }

	GameObject findRandomTarget() {
		GameObject[] possibleTargets = GameObject.FindGameObjectsWithTag (targetsTag);

		if (possibleTargets.Length > 0) {
			int targetIndex = Random.Range (0, possibleTargets.Length);
			GameObject target = possibleTargets [targetIndex];

			return target;
		}

		return null;
	}

	public void act() {
        Debug.Log("Enemy Attacking - Need to setup list of enemy attacks");
		GameObject target = findRandomTarget ();
		this.attack.GetComponent<AttackTarget> ().hit (target); //enemy  needs attack
        UnitStats targetStats = target.GetComponent<UnitStats>();
        int health = (int)targetStats.health;
        hudController.UpdateHUD("You have been Attacked by the Villian, your health decreased " +  health);
        hudController.updatePlayerHealthHUD(health);
    }
}
