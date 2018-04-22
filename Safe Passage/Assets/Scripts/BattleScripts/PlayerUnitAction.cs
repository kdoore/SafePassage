using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerUnitAction : MonoBehaviour {

	[SerializeField]
	private GameObject physicalAttack;

	[SerializeField]
	private GameObject peachAttack;

	private GameObject currentAttack;

	[SerializeField]
	private HUDController hudController;

    //[TextArea]
    //public List<string> playerActionText;


	void Awake () {
        this.hudController = GameObject.Find("HUDPanel").GetComponent<HUDController>();
		this.physicalAttack = Instantiate (this.physicalAttack, this.transform) as GameObject;
		this.peachAttack = Instantiate (this.peachAttack, this.transform) as GameObject;

		this.physicalAttack.GetComponent<AttackTarget> ().owner = this.gameObject;
		this.peachAttack.GetComponent<AttackTarget> ().owner = this.gameObject;

		this.currentAttack = this.physicalAttack;  //physical is default

       
	}

    void Start()
    {
        UnitStats unitStats = GetComponent<UnitStats>();
        if (unitStats != null)
        {
            int health = (int)unitStats.health;
            hudController.updatePlayerHealthHUD(health);
        }
    }

	public void selectAttack(bool physical) {
		this.currentAttack = (physical) ? this.physicalAttack : this.peachAttack;
        Debug.Log("PlayerUnit selecting attack - physical? " + physical);
        if (physical)
        {
            hudController.UpdateHUD("You have selected to Attack");
        
        }else{
            hudController.UpdateHUD("You have selected to use peaches or run");
        }
    }

	public void act(GameObject target) {
		this.currentAttack.GetComponent<AttackTarget> ().hit (target);
        Debug.Log("PlayerUnit attacking enemy, calling AttackTarget.hit");
        UnitStats targetStats = target.GetComponent<UnitStats>();
        int health = (int)targetStats.health;
        hudController.UpdateHUD("You have attacked the villian, his health decreased " +  health);
        hudController.updateEnemyHealthHUD(health);
    }

	public void updateHUD() {
        //Update - show when 
        hudController.UpdateHUD("What will you do?") ;
        Debug.Log("Update Player HUD HealthBar and Face");
    }
}
