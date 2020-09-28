using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class levelGenerator : MonoBehaviour
{
    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private Transform levelPart_1;

    private void Awake()
    {
        Transform lastLevelPartTransform;
        lastLevelPartTransform = spawnLevelPart(levelPart_Start.Find("EndPosition").position);
        lastLevelPartTransform = spawnLevelPart(lastLevelPartTransform.Find("EndPosition").position);
        lastLevelPartTransform = spawnLevelPart(lastLevelPartTransform.Find("EndPosition").position);
        lastLevelPartTransform = spawnLevelPart(lastLevelPartTransform.Find("EndPosition").position);
        lastLevelPartTransform = spawnLevelPart(lastLevelPartTransform.Find("EndPosition").position);
        lastLevelPartTransform = spawnLevelPart(lastLevelPartTransform.Find("EndPosition").position);
    }

    private Transform spawnLevelPart(Vector3 spawnPosition)
    {
       Transform levelPartTransform = Instantiate(levelPart_1, spawnPosition, quaternion.identity);
        return levelPartTransform;
    }
}
