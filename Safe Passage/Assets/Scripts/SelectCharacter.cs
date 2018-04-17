using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour {

    private Button  button9,button10,button11,button12, button13, button14,button15; 
    private CanvasGroup cgPlayerPanel,cgCharacterPanel; 
   

    //private Character selectedCharacter;
    //private Character[] characters;
	
    private FeaturePanelUI featurepanel1; 


    // Use this for initialization
	void Start () {
        button9 = GameObject.Find("Player1Button").GetComponent<Button>();
        button9.onClick.AddListener(doPlayer1ButtonThings);

        button10 = GameObject.Find("Player2Button").GetComponent<Button>();
        button10.onClick.AddListener(doPlayer2ButtonThings);

        button11 = GameObject.Find("Player3Button").GetComponent<Button>();
        button11.onClick.AddListener(doPlayer3ButtonThings);

        button12 = GameObject.Find("Player4Button").GetComponent<Button>();
        button12.onClick.AddListener(doPlayer4ButtonThings);

        button13 = GameObject.Find("CharacterBackButton").GetComponent<Button>();
        button13.onClick.AddListener(doChoice1Things);

        featurepanel1 = GameObject.Find("CharacterPanel").GetComponent<FeaturePanelUI>();
        cgPlayerPanel=GameObject.Find("PlayerPanel").GetComponent<CanvasGroup>();

        cgCharacterPanel=GameObject.Find("CharacterPanel").GetComponent<CanvasGroup>();

	}
	
    public void doChoice1Things()
    {
        Debug.Log("Choice 1 Things are Happening"); //only happens once
        Utility.HideCG(cgCharacterPanel);                                            //hide invitationPanel
        Utility.ShowCG(cgPlayerPanel);

    }


    public void doPlayer1ButtonThings()
    {
        //selectedCharacter = characters[0];

        Utility.ShowCG(cgCharacterPanel);
        featurepanel1.DisplayCharacter(0);
        //Debug.Log("Player1Button Things are Happening");//only happens once

    }

    public void doPlayer2ButtonThings()
    {
        //selectedCharacter = characters[1];
        //Debug.Log ("Player2Button Things are Happening");//only happens once
        Utility.ShowCG(cgCharacterPanel);
        featurepanel1.DisplayCharacter(1);

    }

    public void doPlayer3ButtonThings()
    {
       // selectedCharacter = characters[2];
        //Debug.Log ("Player3Button Things are Happening");//only happens once

        Utility.ShowCG(cgCharacterPanel);
        featurepanel1.DisplayCharacter(2);

    }

    public void doPlayer4ButtonThings()
    {
        //selectedCharacter = characters[3];
        Debug.Log("Player2Button Things are Happening");//only happens once

        Utility.ShowCG(cgCharacterPanel);
        featurepanel1.DisplayCharacter(3);

    }

    public void doPlayer5ButtonThings()
    {
       // selectedCharacter = characters[4];
        Debug.Log("Player5Button Things are Happening");//only happens once

        Utility.ShowCG(cgCharacterPanel);
        featurepanel1.DisplayCharacter(4);

    }

   


}
