using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class bullet : MonoBehaviour {

    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage;
    public Boundary boundary;
    public ScoreKeeper score;
    private GameObject refObject;
    private int scoreValue = 0;

	// Use this for initialization
	void Start () {
        rb.velocity = transform.up * speed;
        refObject = GameObject.FindGameObjectWithTag("ScoreKeeper");
        if(refObject != null)
        {
            score = refObject.GetComponent<ScoreKeeper>();            
        }
        if(score == null)
        {
            Debug.Log("This is still not working!");
        }
    }
    void Update()
    {
        //add boundary condition here
        if(transform.position.y>boundary.yMax || transform.position.y < boundary.yMin || transform.position.x > boundary.xMax || transform.position.x < boundary.xMin)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D hitinfo){
        if (hitinfo.name == "Helicopter1_0(Clone)" || hitinfo.name == "Helicopter2_0(Clone)" || hitinfo.name == "Helicopter1_1(Clone)" || hitinfo.name == "Helicopter2_1(Clone)")
        {
            Helicopter_Movement heli = hitinfo.GetComponent<Helicopter_Movement>();
            Debug.Log("Collided Helicopter");
            if (heli != null)
            {
                heli.hurt(damage);
                scoreValue = 50;
                Debug.Log("Here");
            }
        }
        else if(hitinfo.name == "Aeroplane(Clone)"){
            Aeroplane_Movement aero = hitinfo.GetComponent<Aeroplane_Movement>();
            Debug.Log("Collided Airplane");
            if (aero != null)
            {
                aero.hurt(damage);
                scoreValue = 100;
            }
        }
        else if(hitinfo.name == "cannon-ball(Clone)"){
            Bomb bomb = hitinfo.GetComponent<Bomb>();
            Debug.Log("Collided cannon!");

            if (bomb!=null)
            {
                bomb.die();
                scoreValue = 30;
            }
        }
        else if(hitinfo.name == "parachute"){
            parachute para = hitinfo.GetComponent<parachute>();
            if (para != null)
            {
                para.parachuteAttacked();
                scoreValue = 10;
            }
        }
        else if(hitinfo.name == "Falling_trooper(Clone)"){
            trooper trooper = hitinfo.GetComponent<trooper>();
            if(trooper != null){
                trooper.trooperAttacked();
                scoreValue = 20;
            }
        }
        else if (hitinfo.name == "Falling_trooper(L2)(Clone)")
        {
            Trooper_L2 trooper = hitinfo.GetComponent<Trooper_L2>();
            if (trooper != null)
            {
                trooper.trooperAttacked();
                scoreValue = 20;
            }
        }
        score.AddScore(scoreValue);
        Debug.Log("Here");
        Destroy(this.gameObject);
    }
}
