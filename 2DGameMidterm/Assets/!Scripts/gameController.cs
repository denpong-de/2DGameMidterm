using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    public playerValue gameValues; //ScriptableObject
    public Text coinCountTXT;
    public Canvas resultCanV;

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
        resultCanV.gameObject.SetActive(true);
    }

    //Button Behavior.

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
