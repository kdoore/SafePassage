using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{

    private Transform targetTransform;
    private Animator animator;
    private bool thisAIfacingRight = true;
    public PlayerController3 playerController;
    public float xOffset = 1f;
    private float xDistance;
    public float speed = 1f;


    void Start()
    {
        animator = GetComponent<Animator>();
        //look for a gameObj named Player
        //playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController3>();

        //look for gameObj with Tag, Player
        if (playerController == null)
        {
            playerController = GameObject.Find("Player").GetComponent<PlayerController3>();
        }
        //found player - only have 1?  player object...flocking if find the nearest?
        if (playerController != null)
        {
            Debug.Log("Found Player");
        }
        targetTransform = playerController.GetComponent<Transform>();
    }

    void Update()
    {
        xDistance = targetTransform.position.x - transform.position.x;
        if (xDistance < - xOffset)
        {
            // Set the position to the player's position with the offset.
            //transform.position = targetTransform.position + offset;
            //transform.Translate(1 * Time.deltaTime, 0, 0, Space.World);
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            animator.SetInteger("Player_State", (int)Player_State.walk);
        }
        else
        {
            animator.SetInteger("Player_State", (int)Player_State.idle);

        }

        if (xDistance > xOffset)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            animator.SetInteger("Player_State", (int)Player_State.walk);
        }
        else
        {
            animator.SetInteger("Player_State", (int)Player_State.idle);

        }

        //AFTER MOVING, change sprite direction?
        //target is right, thisAI is left
        if (playerController.facingRight && !thisAIfacingRight)
        {
            flip();  //change thisAI to right to match target
        }
        //target is left, thisAI is right
        else if (!playerController.facingRight && thisAIfacingRight)
        {
            flip();      //change thisAI to left to match target
        }
    } //end Update


    //flip sprite between left and right
    void flip()
{
    thisAIfacingRight = !thisAIfacingRight;
    Vector3 theScale = transform.localScale;
    theScale.x *= -1;
    transform.localScale = theScale;
}
}


         
            

       
