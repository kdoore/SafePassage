using UnityEngine;

/// <summary>
/// Simply moves the current game object
/// </summary>
public class MoveScript : MonoBehaviour
{
	// 1 - Designer variables
	
	
	//private Rigidbody2D rigidbody2D;
	/// <summary>
	/// Moving direction
	/// </summary>
	public float speed;

	public Vector2 direction;
	public Vector2 position;
	public float spriteDirection;
	private Vector2 movement;
	private Rigidbody2D  rb2D;
	private Vector3 LowerLeft;
	private Vector3 UpperRight;
	private float curX;
	private bool firstPass=true;
	
	void Start(){
			speed=20f ;
			spriteDirection= transform.localScale.x;  //what is the initial value of scale
			direction = new Vector2(-1, 0);///direction to move the object
			
			rb2D=this.GetComponent<Rigidbody2D>();
			LowerLeft=Camera.main.ScreenToWorldPoint(new Vector3(0,0,0));
			UpperRight=Camera.main.ScreenToWorldPoint (new Vector3(Screen.width, Screen.height, 0));
			
			Debug.Log("lowerLeft.x " + LowerLeft.x);
			//Debug.Log ("camera viewPort width " + Camera.main.ViewportToWorldPoint(new Vector3(0,0,0)).x);
			Debug.Log ("UpperRight.x " + UpperRight.x); 

	}
	
	
	void FixedUpdate()
	{
		curX= transform.localPosition.x;  //read only property
		
		if(curX < LowerLeft.x){
		     speed *= -1;
		     Debug.Log ("hit left boundry"  + curX);
		     spriteDirection *= -1;
		     firstPass=false;
		     transform.localScale = new Vector3(spriteDirection, -27 , 1);
		}
		else if(curX > UpperRight.x  && !firstPass){
			speed *= -1;
			Debug.Log ("hit right boundry");
			spriteDirection *= -1;
			transform.localScale = new Vector3(spriteDirection, 27 , 1);
		 	
		
		 }
		movement = new Vector2(
				speed * direction.x,
				speed * direction.y
				);
		
	   //if we have hit the wall direction = direction * -1;		
	
		// Apply movement to the rigidbody
		
		rb2D.velocity = movement;
	}
}
