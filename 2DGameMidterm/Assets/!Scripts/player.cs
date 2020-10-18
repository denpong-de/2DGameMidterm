using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{ 
    public playerValue Player; //ScriptableObject

    Rigidbody2D Rigidbody;
    Animator Animator;

    public AudioClip[] audioClips;

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

    //Jump System.

    public void pressJump()
    {
        if(canJump == true)
        {      
            Rigidbody.AddForce(Vector2.up * Player.jumpVelocity, ForceMode2D.Impulse);
            canJump = false;
            Animator.SetBool("isJump", true);
            AudioSource.PlayClipAtPoint(audioClips[0], this.transform.position);
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

    //Collision.

    bool canJump;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
        Animator.SetBool("isJump", false);
        Player.BeforeDeadPosition = collision.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "coin")
        {
            Player.coinCount++;
            gameEvent.current.CoinTriggerEnter();
            AudioSource.PlayClipAtPoint(audioClips[1], collision.transform.position);
            Destroy(collision.gameObject);
        }
        if (collision.tag == "enemy")
        {
            Player.HealthPoint--;

            AudioSource.PlayClipAtPoint(audioClips[2], collision.transform.position);
            if (Player.HealthPoint <= 0)
            {
                gameEvent.current.RespawnTriggerEnter();
            }
            else
            {
                gameEvent.current.EnemyTriggerEnter();
            }
        }
        if (collision.tag == "Respawn")
        {
            gameEvent.current.RespawnTriggerEnter();
        }
    }
}
