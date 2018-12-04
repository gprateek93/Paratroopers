using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aeroplane_Movement : MonoBehaviour {

    public float speed;
    public float health;
    public Boundary boundary;
    public GameObject explosionPrefab;
    GameObject myObject;
    float time = 1.0f;
	// Update is called once per frame
	void Update () {
        transform.Translate((new Vector3(-1, 0, 0)) * speed * Time.deltaTime);
        if(transform.position.x < boundary.xMin){
            Destroy(gameObject);
        }
	}

    public void hurt(int damage)
    {
        //aeroplane getting shot logic
        health -= damage;
        if (health <= 0)
        {
            die();
        }
    }
    public void die()
    {
        myObject = (GameObject)(Instantiate(explosionPrefab, transform.position, transform.rotation));
        Destroy(this.gameObject);
        Destroy(myObject, time);
    }
}
