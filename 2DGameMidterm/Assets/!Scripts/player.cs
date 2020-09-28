﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{ 
    public playerValue Player; //ScriptableObject

    Rigidbody2D Rigidbody;
    Animator Animator;

    void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        betterGravityForJump();
    }

    //Jump System

    public void pressJump(InputAction.CallbackContext context)
    {
        if(context.performed == true && canJump == true)
        {      
            Rigidbody.AddForce(Vector2.up * Player.jumpVelocity, ForceMode2D.Impulse);
            canJump = false;
            Animator.SetBool("isJump", true);
        }    
    }

    void betterGravityForJump()
    {
        if (Rigidbody.velocity.y < 0)
        {
            Rigidbody.gravityScale = Player.fallMultiply;
        }
        else
        {
            Rigidbody.gravityScale = 1;
        }
    }

    bool canJump;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
        Animator.SetBool("isJump", false);
    }
}
