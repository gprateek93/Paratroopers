using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrorist_movement : MonoBehaviour {

    public float speed;
    public float direction;
    private Rigidbody2D rb;
    private Animator m_animator;
    private PlayerController player;
    public static int count = 0;
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        m_animator = this.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        if(direction <= -1f){
            transform.Rotate(0, 180, 0);
        }
    }
    // Update is called once per frame
    void Update () {
        if (transform.position.x > 1f || transform.position.x < -1f)
        {
            transform.Translate((new Vector3(1f, 0, 0)) * speed * Time.deltaTime);
        }
        else{
            m_animator.GetComponent<Animator>().enabled = false;
            rb.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        rb.GetComponent<Rigidbody2D>().gravityScale = 0;
        if(collision.name == "Player"){
            count++;
            if (count >=4)
            {
                Debug.Log("4 terrorist arrives");
                player.die();
            }
        }
    }
}
