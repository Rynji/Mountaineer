using UnityEngine;
using System.Collections;

public class Enemy_Goat : BasicEnemy
{
    new void Start()
    {
        base.Start();
        SetSpeed(-0.2f, -0.25f);
        spawnHeight = 2.25f;

        parent = this.transform.parent.transform;
        parent.transform.position += new Vector3(0, spawnHeight, 0);
    }

    void FixedUpdate()
    {
        parent.transform.position += new Vector3(forwardSpeed, 0f, 0f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Deadly")
        {
            this.forwardSpeed = collision.gameObject.GetComponent<BasicEnemy>()._forwardSpeed;
        }
    }
}
