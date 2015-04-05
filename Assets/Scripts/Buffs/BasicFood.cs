using UnityEngine;
using System.Collections;

public class BasicFood : MonoBehaviour 
{
    void Start()
    {
        float spawnHeight = 1f;
        this.transform.position += new Vector3(0, spawnHeight, 0);
        this.transform.localRotation = Quaternion.Euler(new Vector3(-45, -45, 0));
    }

    new void FixedUpdate()
    {
        this.transform.position += new Vector3(s_SpawnHandler._instance._staticMovementSpeed * 2, 0f, 0f);
    }
}
