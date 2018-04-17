using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	public float TotalHP;
	public float CurrentHP;

	// Use this for initialization
	void Start () {
	CurrentHP = TotalHP;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)){
			TakeDamage(); 
		}
	}

	void TakeDamage(){
		CurrentHP -=5; 
		transform.localScale = new Vector3((CurrentHP/TotalHP),1,1); 
	}
}
