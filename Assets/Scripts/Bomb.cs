using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public GameObject myPlayer;
    public GameObject Enemy_Aero;
    public GameObject explosionPrefab;
    GameObject myObject;
    float time = 1.0f;
    public float speed = 2.0f;
    public float damage;
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, myPlayer.transform.position, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D hit)
    {
        if(hit.name == "Background"){
            Destroy(gameObject);
            return;
        }
        PlayerController player = hit.GetComponent<PlayerController>();
        if(player!=null){
            player.hurt(damage);
            Destroy(gameObject);
        }
    }
    public void die(){
        myObject = (GameObject)(Instantiate(explosionPrefab, transform.position, transform.rotation));
        Destroy(this.gameObject);
        Destroy(myObject, time);
    }
}
