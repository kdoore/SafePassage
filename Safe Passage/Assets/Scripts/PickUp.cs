using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public enum PickUpType { Peach }

public class PickUp : MonoBehaviour {

	public PickUpType type;
	public int value;

    public UnityEvent onDied;
    

    void Start()
    {
        //initialize the UnityEvent by calling the constructor
        if (onDied == null)
        {
            onDied = new UnityEvent();
        }

        Invoke("DestroyMe", Random.Range(5, 9));
    }



    public void DestroyMe() //executed by Animation-Trigger
    {
        //if there are any registered listeners,
        //then broadcast / publish the event
        if (onDied != null)
        {
            onDied.Invoke(); //tells the Spawner it has died so a new item can be spawned
            Debug.Log("Invoked event when PickUp died");
            onDied.RemoveAllListeners(); //remove spawner's registration/ listener connection
        }
        //Debug.Log("Item Destroy Me");
        Destroy(gameObject);
    }

}
