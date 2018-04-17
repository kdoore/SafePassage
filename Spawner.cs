//Code Updated 4/12/18 3:30 pm
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    // The prefab we will spawn
    [Header("Set in Inspector")]
    
    public GameObject prefabGood;
    public GameObject ghost;
    //public Transform ghostSpawn;
    // Use this for initialization

    private int pauseTime = 2;//wait 2 sec before starting
    public int numToSpawn = 3;

    public float xRange = 8.0f;
    public float yRangeTop = -2.0f;
    public float yRangeBottom = -3.5f;
    public bool activeSpawning = false;

    void Start()
    {
        StartSpawning(); //call in LevelManager
        activeSpawning = true;
    }

    public void StartSpawning()
    {

        for (int i = 0; i < numToSpawn; i++)
        {
            Invoke("SpawnPrefab", Random.Range(pauseTime, pauseTime * 2.0f));
        }

    }


    public void SpawnPrefab()
    {
        Vector3 position = transform.localPosition;
        position.x = Random.Range(-xRange, xRange);
        position.y = Random.Range(yRangeBottom, yRangeTop);

        float rand = Random.value;
        GameObject item;
        PickUp spawnedItem;

               item = Instantiate(prefabGood, position, transform.rotation);

            //register as a listener for the OnDied event 
            spawnedItem = item.GetComponent<PickUp>();
            spawnedItem.onDied.AddListener(SpawnNewOne);
        }


    public void SpawnGhost(){
        Vector3 position = transform.localPosition;
        Instantiate(ghost, position, transform.rotation);
        Debug.Log("Spawned Ghost");
    }

    //Method to spawn a new object when another PickUp Destroys itself.  
    //Select one of the methods below to either spawn with a delay, or spawn with no delay.  
    //If you spawn with no delay, then it's easier to stop spawning when switching levels, 
    //because no delayed spawning can happen after setting activeSpawning to false.
    public void SpawnNewOne()
    {
        if( GameData.instanceRef.GetPeachCount()>2){
            SpawnGhost();
        }
        if (activeSpawning)
        {
            // SpawnPrefab(); //use this one for no delayed spawning, comment out line below

            Invoke("SpawnPrefab", Random.Range(pauseTime, pauseTime * 2.0f)); //comment out if using code in line above, for spawning with no delay
        }
        Debug.Log("Spawned new prefab");
    }

    //}///end of Class

    ///This method can be called from any other script using the Spawner object, to destroy all spawned objects with Tags as shown.

}////ENd of class