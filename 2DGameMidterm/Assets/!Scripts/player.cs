using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    Rigidbody2D Rigidbody;
    public playerValue Player; //ScriptableObject

    // Start is called before the first frame update
    void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(jumpRequest == true && canJump == true)
        {
            Rigidbody.AddForce(Vector2.up * Player.jumpVelocity, ForceMode2D.Impulse);
            jumpRequest = false;
            canJump = false;
        }
        betterGravityForJump();
    }

    //Jump System

    bool jumpRequest = false;
    public void pressJump(InputAction.CallbackContext context)
    {
        if(context.performed == true)
        {
            jumpRequest = true;
        }    
    }

    void betterGravityForJump()
    {
        if(Rigidbody.velocity.y < 0)
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

    }
}
