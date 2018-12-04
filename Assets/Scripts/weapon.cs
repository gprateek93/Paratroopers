using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {

    public Transform firePoint;
    public GameObject bulletPrefab;
    private GameObject myObject;
    public Boundary boundary;
    public float fireSpeed = 0.2f;
    float nextFire = 0f;
	// Update is called once per frame
	void Update () {
        if(Input.GetButton("Fire1")&&Time.time>nextFire){
            nextFire = Time.time + fireSpeed; //cooldown timer
            GetComponent<AudioSource>().Play();
            Shoot();

        }
	}
    void Shoot(){
        //Shooting logic
        myObject = (GameObject)(Instantiate(bulletPrefab, firePoint.position, firePoint.rotation));
        if(myObject.transform.position.y > boundary.yMax){
            Destroy(myObject);
        }
    }
}
