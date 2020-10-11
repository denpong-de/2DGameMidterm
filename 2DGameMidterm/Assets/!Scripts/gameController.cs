using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    public playerValue gameValues; //ScriptableObject
    public Text coinCountTXT;

    private void Start()
    {
        gameValues.coinCount = 0;
    }

    void Update()
    {
        coinCountTXT.text = ("Coin : " + gameValues.coinCount);
    }
}
