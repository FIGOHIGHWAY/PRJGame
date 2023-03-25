using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{

    public float moveSpeed;

    private Rigidbody2D myRigidbody;

    public bool isWalking;

    public float  walkTime;
    private float walkCounter;
    public float  waitTime;
    private float waitCounter;

    private bool moveRight = true;

    public Animator animator;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        waitCounter = waitTime;
        walkCounter = walkTime;
    }

    void Update()
    {
        if(isWalking){
            animator.SetBool("move", true);
            walkCounter -= Time.deltaTime;

            if(moveRight){
                myRigidbody.velocity = new Vector2 (moveSpeed, 0);
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else{
                myRigidbody.velocity = new Vector2 (-moveSpeed, 0);
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }

            if(walkCounter < 0){
                isWalking = false;
                animator.SetBool("move", false);
                waitCounter = waitTime;
            }
        }

        else{
           animator.SetBool("move", false);
           waitCounter -= Time.deltaTime;

           myRigidbody.velocity = Vector2.zero;

           if(waitCounter < 0){
                moveRight = !moveRight;
                isWalking = true;
                walkCounter = walkTime;
           }
        }
    }
}

