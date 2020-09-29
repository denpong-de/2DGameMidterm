using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class levelGenerator : MonoBehaviour
{
    public playerValue Level; //ScriptableObject

    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private player player;
    [SerializeField] private List<Transform> levelPartList;

    private Vector3 lastEndPosition;

    private void Awake()
    {
        lastEndPosition = levelPart_Start.Find("EndPosition").position;
    }

    private void Update()
    {
        //Spawn new level Part.
        if (Vector3.Distance(player.transform.position, lastEndPosition) < Level.SpawnDistance)
        {
            SpawnLevelPart();
        }

        deleteOldLevelPart();
    }

    //Spawn new level Part Method.

    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelPartList[UnityEngine.Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, quaternion.identity);
        return levelPartTransform;
    }

    //Delete old level Part Method.

    private GameObject[] levelPartInGame;
    private void deleteOldLevelPart()
    {
        levelPartInGame = GameObject.FindGameObjectsWithTag("levelPart");
        foreach (GameObject levelPartInGame in levelPartInGame)
        {
            if (Vector3.Distance(levelPartInGame.transform.position, player.transform.position) > Level.SpawnDistance)
            {
                Destroy(levelPartInGame);
            }
        }
    }
}
