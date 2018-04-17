using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSetActive : MonoBehaviour {

    //activate GameObject if tagName matches 
    public GameObject enableGameObject;
    public string tagName;
	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.CompareTag(tagName)){
            enableGameObject.SetActive(true);
        }
    }
}
