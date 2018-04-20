using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// //https://gamedev.stackexchange.com/questions/98251/unity-2d-object-following-target-instead-of-moving-towards-it

public class FollowBehavior : MonoBehaviour {
   
    public PlayerController3 target;
    Animator animator;
    float mobRange;
    bool facingRight;


    void Start(){
        animator = GetComponent<Animator>();
        mobRange = 2f;
        facingRight = true;

    }

    void Update(){
        TotalDistance();
    }

    void TotalDistance()
    {
        var testX = transform.position.x;
        var testY = transform.position.y;

        var pTestX = target.transform.position.x;
        var pTestY = target.transform.position.y;

        var xDistance = testX - pTestX;
        var yDistance = testY - pTestY;

        var totalDistance = Mathf.Pow(xDistance, 2) + Mathf.Pow(yDistance, 2);
        totalDistance = Mathf.Sqrt(totalDistance);

        FacePlayer(xDistance, totalDistance);
    }

    //function takes in distance to Player along X, total Distance to travel to get to player?
    void FacePlayer(float xDistance, float totalDistance)
    {
        if (xDistance < - 0.5) //thisAI is Moving to Left along X 
        {
           
            //target just started facing left, but followers still facing right
          
            if (totalDistance > mobRange)
            {
                transform.Translate(1 * Time.deltaTime, 0, 0, Space.World);
                animator.SetInteger("Player_State", (int)Player_State.walk);
                 //target facing left, 
                if (!target.facingRight && facingRight)//target turned left, thisAI needs to turn left
                {
                    //Invoke("flip", Random.Range(.5f, 2f)); //give a 1 second pause
                    flip();
                    Debug.Log("Fipped Left");
                }
            }
            else
            {
                animator.SetInteger("Player_State", (int)Player_State.idle);

            }

        }
        if (xDistance > 0.5)
        {
           // transform.localScale = new Vector3(1, 1, 1);
            if (totalDistance > mobRange)
            {
                
                transform.Translate(-1 * Time.deltaTime, 0, 0, Space.World);
                animator.SetInteger("Player_State", (int)Player_State.walk);
                if (target.facingRight && !facingRight)
                {
                   // Invoke("flip", Random.Range(.5f, 2f)); //give a 1 second pause
                    //Debug.Log("Fipped Right");
                }
            }
            else //not moving
            {
                animator.SetInteger("Player_State", (int)Player_State.idle);
            }
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
