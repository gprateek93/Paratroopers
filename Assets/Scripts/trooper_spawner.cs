using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trooper_spawner : MonoBehaviour {

    public Transform gate;
    public GameObject trooperPrefab;
    public float maxTime = 5;
    public float minTime = 2;
    int counter = 0;
    //current time
    private float time;

    //The time to spawn the object
    private float spawnTime;
    private int maxcount = 2;

    void Start()
    {
        SetRandomTime();
        time = minTime;
    }

    void FixedUpdate()
    {

        //Counts up
        if(Time.time>Enemy_Spawner.incrementer){
            if(maxcount<10){
                maxcount++;
            }
        }
        time += Time.deltaTime;

        //Check if its the right time to spawn the object
        if (time >= spawnTime && counter<maxcount &&  (transform.position.x < -1.2f || transform.position.x > 1.7f))
        {
            Throw();
            SetRandomTime();
        }

    }
    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }
    void Throw()
    {
        time = 0;
        Instantiate(trooperPrefab, gate.position, gate.rotation);
        counter++;
    }
}
