using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudSpawner : MonoBehaviour {

    public GameObject cloudPrefab;
    Vector2 whereTospawn;
    public float spawnRate;
    float nextSpawn = 0;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            whereTospawn = new Vector2(-6.7f, 4.14f);
            Instantiate(cloudPrefab, whereTospawn, Quaternion.identity);
        }
    }
}
