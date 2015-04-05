using UnityEngine;
using System.Collections;

public class Enemy_Snowball : BasicEnemy
{
    new void Start()
    {
        base.Start();
        SetSpeed(s_SpawnHandler._instance._staticMovementSpeed, s_SpawnHandler._instance._staticMovementSpeed);
        spawnHeight = 1f;
        this.transform.position += new Vector3(0, spawnHeight, 0);
    }

    new void FixedUpdate()
    {
        this.transform.position += new Vector3(forwardSpeed * 2.75f, 0.014f, 0f);
        this.transform.localScale += new Vector3(0.04f, 0.04f, 0.04f);
        this.transform.Rotate((new Vector3(0.0f, 0.0f, 100.0f) * Time.deltaTime));
    }
}
