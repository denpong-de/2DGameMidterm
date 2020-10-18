using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class gameAnalytics : MonoBehaviour
{
    public playerValue gameValues; //ScriptableObject

    // Start is called before the first frame update
    void Start()
    {
        gameEvent.current.onRespawnTriggerEnter += OnRespawnAnalytics;
    }

    void OnRespawnAnalytics()
    {
        AnalyticsResult analyticsResult = Analytics.CustomEvent(
            "LevelDied",
            new Dictionary<string, object>
            {
                {"Game Mode", gameValues.lastSceneIndex},
                {"Dificulty", gameValues.difficultyIndex},
                {"Coin Count", gameValues.coinCount},
                {"Score", gameValues.currentScore },
                {"Dead Platform",gameValues.BeforeDeadPlatform }
            }
        );
        Debug.Log("analyticsResult: " + analyticsResult);
    }
}
