using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter_Movement : MonoBehaviour {
    public float speed;
    public int health;
    private float time = 1.0f;
    public GameObject explosionPrefab;
    private GameObject myObject;
    public Boundary boundary;
    public float direction;

    // Update is called once per frame
    void Update()
    {
        if(Time.time>Enemy_Spawner.incrementer){
            health *= 2;
        }
        transform.Translate((new Vector3(direction, 0, 0)) * speed * Time.deltaTime);
        if (transform.position.x < boundary.xMin || transform.position.x>boundary.xMax)
        {
            //add boundary instead of hard coding the val
            Destroy(this.gameObject);
        }
    }

    public void hurt(int damage){
        //helicopter getting shot logic
        health -= damage;
        if(health<=0){
            die();
        }
    }
    public void die(){
        myObject = (GameObject)(Instantiate(explosionPrefab, transform.position, transform.rotation));
        Destroy(this.gameObject);
        Destroy(myObject,time);
    }
}
