using UnityEngine;
using System.Collections;

public class AttackTarget : MonoBehaviour {

	public GameObject owner;

	//[SerializeField]
	//private string attackAnimation;
    TurnSystem turnSystem;

	[SerializeField]
	private bool peachAttack;

	[SerializeField]
	private float peachCost;

	[SerializeField]
	private float minAttackMultiplier;

	[SerializeField]
	private float maxAttackMultiplier;

	[SerializeField]
	private float minDefenseMultiplier;

	[SerializeField]
	private float maxDefenseMultiplier;

    private void Start()
    {
        turnSystem = GameObject.Find("TurnSystem").GetComponent<TurnSystem>();
    }
 

    public void hit(GameObject target) {
		UnitStats ownerStats = this.owner.GetComponent<UnitStats> ();
		UnitStats targetStats = target.GetComponent<UnitStats> ();
		
        if (ownerStats.peaches >= this.peachCost) { //check player peach vs peachCost? 
            Debug.Log("Attack Happening");
			float attackMultiplier = (Random.value * (this.maxAttackMultiplier - this.minAttackMultiplier)) + this.minAttackMultiplier;
			
            //is it a peachAttack?  if so, we should improve player's health based on using peaches
            //calculate damage, infllict on target
            float damage = (this.peachAttack) ? attackMultiplier * ownerStats.peaches : attackMultiplier * ownerStats.attack;

			float defenseMultiplier = (Random.value * (this.maxDefenseMultiplier - this.minDefenseMultiplier)) + this.minDefenseMultiplier;
			damage = Mathf.Max(0, damage - (defenseMultiplier * targetStats.defense));
            Debug.Log("Attack Damage " + damage);
			targetStats.receiveDamage (damage);

			ownerStats.peaches -= this.peachCost;

            Debug.Log("AttackTarget, Call TurnSystem.nextTurn?");

            turnSystem.DelayedNextTurn();
		}
	}
}
