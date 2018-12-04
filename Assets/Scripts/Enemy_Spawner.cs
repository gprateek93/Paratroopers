using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour {

    public GameObject enemy_Helicopter_right;
    public GameObject enemy_Helicopter_left;
    public GameObject enemy_Aeroplane;
    Vector2Int flag = new Vector2Int(1, 0);
    float heliSession = 20f;
    float aeroSession = 10f;
    Vector2 whereTospawn;
    public float spawnRate;
    float time = 100;
    float nextSpawn = 0;
    public static float incrementer = 40f;
    
    // Update is called once per frame
    void Update () {
        if(Time.time>incrementer){
            incrementer *= 2;
            spawnRate /= 2;
        }
        if(Time.time > nextSpawn){
            nextSpawn = Time.time + spawnRate;
            if(flag[0] == 1){
                whereTospawn = new Vector2(7f, 2.63f);
                Instantiate(enemy_Helicopter_right, whereTospawn, Quaternion.identity);
                whereTospawn = new Vector2(-7f, 3.8f);
                Instantiate(enemy_Helicopter_left, whereTospawn, Quaternion.identity);
                heliSession -= time*Time.deltaTime;
                if (heliSession <=0)
                {
                    flag[1] = 1;
                    flag[0] = 0;
                    heliSession = 20f;
                }
            }
            else if(flag[1] == 1){
                whereTospawn = new Vector2(7f, 4.63f);
                Instantiate(enemy_Aeroplane, whereTospawn, Quaternion.identity);
                aeroSession -= time*Time.deltaTime;
                if (aeroSession<=0)
                {
                    flag[0] = 1;
                    flag[1] = 0;
                    aeroSession = 10f;
                }
            }
        }
    }
}
