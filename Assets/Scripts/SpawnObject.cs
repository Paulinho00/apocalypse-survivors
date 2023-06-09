using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] GameObject toSpawn;
    [SerializeField][Range(0, 1)] float probability;

    public void Spawn()
    {
        if(Random.value < probability)
        {
            GameObject go = Instantiate(toSpawn, transform.position, Quaternion.identity);
        }
    }
}
