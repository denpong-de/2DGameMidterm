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

        gameEvent.current.onRespawnTriggerEnter += OnResultScreenOpen;
    }

    void Update()
    {
        coinCountTXT.text = ("Coin : " + gameValues.coinCount);
    }

    //onRespawnTriggerEnter listener.

    private void OnResultScreenOpen()
    {
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
        player.transform.position = gameValues.BeforeDeadPosition;
        Time.timeScale = 1;
        resultCanv.gameObject.SetActive(false);
    }
}
