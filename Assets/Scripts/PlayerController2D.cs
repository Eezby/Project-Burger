﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    public bool isGrounded;
   
   
    
    [SerializeField]
    Transform groundCheckM;
    [SerializeField]
    Transform groundCheckL;
    [SerializeField]
    Transform groundCheckR;
    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // sends a line from player to grouncheck object position,
        // if line encounters anything on layer "ground", object is considered grounded
        if((Physics2D.Linecast(transform.position, groundCheckM.position, 1 << LayerMask.NameToLayer("Ground"))) ||
           (Physics2D.Linecast(transform.position, groundCheckL.position, 1 << LayerMask.NameToLayer("Ground"))) ||
           (Physics2D.Linecast(transform.position, groundCheckR.position, 1 << LayerMask.NameToLayer("Ground")))) {
                isGrounded = true;
            } else{
                isGrounded = false;
            //  animator.Play("Player_jump");
            }
        // movement right
        if(Input.GetKey("d") || Input.GetKey("right")){
            rb2d.velocity = new Vector2(moveSpeed,rb2d.velocity.y);
            spriteRenderer.flipX = false;
        //  if(isGrounded){
        //  animator.Play("Player_run");}
        }
        
        //movement left
        else if(Input.GetKey("a") || Input.GetKey("left")){
            rb2d.velocity = new Vector2(-moveSpeed,rb2d.velocity.y);
            spriteRenderer.flipX = true;
        //  if(isGrounded){
        //  animator.Play("Player_run");}
        } else{
            rb2d.velocity = new Vector2(0,rb2d.velocity.y);
        //  if(isGrounded){
        //  animator.Play("Player_run");}
        }

        // player jumping
        if(Input.GetKeyDown("space") && isGrounded){
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        //  animator.Play("Player_jump");
        }
    }
}