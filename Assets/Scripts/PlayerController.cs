using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax;
    public float yMin, yMax;
}
public class PlayerController : MonoBehaviour {

    public Boundary boundary;
    //private Rigidbody2D rb;
    public float health;
    public GameObject explosionPrefab;
    public GameObject GameOverUI;
    GameObject myObject;
    float time = 1.0f;
    public Rigidbody2D Rb;

    private void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D()
    {
        Rb.gravityScale = 0;
    }

    public void hurt(float damage){
        health -= damage;
        if(health<=0){
            die();
        }
    }
    public void die()
    {
        trooper.countLeft = 0;
        trooper.countRight = 0;
        trooper.reachedLeft = 0;
        trooper.reachedRight = 0;
        terrorist_movement.count = 0;
        Enemy_Spawner.incrementer = 40;
        myObject = (GameObject)(Instantiate(explosionPrefab, transform.position, transform.rotation));
        Destroy(this.gameObject);
        Destroy(myObject, time);
        
        Time.timeScale = 0f;
        GameOverUI.SetActive(true);
    }

}

