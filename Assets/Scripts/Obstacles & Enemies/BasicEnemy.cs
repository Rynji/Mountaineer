using UnityEngine;
using System.Collections;

public class BasicEnemy : MonoBehaviour 
{
    BoxCollider enemyCollider;
    Camera cam;
    Plane[] planes;

    float forwardSpeed;
    public float _forwardSpeed
    {
        get { return forwardSpeed; }
        set { forwardSpeed = value; }
    }

    bool justSpawned, canRespawn;
    public bool _justSpawned
    { get { return justSpawned; } }

    void Awake()
    {
        cam = Camera.main;
        planes = GeometryUtility.CalculateFrustumPlanes(cam);
        enemyCollider = this.GetComponent<BoxCollider>();

        SetSpeed();
        justSpawned = true;
    }

    void FixedUpdate()
    {
        //Static forward movement.
        this.transform.position += new Vector3(forwardSpeed, 0f, 0f);

        if (justSpawned)
            canRespawn = false;

        if (canRespawn)
        {
            if (!GeometryUtility.TestPlanesAABB(planes, enemyCollider.bounds))
            {
                SetSpeed();
                SetSpawnPosition();
            }
        }

        else if (!canRespawn)
        {
            if (GeometryUtility.TestPlanesAABB(planes, enemyCollider.bounds))
            {
                canRespawn = true;
                justSpawned = false;
            }
        }
    }

    void SetSpeed()
    {
        forwardSpeed = Random.Range(-0.1f, -0.2f);
    }

    void SetSpawnPosition()
    {
        justSpawned = true;
        float spawnZpos = Random.Range(-14f, 14f);
        this.transform.position = new Vector3(14f, 0.75f, spawnZpos);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Deadly")
        {
            this.forwardSpeed = collision.gameObject.GetComponent<BasicEnemy>()._forwardSpeed;

            if (collision.gameObject.GetComponent<BasicEnemy>()._justSpawned)
                SetSpawnPosition();
        }
    }

}
