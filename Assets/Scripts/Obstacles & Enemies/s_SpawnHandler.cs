using UnityEngine;
using System.Collections;

public class s_SpawnHandler : MonoBehaviour 
{
    private static s_SpawnHandler instance;
    public static s_SpawnHandler _instance
    {
        get
        {
            return instance ?? (instance = (new GameObject("SpawnHandler")).AddComponent<s_SpawnHandler>());
        }
    }

    float[] spawnLanes = new float[7];
    float firstLanePosition = -8.5f;
    float laneOffset = 3f;
    float spawnX = 15f;

    int[] laneObjectsAlive = new int[7];
    public int[] _laneObjectsAlive
    {
        get { return laneObjectsAlive; }
        set { laneObjectsAlive = value; }
    }

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
        StartCoroutine(spawnObstacles());
    }

    void SpawnObstacle(GameObject obstacle)
    {
        int laneToSpawn = Random.Range(0, 6);
        if (laneObjectsAlive[laneToSpawn] < 1)
        {
            laneObjectsAlive[laneToSpawn] += 1;
            GameObject basicEnemy = Instantiate(obstacle, new Vector3(spawnX, obstacle.GetComponent<BasicEnemy>()._spawnHeight, spawnLanes[laneToSpawn]), Quaternion.identity) as GameObject;
            basicEnemy.GetComponent<BasicEnemy>()._currentLane = laneToSpawn;
        }
        else
            print("Not spawning, lane: " + laneObjectsAlive[laneToSpawn] + " is already occupied!");
    }

    IEnumerator spawnObstacles()
    {
        while (true)
        {
            SpawnObstacle(basicEnemy);
            yield return new WaitForSeconds(1);
        }

    }
}
