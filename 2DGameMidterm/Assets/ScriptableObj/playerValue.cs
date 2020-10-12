using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "player")]
public class playerValue : ScriptableObject
{
    //1.
    [Header("Player Settings")]
    [Range(0f, 10f)] public float jumpVelocity;
    [Range(0f, 5f)] public float fallMultiply;
    [Range(0f, 20f)] public float runSpeed;

    //2.
    [Header("Level Generator")]
    [Range(0f, 50f)] public float SpawnDistance;

    //3.
    [Header("BG Setting")]
    public Vector2 bgPropMultiplier;
    public Vector2 bgMultiplier;

    //4.
    [Header("Game price")]
    public int extraLifePrice;

    //5.
    [Header("InGame Value")]
    public int coinCount;
    public Vector3 BeforeDeadPosition;
}
