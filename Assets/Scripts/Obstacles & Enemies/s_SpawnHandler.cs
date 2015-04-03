using UnityEngine;
using System.Collections;

public class s_SpawnHandler : MonoBehaviour 
{
    private static s_SpawnHandler instance;
    public static s_SpawnHandler _instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<s_SpawnHandler>();
                if (instance == null)
                {
                    GameObject SpawnHandler = new GameObject("_SpawnHandler");
                    //SpawnHandler.hideFlags = HideFlags.HideAndDontSave;
                    instance = SpawnHandler.AddComponent<s_SpawnHandler>();
                }
            }
            return instance;
        }
    }

    float[] spawnLanes = new float[7];
    float firstLanePosition = -8.5f;
    float laneOffset = 3f;
    float spawnX = 22f;

    //Difficulty variables
    float spawnDelay;
    public float _spawnDelay
    {
        get { return spawnDelay; }
        set { spawnDelay = value; }
    }
    int maxObjectsPerLane;
    public int _maxObjectsPerLane
    {
        get { return maxObjectsPerLane; }
        set { maxObjectsPerLane = value; }
    }

    int[] laneObjectsAlive = new int[7];
    public int[] _laneObjectsAlive
    {
        get { return laneObjectsAlive; }
        set { laneObjectsAlive = value; }
    }

    GameObject obstacleGoat;

    void Awake()
    {
        spawnLanes[0] = firstLanePosition;
        
        //Difficulty variables
        spawnDelay = 0.3f;
        maxObjectsPerLane = 5;

        for (int i = 0; i < spawnLanes.Length; i++)
        {
            spawnLanes[i] = firstLanePosition + (i * laneOffset);
        }

        obstacleGoat = Resources.Load("Prefabs/Obstacle_Goat") as GameObject;
    }

    void Start()
    {
        StartCoroutine(spawnObstacles());
    }

    void SpawnBasicEnemy(GameObject basicEnemy)
    {
        int laneToSpawn = Random.Range(0, 7);
        if (laneObjectsAlive[laneToSpawn] < maxObjectsPerLane)
        {
            laneObjectsAlive[laneToSpawn] += 1;
            GameObject spawnedEnemy = Instantiate(basicEnemy, new Vector3(spawnX, 0, spawnLanes[laneToSpawn]), Quaternion.identity) as GameObject;
            spawnedEnemy.GetComponentInChildren<BasicEnemy>()._currentLane = laneToSpawn;
        }
    }

    IEnumerator spawnObstacles()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            //TODO: Determine which object to spawn when...
            SpawnBasicEnemy(obstacleGoat);
            print("Spawning...");
        }
    }
}
