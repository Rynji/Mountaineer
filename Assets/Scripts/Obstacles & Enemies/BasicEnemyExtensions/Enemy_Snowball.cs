using UnityEngine;
using System.Collections;

public class Enemy_Snowball : BasicEnemy
{
    Projector blobShadow;
    new void Start()
    {
        base.Start();

        parent = this.transform.parent;
        blobShadow = transform.parent.FindChild("BlobShadowProjector").GetComponent<Projector>();
        SetSpeed(s_SpawnHandler._instance._staticMovementSpeed, s_SpawnHandler._instance._staticMovementSpeed);
        spawnHeight = 1f;
        parent.transform.position += new Vector3(0, spawnHeight, 0);
    }

    void FixedUpdate()
    {
        parent.transform.position += new Vector3(forwardSpeed * 2.75f, 0f, 0f);
        this.transform.position += new Vector3(0, 0.014f, 0f);
        this.transform.localScale += new Vector3(0.04f, 0.04f, 0.04f);
        blobShadow.fieldOfView += 0.35f;
        this.transform.Rotate((new Vector3(0.0f, 0.0f, 100.0f) * Time.deltaTime));
    }
}
