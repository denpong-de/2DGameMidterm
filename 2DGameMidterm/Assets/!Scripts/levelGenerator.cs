using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class levelGenerator : MonoBehaviour
{
    public playerValue Level; //ScriptableObject

    [SerializeField] private Transform pfTesting; //Warning : For testing only!
    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private player player;
    [SerializeField] private List<Transform> levelPartEasyList;
    [SerializeField] private List<Transform> levelPartNormalList;

    private Vector3 lastEndPosition;
    private int levelPartsSpawned;

    private void Awake()
    {
        lastEndPosition = levelPart_Start.Find("EndPosition").position;

        //Warning : For testing only!
        if (pfTesting != null)
        {
            Debug.Log("Warning : Using Debug Testing Platform!");
        }
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

    List<Transform> difficultyLevelPartList;
    private void SpawnLevelPart()
    {
        switch (getDifficulty())
        {
            default:
            case 1:   difficultyLevelPartList = levelPartEasyList;   break;
            case 2: difficultyLevelPartList = levelPartNormalList; break;
        }

        Transform chosenLevelPart = difficultyLevelPartList[UnityEngine.Random.Range(0, difficultyLevelPartList.Count)];

        //Warning : For testing only!
        if (pfTesting != null)
        {
            chosenLevelPart = pfTesting;
        }

        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
        levelPartsSpawned++;
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, quaternion.identity);
        return levelPartTransform;
    }

    private int getDifficulty()
    {
        if (levelPartsSpawned >= Level.easyToNormal)
        {
            Level.difficultyIndex = 2;
            return Level.difficultyIndex;
        }

        Level.difficultyIndex = 1;
        return Level.difficultyIndex;
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
