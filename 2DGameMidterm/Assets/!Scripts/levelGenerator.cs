using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class levelGenerator : MonoBehaviour
{
    private const float LevelSpawnDistance = 25f;

    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private Transform levelPart_1;
    [SerializeField] private player player;

    private Vector3 lastEndPosition;

    private void Awake()
    {
        lastEndPosition = levelPart_Start.Find("EndPosition").position;
    }

    private void Update()
    {
        if(Vector3.Distance(player.transform.position,lastEndPosition) < LevelSpawnDistance)
        {
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart()
    {
        Transform lastLevelPartTransform = SpawnLevelPart(lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart(Vector3 spawnPosition)
    {
       Transform levelPartTransform = Instantiate(levelPart_1, spawnPosition, quaternion.identity);
        return levelPartTransform;
    }
}
