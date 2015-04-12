using UnityEngine;
using System.Collections;

public class Enemy_Snowball : BasicEnemy
{
    Transform blobShadow;
    float growthRate, shadowGrowthRate;

    new void Start()
    {
        base.Start();

        growthRate = Random.Range(0.01f, 0.04f);
        shadowGrowthRate = growthRate * 1.75f;
        parent = this.transform.parent;
        blobShadow = transform.parent.FindChild("ShadowBlob").GetComponent<Transform>();
        SetSpeed(s_SpawnHandler._instance._staticMovementSpeed, s_SpawnHandler._instance._staticMovementSpeed);
        spawnHeight = 1f;
        parent.transform.position += new Vector3(0, spawnHeight, 0);
    }

    void FixedUpdate()
    {
        parent.transform.position += new Vector3(forwardSpeed * 2.75f, 0f, 0f);
        this.transform.position += new Vector3(0, 0.01f, 0f);
        this.transform.localScale += new Vector3(growthRate, growthRate, growthRate);
        blobShadow.localScale += new Vector3(shadowGrowthRate, shadowGrowthRate, shadowGrowthRate);
        this.transform.Rotate((new Vector3(0.0f, 0.0f, 100.0f) * Time.deltaTime));
    }
}
