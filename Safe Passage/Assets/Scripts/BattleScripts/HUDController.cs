using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {

    [SerializeField]
    private Text hudText;
    public Slider playerHealthSlider, enemyHealthSlider;
    public Color green, red, yellow;

	// Use this for initialization
	void Awake () {
        this.hudText = GameObject.Find("HUDText").GetComponent<Text>();
        playerHealthSlider = GameObject.Find("PlayerHealthSlider").GetComponent<Slider>();
        enemyHealthSlider = GameObject.Find("EnemyHealthSlider").GetComponent<Slider>();

    }
	
    public void UpdateHUD(string text){
        hudText.text = text;
    }

    public void updateEnemyHealthHUD(  int enemyHealth)
    {
        Image[] pColor = enemyHealthSlider.GetComponentsInChildren<Image>();
        enemyHealthSlider.value = enemyHealth;
  
        if(enemyHealth< 70){
             pColor[1].color = yellow;
            if (enemyHealth < 40)
            {
                pColor[1].color = red;
            }
         } 
    }
    public void updatePlayerHealthHUD(int playerHealth )
    {   
        Image[] pColor = playerHealthSlider.GetComponentsInChildren<Image>();
          
        playerHealthSlider.value = playerHealth;
        if(playerHealth< 70){
             pColor[1].color = yellow;
            if (playerHealth < 40)
            {
                pColor[1].color = red;
            }
         } 
    }
}
