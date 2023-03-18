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

    private int WalkDirection;

    public Animator animator;
					
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        waitCounter = waitTime;
        walkCounter = walkTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(isWalking){
            animator.SetBool("move", false);
            walkCounter -= Time.deltaTime;

            switch (WalkDirection)
            {
            case 0:
                Flipright();
                myRigidbody.velocity = new Vector2 (moveSpeed, 0);
                animator.SetBool("move", true);
                break;
            
            case 1:
                Flipleft();
                myRigidbody.velocity = new Vector2 (-moveSpeed, 0);
                animator.SetBool("move", true);
                break;

            }

            if(walkCounter < 0){
                isWalking = false;
                animator.SetBool("move", false);
                waitCounter = waitTime;
            }
        }
        
        else
        {
           waitCounter -= Time.deltaTime;

           myRigidbody.velocity = Vector2.zero;

           if(waitCounter < 0){
                ChooseDirection();
           }
        }
    }

    public void ChooseDirection(){
        WalkDirection = Random.Range (0,4);
        isWalking = true;
        walkCounter = walkTime;
    }
    private void Flipleft()
	{
		transform.localRotation = Quaternion.Euler(0, 180, 0);
	}
    private void Flipright()
	{
		transform.localRotation = Quaternion.Euler(0, 0, 0);
	}
}
