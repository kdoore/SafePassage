using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// //https://gamedev.stackexchange.com/questions/98251/unity-2d-object-following-target-instead-of-moving-towards-it

public class FollowBehavior : MonoBehaviour {
   
    public GameObject target;
    Animator animator;
    float mobRange;

    void Start(){
        animator = GetComponent<Animator>();
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

        Debug.Log("Total Distance: " + totalDistance);

        FacePlayer(xDistance, totalDistance);
    }

    void FacePlayer(float xDistance, float totalDistance)
    {
        if (xDistance < -0.5)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            if (totalDistance > mobRange)
            {
                transform.Translate(1 * Time.deltaTime, 0, 0, Space.World);
                animator.SetInteger("Player_State", (int)Player_State.idle);
            }
            else
            {
                animator.SetInteger("playerState", 0);
            }

        }
        if (xDistance > 0.5)
        {
            transform.localScale = new Vector3(1, 1, 1);
            if (totalDistance > mobRange)
            {
                transform.Translate(-1 * Time.deltaTime, 0, 0, Space.World);
                animator.SetInteger("Player_State", (int)Player_State.walk);
            }
            else //not moving
            {
                animator.SetInteger("Player_State", (int)Player_State.idle);
            }
        }
    }
}
