using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class FeaturePanelUI : MonoBehaviour {

    [Header("Set in Inspector")]
	public Character [] characters; 

    public Character curCharacter;

    //UI ELEMENTS
    private Text nameText, skillsText, backstoryText;
    private  Button selectChar, altChar; 
    private  CanvasGroup cg1; 
    private  Image image; 
	  
	// Use this for initialization
	void Start () {
		nameText = GameObject.Find("NameText").GetComponent<Text>(); 
		skillsText = GameObject.Find("SkillText").GetComponent<Text>();
		backstoryText = GameObject.Find("BackstoryText").GetComponent<Text>();
		image = GameObject.Find("CharacterImage").GetComponent<Image>();

		cg1 = GetComponent<CanvasGroup>(); 
	}

	//public void SetCharacter()
	void initializeObjectRefs(){ 
		selectChar=GameObject.Find("SelectButton").GetComponent<Button>();
		selectChar.onClick.AddListener(doSelectButtonThings);

		altChar=GameObject.Find("CharacterBackButton").GetComponent<Button>();
		altChar.onClick.AddListener(doCharacterBackThings); 

	}

	public void UpdateUI(int index){
		curCharacter = characters[index]; 
		nameText.text = curCharacter.name; 
		skillsText.text = curCharacter.skillValue; 
		backstoryText.text = curCharacter.backstory; 
		image.sprite = curCharacter.Sprite; 
		Debug.Log(characters[index].name);

	}

	public void doSelectButtonThings(){

        GameData.instanceRef.activeCharacter = curCharacter; 
	}
	
	public void doCharacterBackThings(){
		
		Debug.Log ("Character Back Things are Happening");//only happens once

		Utility.HideCG(cg1);


	}

	public void DisplayCharacter(int index){
		Debug.Log(characters[index].skill.ToString());
		UpdateUI(index); 

	}


	
}
