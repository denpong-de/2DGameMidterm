using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class levelGenerator : MonoBehaviour
{
    [SerializeField] private Transform levelPart_1;

    private void Awake()
    {
        spawnLevelPart(new Vector3(9, -3));
        spawnLevelPart(new Vector3(9, -3) + new Vector3(18,0));
        spawnLevelPart(new Vector3(9, -3) + new Vector3(18 + 18, 0));
    }

    private void spawnLevelPart(Vector3 spawnPosition)
    {
        Instantiate(levelPart_1, spawnPosition, quaternion.identity);
    }
}
