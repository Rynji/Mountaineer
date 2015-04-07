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
    float foodSpawnDelay;
    int maxObjectsPerLane;
    public int _maxObjectsPerLane
    {
        get { return maxObjectsPerLane; }
        set { maxObjectsPerLane = value; }
    }
    float staticMovementSpeed;
    public float _staticMovementSpeed
    {
        get { return staticMovementSpeed; }
        set { staticMovementSpeed = value; }
    }

    int[] laneObjectsAlive = new int[7];
    public int[] _laneObjectsAlive
    {
        get { return laneObjectsAlive; }
        set { laneObjectsAlive = value; }
    }

    GameObject obstacleGoat, obstaclePineTree, obstacleSnowball;
    GameObject basicFood;

    void Awake()
    {
        spawnLanes[0] = firstLanePosition;
        
        //Difficulty variables
        spawnDelay = 0.3f;
        maxObjectsPerLane = 5;
        staticMovementSpeed = -0.075f;
        foodSpawnDelay = 6f;

        for (int i = 0; i < spawnLanes.Length; i++)
        {
            spawnLanes[i] = firstLanePosition + (i * laneOffset);
        }

        LoadPrefabs();
    }

    void Start()
    {
        StartCoroutine(spawnObstacles());
        StartCoroutine(spawnFoods());
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

    void SpawnFood(GameObject food)
    {
        int laneToSpawn = Random.Range(0, 7);

        laneObjectsAlive[laneToSpawn] += 1;
        GameObject spawnedBuff = Instantiate(food, new Vector3(spawnX, 0, spawnLanes[laneToSpawn]), Quaternion.identity) as GameObject;
    }

    void LoadPrefabs()
    {
        //Standard Goat
        obstacleGoat = Resources.Load("Prefabs/Obstacles/Obstacle_Goat") as GameObject;
        obstaclePineTree = Resources.Load("Prefabs/Obstacles/Obstacle_PineTree") as GameObject;
        obstacleSnowball = Resources.Load("Prefabs/Obstacles/Obstacle_Snowball02") as GameObject;

        basicFood = Resources.Load("Prefabs/Buffs/BasicFood") as GameObject;
    }

    IEnumerator spawnFoods()
    {
        while (true)
        {
            yield return new WaitForSeconds(foodSpawnDelay);
            SpawnFood(basicFood);
        }
    }

    IEnumerator spawnObstacles()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);

            int spawnDecider = Random.Range(0, 16);

            switch (spawnDecider)
            {
                case 0:
                    SpawnBasicEnemy(obstacleGoat);
                    break;
                case 1:
                    SpawnBasicEnemy(obstaclePineTree);
                    break;
                case 2:
                    SpawnBasicEnemy(obstaclePineTree);
                    break;
                case 3:
                    SpawnBasicEnemy(obstaclePineTree);
                    break;
                case 4:
                    SpawnBasicEnemy(obstaclePineTree);
                    break;
                case 5:
                    SpawnBasicEnemy(obstaclePineTree);
                    break;
                case 6:
                    SpawnBasicEnemy(obstaclePineTree);
                    break;
                case 7:
                    SpawnBasicEnemy(obstaclePineTree);
                    break;
                case 15:
                    SpawnBasicEnemy(obstacleSnowball);
                    break;
                default:
                    SpawnBasicEnemy(obstacleGoat);
                    break;
            }
        }
    }
}
