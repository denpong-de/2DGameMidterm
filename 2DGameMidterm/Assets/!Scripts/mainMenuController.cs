using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuController : MonoBehaviour
{
    public playerValue gameValue; //ScriptableObject

    Animator animator;
    Rigidbody2D Rigidbody;

    public GameObject player;
    private bool isStart;

    private void Awake()
    {
        animator = player.GetComponent<Animator>();
        Rigidbody = player.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (isStart)
        {
            Rigidbody.velocity = new Vector2(gameValue.runSpeed, Rigidbody.velocity.y);
        }

    }

    //Button Behavior.

    public void Play()
    {
        StartCoroutine(playerRunning());
    }

    IEnumerator playerRunning()
    {
        animator.SetTrigger("isStart");
        isStart = true;
        yield return new WaitForSeconds(1.5f);
        isStart = false;
        SceneManager.LoadScene(1);
    }
}
