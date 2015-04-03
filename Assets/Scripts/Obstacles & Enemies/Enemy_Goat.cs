using UnityEngine;
using System.Collections;

public class Enemy_Goat : BasicEnemy
{
    new void Start()
    {
        base.Start();
        SetSpeed(-0.2f, -0.25f);
        spawnHeight = 1.06f;
        parent.transform.position += new Vector3(0, spawnHeight, 0);
    }
}
