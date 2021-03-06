﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "player")]
public class playerValue : ScriptableObject
{
    [Header("Player Settings")]
    [Range(0f, 10f)] public float jumpVelocity;
    [Range(0f, 5f)] public float fallMultiply;
    [Range(0f, 20f)] public float runSpeed;

    [Header("Enamy Settings")]
    [Range(0f, 5f)] public float spikeSpeed;

    [Header("Level Generator")]
    [Range(0f, 50f)] public float SpawnDistance;

    [Header("BG Setting")]
    public Vector2 bgPropMultiplier;
    public Vector2 bgMultiplier;
    public Vector2 bgXLMultiplier;

    [Header("Difficult Value")]
    public int easyToNormal;

    [Header("In Game price")]
    public int healthPrice;
    public int extraLifePrice;
    public int rewardAdsPrice;
    public int dungeon1Price;

    [Header("In Game Value")]
    public int HealthPoint;
    public int coinCount;
    public float currentScore;
    public int difficultyIndex;
    public Vector3 BeforeDeadPosition;
    public string BeforeDeadPlatform;
    public int lastSceneIndex;
    public bool playAgain;

    [Header("Bird Settings")]
    [Range(0f, 20f)] public int birdDistance;
    public Vector2[] birdPosition;
}
