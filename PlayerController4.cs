using UnityEngine;
using System.Collections;

public class PlayerController4 : MonoBehaviour
{

    public enum Player_State  // input parameter signals to send to Animator controller
    {
        idle = 0,
        walk = 1, jump = 2
    }


    private Animator animator;
    private Transform myTransform;
    private Rigidbody2D myRBody2D;
    public float forceX, forceY;
    private bool facingRight;
    private bool _isGrounded = true; // is player on the ground?

    void Awake()
    {
        animator = GetComponent<Animator>();
        myTransform = GetComponent<Transform>();
        myRBody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        facingRight = true;
        forceX = 50f;
        forceY = 250f;
    }

    void Update(){
        // 6 - Make sure we are not outside the camera bounds
        var dist = (transform.position - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).x;

        var rightBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(1, 0, dist)
        ).x;

        var topBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).y;

        var bottomBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 1, dist)
        ).y;

        transform.position = new Vector3(
          Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
          Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
          transform.position.z
        );

    }

    void FixedUpdate()
    {

        if (Input.GetKey("up"))
        {
            if (_isGrounded)
            {
                _isGrounded = false;
                //simple jump code using unity physics
                myRBody2D.velocity = new Vector2(myRBody2D.velocity.x, 0);
                myRBody2D.AddForce(new Vector2(0, forceY));
                //send signal: 1 to animator component: 
                animator.SetInteger("Player_State", (int)Player_State.jump);
            }
            
            }
        }  // end class

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PickUp")){
            Debug.Log("Hit PickuP");

        }
    }



    //--------------------------------------
    // Check if player has collided with the floor
    //--------------------------------------
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Floor")
        {
            _isGrounded = true;

        }

    }
}
