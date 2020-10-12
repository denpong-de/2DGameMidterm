using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    public playerValue gameValues; //ScriptableObject
    public GameObject player;
    public Text[] texts;
    public Button[] buttons;
    public Canvas resultCanv;

    private void Start()
    {
        gameValues.coinCount = 0;

        gameEvent.current.onCoinTriggerEnter += OnCoinCountUpdate;
        gameEvent.current.onRespawnTriggerEnter += OnResultScreenOpen;
    }

    //onCoinTriggerEnter listener.

    private void OnCoinCountUpdate()
    {
        texts[0].text = ("" + gameValues.coinCount);
    }

    //onRespawnTriggerEnter listener.

    private int myCoin;
    private void OnResultScreenOpen()
    {
        Time.timeScale = 0;

        PlayerPrefs.SetInt("MyCoin", PlayerPrefs.GetInt("MyCoin") + gameValues.coinCount);
        myCoin = PlayerPrefs.GetInt("MyCoin");

        resultCanv.gameObject.SetActive(true);
        texts[1].text = ("My Coin : " + myCoin);
        if (myCoin <= gameValues.extraLifePrice)
        {
            buttons[0].interactable = false;
            texts[2].gameObject.SetActive(true);
        }
    }

    //Button Behavior.

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void extraLife()
    {

        PlayerPrefs.SetInt("MyCoin", myCoin - gameValues.extraLifePrice);

        player.transform.position = gameValues.BeforeDeadPosition;
        Time.timeScale = 1;
        resultCanv.gameObject.SetActive(false);
    }
}
