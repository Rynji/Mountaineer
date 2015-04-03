using UnityEngine;
using System.Collections;

public class BasicEnemy : MonoBehaviour 
{
    float forwardSpeed;
    public float _forwardSpeed
    {
        get { return forwardSpeed; }
        set { forwardSpeed = value; }
    }
    float spawnHeight = 1f;
    public float _spawnHeight
    {
        get { return spawnHeight; }
        set { spawnHeight = value; }
    }

    int currentLane;
    public int _currentLane
    {
        get { return currentLane; }
        set { currentLane = value; }
    }

    void Start()
    {
        SetSpeed();
        print("Enemy spawned on lane: " + currentLane);
    }

    void FixedUpdate()
    {
        this.transform.position += new Vector3(forwardSpeed, 0f, 0f);
    }

    void SetSpeed()
    {
        forwardSpeed = Random.Range(-0.1f, -0.2f);
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            print("Enemy on lane " + currentLane + " left the map.");
            s_SpawnHandler._instance._laneObjectsAlive[currentLane] -= 1;
            Destroy(this.gameObject);
        }
    }

}
