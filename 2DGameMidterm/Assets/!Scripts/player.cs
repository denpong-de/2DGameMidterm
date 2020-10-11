﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
        Rigidbody.velocity = new Vector2(Player.runSpeed, Rigidbody.velocity.y);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "coin")
        {
            Player.coinCount++;
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Respawn")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
