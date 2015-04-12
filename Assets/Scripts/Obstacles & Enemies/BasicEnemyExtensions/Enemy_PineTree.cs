using UnityEngine;
using System.Collections;

public class Enemy_PineTree : BasicEnemy
{
    new void Start()
    {
        base.Start();
        SetSpeed(s_SpawnHandler._instance._staticMovementSpeed, s_SpawnHandler._instance._staticMovementSpeed);
        spawnHeight = 4.48f;
        this.transform.position += new Vector3(0, spawnHeight, 0);
        this.transform.localRotation = Quaternion.Euler(new Vector3(-90, Random.Range(0f, 360f), 0));
    }

    void FixedUpdate()
    {
        this.transform.position += new Vector3(forwardSpeed * 2, 0f, 0f);
    }
}
