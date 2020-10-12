using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameEvent : MonoBehaviour
{
    public static gameEvent current;

    private void Awake()
    {
        current = this;
    }

    public Action onRespawnTriggerEnter;
    public void RespawnTriggerEnter()
    {
        if(onRespawnTriggerEnter != null)
        {
            onRespawnTriggerEnter();
        }
    }
}
