using UnityEngine;
using System.Collections;

public class VerticalMoveScript : MonoBehaviour {

	public float speed;
	
	public Vector2 direction;
	public Vector2 position;
	//public int spriteDirection; 
	
	private Vector2 movement;
	private Rigidbody2D  rb2D;
	private Vector3 LowerLeft;
	private Vector3 UpperRight; 
	private float curX, curY;
	//private bool firstPass = true; 
	
	void Start(){
		speed=30f ;
		//spriteDirection=-6; 
		direction = new Vector2(0,-1);
		rb2D=this.GetComponent<Rigidbody2D>();
		LowerLeft=Camera.main.ViewportToWorldPoint(new Vector3(0,0,0));
		UpperRight =Camera.main.ViewportToWorldPoint (new Vector3(Screen.width,Screen.height,0)); 

		curX= transform.localPosition.x;  //read only property
		
		//Debug.Log("lowerLeft.x " + LowerLeft.y);
		
		//Debug.Log ("camera viewPort width " + Camera.main.ViewportToWorldPoint(new Vector3(0,0,0)).x);
	}
	
	
	void FixedUpdate(){
		curY= transform.localPosition.y;  //read only property


		//Debug.Log ("fixed update curX " + curX); 
		

		
		if(curY < LowerLeft.y){
			//speed *= -1;
			//spriteDirection *= -1; 
			Debug.Log ("hit right boundary");
			transform.localPosition= new Vector3(curX,153, 1); 
		}
		movement = new Vector2(
			speed * direction.x,//makes the key move 
			speed * direction.y//makes the key move 
			);
		
		//if we have hit the wall direction = direction * -1;        
		
		// Apply movement to the rigidbody
		
		rb2D.velocity = movement;//assign the movement to the velocity 
	}
}
