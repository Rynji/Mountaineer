using UnityEngine;
using System.Collections;

public class TerrainMovement : MonoBehaviour 
{
	void FixedUpdate () 
    {
        this.transform.position += new Vector3(s_SpawnHandler._instance._staticMovementSpeed, 0, 0);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RepositionerOfTerrain")
            this.transform.position += new Vector3(41.02f, 0, 0);
    }
}
