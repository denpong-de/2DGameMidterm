using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    public playerValue gameValues; //ScriptableObject
    public GameObject player;
    public Text coinCountTXT;
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
        coinCountTXT.text = ("Coin : " + gameValues.coinCount);
    }

    //onRespawnTriggerEnter listener.

    private void OnResultScreenOpen()
    {
        Time.timeScale = 0;
        PlayerPrefs.SetInt("MyCoin", PlayerPrefs.GetInt("MyCoin") + gameValues.coinCount);
        resultCanv.gameObject.SetActive(true);
    }

    //Button Behavior.

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void extraLife()
    {
        PlayerPrefs.SetInt("MyCoin", PlayerPrefs.GetInt("MyCoin") - gameValues.coinCount);

        player.transform.position = gameValues.BeforeDeadPosition;
        Time.timeScale = 1;

        resultCanv.gameObject.SetActive(false);
    }
}
