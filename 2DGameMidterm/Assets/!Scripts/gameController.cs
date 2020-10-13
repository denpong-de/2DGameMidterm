using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    public playerValue gameValues; //ScriptableObject

    public GameObject player;
    public Canvas resultCanv;
    public Text[] texts;
    public Button[] buttons;
    public Image[] hearts;

    private void Awake()
    {
        healthBarSetup();
    }

    private void Start()
    {
        gameValues.coinCount = 0;
        gameValues.score = 0;

        gameEvent.current.onCoinTriggerEnter += OnCoinCountUpdate;
        gameEvent.current.onEnemyTriggerEnter += OnHealthPointUpdate;
        gameEvent.current.onRespawnTriggerEnter += OnResultScreenOpen;
    }

    private void Update()
    {
        scoreUpdate();
    }

    //onCoinTriggerEnter listener.

    private void OnCoinCountUpdate()
    {
        texts[0].text = ("" + gameValues.coinCount);
    }

    //onEnemyTriggerEnter listener.

    private void OnHealthPointUpdate()
    {
        hearts[gameValues.HealthPoint].enabled = false;
    }

    //onRespawnTriggerEnter listener.

    private int myCoin;
    private void OnResultScreenOpen()
    {
        Time.timeScale = 0;

        foreach(Image image in hearts)
        {
            image.enabled = false;
        }

        //Store High Score.
        gameValues.score = Mathf.Round(gameValues.score);

        if (PlayerPrefs.HasKey("HighScore"))
        {
            if(PlayerPrefs.GetFloat("HighScore") < gameValues.score)
            {
                PlayerPrefs.SetFloat("HighScore", gameValues.score);
            }
        }
        else
        {
            PlayerPrefs.SetFloat("HighScore", gameValues.score);
        }

        texts[4].text = "High Score : " + PlayerPrefs.GetFloat("HighScore");

        //Store and show MyCoin.
        PlayerPrefs.SetInt("MyCoin", PlayerPrefs.GetInt("MyCoin") + gameValues.coinCount);
        myCoin = PlayerPrefs.GetInt("MyCoin");

        resultCanv.gameObject.SetActive(true);
        texts[1].text = ("" + myCoin);
        //Not enough coin.
        if (myCoin <= gameValues.extraLifePrice)
        {
            buttons[0].interactable = false;
            texts[2].gameObject.SetActive(true);
        }
    }

    //Set Health Bar to match the Health Points.

    private void healthBarSetup()
    {
        for (int i = 4; i > gameValues.HealthPoint - 1; i--)
        {
            hearts[i].enabled = false;
        }
    }

    //update Score
    private void scoreUpdate()
    {
        gameValues.score += Time.deltaTime * gameValues.runSpeed;
        texts[3].text = "Score : " + Mathf.Round(gameValues.score);
    }

    //Button Behavior.

    public void extraLife()
    {

        PlayerPrefs.SetInt("MyCoin", myCoin - gameValues.extraLifePrice);

        player.transform.position = gameValues.BeforeDeadPosition;
        Time.timeScale = 1;
        resultCanv.gameObject.SetActive(false);
    }

    public void restart()
    {
        gameValues.playAgain = true;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void mainMenu()
    {
        gameValues.playAgain = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
