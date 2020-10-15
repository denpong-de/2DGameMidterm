﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenuController : MonoBehaviour
{
    public playerValue gameValues; //ScriptableObject

    Animator playerAnimator;
    Animator transitionAnimator;
    Rigidbody2D Rigidbody;

    public GameObject player;
    public GameObject buyTransition;
    public Canvas buyFade;
    public Text myCoinTXT;
    public Image[] menuHearts;

    private bool isStart;
    private int myCoin;

    private void Awake()
    {
        playerAnimator = player.GetComponent<Animator>();
        transitionAnimator = buyTransition.GetComponent<Animator>();
        Rigidbody = player.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        gameValues.HealthPoint = 1;
        myCoin = PlayerPrefs.GetInt("MyCoin");

        if (gameValues.playAgain)
        {
            startBuying();
            gameValues.playAgain = false;
        }
    }

    private void FixedUpdate()
    {
        if (isStart == true)
        {
            Rigidbody.velocity = new Vector2(gameValues.runSpeed, Rigidbody.velocity.y);
        }
    }

    //Button Behavior.

    public void Play()
    {
        StartCoroutine(playerRunning());
    }

    public void startGame()
    {
        PlayerPrefs.SetInt("MyCoin", myCoin);
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void buyHealth()
    {
        if(myCoin >= gameValues.healthPrice && gameValues.HealthPoint < 5)
        {
            gameValues.HealthPoint++;
            menuHearts[(gameValues.HealthPoint - 2)].gameObject.SetActive(true);
            myCoin = myCoin - gameValues.healthPrice;
            myCoinTXT.text = ("" + myCoin);
        }
        else
        {
            Debug.Log("You don't have enough coin!");
        }
    }

    IEnumerator playerRunning()
    {
        //Running Animation Start.
        playerAnimator.SetTrigger("isStart");
        isStart = true;

        yield return new WaitForSeconds(1.1f);

        //Running Animation Stop.
        isStart = false;
        Rigidbody.velocity = Vector3.zero;

        startBuying();
    }

    private void startBuying()
    {
        transitionAnimator.SetTrigger("isBuying");

        buyFade.gameObject.SetActive(true);
        myCoinTXT.text = ("" + myCoin);
    }
}