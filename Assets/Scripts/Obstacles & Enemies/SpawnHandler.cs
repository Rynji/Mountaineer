using UnityEngine;
using System.Collections;

public class SpawnHandler : MonoBehaviour 
{
    float[] spawnLanes = new float[7];
    float firstLanePosition = -8.5f;
    float laneOffset = 3f;
    float spawnX = 15f;
    float spawnY = 1.1f;

    GameObject basicEnemy;

    void Awake()
    {
        spawnLanes[0] = firstLanePosition;

        for (int i = 0; i < spawnLanes.Length; i++)
        {
            spawnLanes[i] = firstLanePosition + (i * laneOffset);
        }

        basicEnemy = Resources.Load("Prefabs/BasicEnemy") as GameObject;
    }

    void Start()
    {
        Instantiate(basicEnemy, new Vector3(spawnX, spawnY, spawnLanes[Random.Range(0, 6)]), Quaternion.identity);
    }
}
