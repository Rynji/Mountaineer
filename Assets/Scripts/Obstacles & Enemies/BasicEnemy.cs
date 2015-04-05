using UnityEngine;
using System.Collections;

public class BasicEnemy : MonoBehaviour 
{
    protected bool despawned;

    protected float forwardSpeed;
    public float _forwardSpeed
    {
        get { return forwardSpeed; }
        set { forwardSpeed = value; }
    }

    protected float spawnHeight;
    public float _spawnHeight
    {
        get { return spawnHeight; }
        set { spawnHeight = value; }
    }

    protected int currentLane;
    public int _currentLane
    {
        get { return currentLane; }
        set { currentLane = value; }
    }

    protected Transform parent;

    protected void Start()
    {
        despawned = false;
    }

    protected void SetSpeed(float min, float max)
    {
        forwardSpeed = Random.Range(min, max);
    }

    protected void Despawn()
    {
        if (!despawned)
        {
            despawned = true;
            s_SpawnHandler._instance._laneObjectsAlive[currentLane] -= 1;

            if(parent != null)
                Destroy(parent.gameObject);
            else
                Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "DestroyerOfObjects")
        {
            Despawn();
        }
    }

}
