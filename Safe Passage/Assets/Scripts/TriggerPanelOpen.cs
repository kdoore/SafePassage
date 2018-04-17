using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//use to open fadePanel from Animation Event or dialogManager
//Put this script on Animation to be called on Animation Event

//or put this script on FadePanel
public class TriggerPanelOpen : MonoBehaviour {

    [Header("Set in Inspector")]
    public FadePanel fadePanel;

    [Header("Set in Inspector")]
    public DialogManager dialogManager;

	// Use this for initialization
	void Start () {
        if (dialogManager != null)
        {
            Debug.Log("DialogManager is not null");
            dialogManager.onPanelClosing.AddListener(OpenPanel);
        }
	}

    void OpenPanel(){ 
        fadePanel.OpenPanel();
    }
	
	
}
