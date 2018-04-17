using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Dialog state.
/// This class contains scene-specific logic for transitioning to new scenes
/// Contains code to open a UI-Panel that contains children: 1 UI-Text 
/// and 3 UI-Buttons with logic for leaiving the scene
/// but in this example, the buttons simply modify the displayed text
/// with a message about leaving the scene.
/// 
/// For projects using the StateManager and IStateBase framework
/// This class would inherit from IStateBase
/// This script would not have MonoBehaviour as a base-class
/// This script would not be attached to a GameObject
/// </summary>
public class DialogState : MonoBehaviour {

    DialogManager dialogManager; //use to register for onPanelClosing event

    CanvasGroup cg;
    Button btn1, btn2,closeBtn;
    Text msgText;

	// Use this for initialization
	void Start () {
        InitializeObjectRefs();
	}


    public void InitializeObjectRefs()
    {
        //connect with the dialog panel's cusotm event: onPanelClosing
        //set method to be executed when the event occurs.
        dialogManager = GameObject.Find("ConvPanel").GetComponent<DialogManager>();
        dialogManager.onPanelClosing.AddListener(ShowPanel);

        //the cg attached to this gameObject
        cg = GetComponent<CanvasGroup>();
        Utility.HideCG(cg); //initially, hide the panel

        //find all buttons, set onClick method to be executed
        btn1 = GameObject.Find("Option1Btn").GetComponent<Button>();
        btn1.onClick.AddListener(LoadScene1);
        btn2 = GameObject.Find("Option2Btn").GetComponent<Button>();
        btn2.onClick.AddListener(LoadScene2);
        closeBtn = GameObject.Find("ClosePanelBtn").GetComponent<Button>();
        closeBtn.onClick.AddListener(HidePanel);

        //find the message text, this would not be used, instead, the buttons
        //would take you to a new scene
        msgText = GameObject.Find("MessageText").GetComponent<Text>();
        msgText.text = "";   
    }

    //this happens when the DialogPanel invokes it's event
    //that says the dialog is done
    public void ShowPanel(){
        Utility.ShowCG(cg);
    }

    //hides this panel 
    public void HidePanel()
    {
        msgText.text = "";  //clear the previous message
        Utility.HideCG(cg);
    }

    //would have code to load Scene1 
    public void LoadScene1(){
        msgText.text = "You've pushed Option1-Button";
    }

    //would have code to load Scene1
    public void LoadScene2(){
        msgText.text = "You've pushed Option2-Button";
    }

}
