using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPool : GenericObjectPool
{
    public float spawnRate = 0.5f;
    private float nextSpawnTime;
    void Update()
    {
        if(Time.timeSinceLevelLoad >= nextSpawnTime)
        {
            nextSpawnTime = Time.timeSinceLevelLoad + spawnRate;
            SpawnObject();
        }
    }
}
