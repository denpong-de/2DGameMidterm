﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "player")]
public class playerValue : ScriptableObject
{
    [Header("Jump Settings")]
    public float jumpVelocity;
    public float fallMultiply;
}
