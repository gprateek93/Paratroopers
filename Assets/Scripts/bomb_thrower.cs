using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb_thrower : MonoBehaviour {

    public Transform firePoint;
    public GameObject bombPrefab;
    private float throwSpeed;
    public float maxTime = 5;
    public float minTime = 2;
    private float time;
    private float maxcount = 2;
    private float count = 0;

    void Start()
    {
        SetRandomTime();
        time = minTime;
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time>Enemy_Spawner.incrementer){
            if (maxcount < 5)
            {
                maxcount++;
            }
        }
        time += Time.deltaTime;
        if (time>throwSpeed && count<maxcount){
            Throw();
            SetRandomTime();
        }
    }
    void SetRandomTime()
    {
        throwSpeed = Random.Range(minTime, maxTime);
    }
    void Throw()
    {
        //Bombing logic
        count++;
        Instantiate(bombPrefab, firePoint.position, firePoint.rotation);
    }
}
