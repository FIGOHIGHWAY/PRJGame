using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public AudioSource audioSource;
   
    
    public float runSpeed = 40f;
    
    float horizontalMove = 0f;
    bool jump = false;
    // Update is called once per frame
    void Update()
    {
        horizontalMove = SimpleInput.GetAxis("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (horizontalMove != 0){
            if (!audioSource.isPlaying){
                audioSource.Play();
            }
        }
        else{
            audioSource.Stop();
        }

        if (Input.GetButtonDown("Jump")){
            jump = true;
            animator.SetBool("IsJumping",true);
        }

    }
    public void Jump ()
    {
        
        jump = true;
        animator.SetBool("IsJumping",true);
    }

    public void Onlanding ()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate ()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
