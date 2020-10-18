using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    public playerValue gameValues; //ScriptableObject

    public GameObject player;
    public Transform endGamePosition;
    public Canvas resultCanv;
    public Text[] texts;
    public Button[] buttons;
    public Image[] hearts;

    private int currentScene;

    private void Awake()
    {
        healthBarSetup();
    }

    private void Start()
    {
        gameValues.coinCount = 0;
        gameValues.currentScore = 0;

        currentScene = SceneManager.GetActiveScene().buildIndex;

        gameEvent.current.onCoinTriggerEnter += OnCoinCountUpdate;
        gameEvent.current.onEnemyTriggerEnter += OnHealthPointUpdate;
        gameEvent.current.onRespawnTriggerEnter += OnResultScreenOpen;
        gameEvent.current.onRewardAdEnter += OnExtraLifeUpdate;
    }

    private void FixedUpdate()
    {
        scoreUpdate();

        if(currentScene == 2)
        {
            dungeonBehav();
        }
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

        gameValues.HealthPoint = 0;
        foreach(Image image in hearts)
        {
            image.enabled = false;
        }

        //Store High Score.
        gameValues.currentScore = Mathf.Round(gameValues.currentScore);

        if (PlayerPrefs.HasKey("HighScore"))
        {
            if(PlayerPrefs.GetFloat("HighScore") < gameValues.currentScore)
            {
                PlayerPrefs.SetFloat("HighScore", gameValues.currentScore);
            }
        }
        else
        {
            PlayerPrefs.SetFloat("HighScore", gameValues.currentScore);
        }

        //Store MyCoin.
        PlayerPrefs.SetInt("MyCoin", PlayerPrefs.GetInt("MyCoin") + gameValues.coinCount);
        myCoin = PlayerPrefs.GetInt("MyCoin");

        resultCanv.gameObject.SetActive(true);

        if (currentScene == 1)
        {
            //Show High Score.
            texts[4].text = "High Score : " + PlayerPrefs.GetFloat("HighScore");

            //Show My Coin.
            texts[1].text = ("" + myCoin);

            //Not enough coin to buy Extra Life.
            OnExtraLifeUpdate();
        }
    }

    void OnExtraLifeUpdate()
    {
        myCoin = PlayerPrefs.GetInt("MyCoin");

        if (alreadyExtraLife || myCoin < gameValues.extraLifePrice)
        {
            buttons[0].interactable = false;
            texts[2].gameObject.SetActive(true);
        }
        else
        {
            buttons[0].interactable = true;
            texts[2].gameObject.SetActive(false);
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
        if(currentScene == 1)
        {
            gameValues.currentScore += Time.deltaTime * gameValues.runSpeed;
            texts[3].text = "Score : " + Mathf.Round(gameValues.currentScore);
        }
        else
        {
            texts[3].text = "distance : " + Mathf.Round(endGamePosition.position.x - player.transform.position.x);
        }
    }

    //dungeon Behavior
    private void dungeonBehav()
    {
        if(endGamePosition.position.x - player.transform.position.x <= 0)
        {
            gameEvent.current.RespawnTriggerEnter();
            PlayerPrefs.SetInt("challengePass" + gameValues.lastSceneIndex, 1);
        }
    }

    //Button Behavior.

    private bool alreadyExtraLife;
    public void extraLife()
    {
        PlayerPrefs.SetInt("MyCoin", myCoin - gameValues.extraLifePrice);

        player.transform.position = gameValues.BeforeDeadPosition;
        gameValues.HealthPoint++;
        hearts[0].enabled = true;
        alreadyExtraLife = true;
        Time.timeScale = 1;
        resultCanv.gameObject.SetActive(false);
    }

    public void restart()
    {
        gameValues.playAgain = true;
        gameValues.lastSceneIndex = SceneManager.GetActiveScene().buildIndex;
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
