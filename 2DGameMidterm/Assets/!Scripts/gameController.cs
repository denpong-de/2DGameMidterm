using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    public playerValue gameValues; //ScriptableObject
    public Text coinCountTXT;

    void Start()
    {
        coinCountTXT.text = ("Coin : " + gameValues.coinCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
