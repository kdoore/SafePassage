using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {

   public float speed;
   private StateManager manager;
   private bool initialized=false;
   private Rigidbody2D rb2D;
   
   void Awake(){
   	    rb2D = GetComponent<Rigidbody2D>();
		speed= 30.0f;  //initialize
   }

	public void initializeObjectRef(){
		if(manager ==null && GameObject.Find ("GameManager") !=null){
			manager=GameObject.Find ("GameManager").GetComponent<StateManager>();
			//Debug.Log ("manager numStars " + manager.numStars);
			initialized=true;
		}
	}


  void FixedUpdate(){
       if(!initialized){  
       		initializeObjectRef();
       }
       if(initialized){
       		//if(manager.numStars >= 0){
       		//	speed += ( manager.numStars);
       		//} 
       }
         
       float xMove = Input.GetAxis("Horizontal");
       float yMove = Input.GetAxis ("Vertical");
       
       float xSpeed= xMove * speed;
       float ySpeed =yMove * speed;
       
       Vector2 newVelocity = new Vector2(xSpeed, ySpeed);
       
		rb2D.velocity = newVelocity;
       }
}