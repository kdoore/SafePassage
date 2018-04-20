using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSimpleDialog : MonoBehaviour {

    public SimpleDialogManager dialogManager;

	// Use this for initialization
	void Start () {
        GameObject dialogObj = GameObject.Find("SimpleDialogPanel");
        if(dialogObj != null){
            dialogManager = dialogObj.GetComponent<SimpleDialogManager>();
            Debug.Log("found dialog");
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            Debug.Log("player triggers dialog");
            dialogManager.openDialog();
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
