using UnityEngine;
using System.Collections;

public enum Player_State  // input parameter signals to send to Animator controller
{
    idle = 0,
    walk = 1
}


public class PlayerController3 : MonoBehaviour
{
    
    public FreeParallax parallax;
	private Animator animator;
	private Transform myTransform;
	private Rigidbody2D myRBody2D;
	public float forceX;
	private bool facingRight;
    public float speed= 2.0f;  //initialize

	void Awake ()
	{
		animator = GetComponent<Animator> ();
		myTransform = GetComponent<Transform> ();
		myRBody2D = GetComponent<Rigidbody2D> ();
        parallax =  Object.FindObjectOfType<FreeParallax>();
	}

	void Start ()
	{
		animator.SetInteger ("Player_State", (int)Player_State.idle);
		facingRight = true;
		forceX = 50f;
	}



	void FixedUpdate ()
	{
		float inputX = Input.GetAxis ("Horizontal");
		bool isWalking = Mathf.Abs (inputX) > 0;  // is there horizontal input 

		if (isWalking) {

			//send signal: 1 to animator component: 
			animator.SetInteger ("Player_State", (int)Player_State.walk);

			if (inputX > 0 && !facingRight) {
				flip (); // flip right
			}
			if (inputX < 0 && facingRight) {
				flip (); // flip left
			}
			myRBody2D.velocity = new Vector2 (0, 0);  // reset velocity to 0
			
            //myRBody2D.AddForce (new Vector2 (forceX * inputX, 0));  ///move with force


            float xSpeed = inputX * speed;

            Vector2 newVelocity = new Vector2(xSpeed, 0);

            myRBody2D.velocity = newVelocity;


            if (parallax != null){ //have parallax go in opposite direction
               parallax.Speed = -myRBody2D.velocity.x;
              // Debug.Log("Parallax Speed is what?" + parallax.Speed);
            }



		} else { // not walking - reset to idle
			//send signal: 0 to animator component: 
			animator.SetInteger ("Player_State", (int)Player_State.idle);
            myRBody2D.velocity = new Vector2(0, 0);  // reset velocity to 0 
           if (parallax != null)
           {
                parallax.Speed = 0f; //stop parallax when player stops
            }
        }
	} // end FixedUpdate

    void OnTriggerEnter2D(Collider2D hitObject)
    {
        if (hitObject.CompareTag("PickUp"))
        {
            Debug.Log("Hit PickuP");
            PickUp item = hitObject.GetComponent<PickUp>();
            GameData.instanceRef.Add(item);
            item.DestroyMe();
        }
    }

	//flip the animation left or right facing using Scale.x
	void flip ()
	{
		facingRight = !facingRight;
		Vector3 theScale = myTransform.localScale;
		theScale.x *= -1;
		myTransform.localScale = theScale;
	}

}  // end class