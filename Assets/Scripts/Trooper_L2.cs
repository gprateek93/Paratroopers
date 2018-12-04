using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trooper_L2 : MonoBehaviour {
    public Rigidbody2D rb;
    public GameObject parent;
    public GameObject child;
    public GameObject child2;
    public GameObject enemy;
    public float parachute_inflator;
    //private PlayerController player;
    public GameObject terroristPrefab;
    public GameObject terroristRevPrefab;
    float startTime;
    int flagOpen = 0;
    public static int countRight = 0;
    public static int countLeft = 0;
    public static int reachedLeft = 0;
    public static int reachedRight = 0;
    public static int explode;
    public GameObject[] troopers;
    public AudioSource ad;
    public AudioClip a1;
    // Use this for initialization
    void Start()
    {
        child.SetActive(false);
        startTime = Time.time;
        rb = GetComponent<Rigidbody2D>();

    }
    // Update is called once per frame
    void Update()
    {
        if ((Time.time - startTime) > parachute_inflator && flagOpen == 0)
        {
            openParachute();
        }
    }
    void openParachute()
    {
        child.SetActive(true);
        flagOpen = 1;
        rb.drag = 20;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Background")
        {
            if (!child.activeInHierarchy)
            {
                ad.clip = a1;
                ad.Play();
                transform.position = Vector3.one * 9999f; // move the game object off screen while it finishes it's sound, then destroy it
                Destroy(this.gameObject, a1.length);
            }
            else
            {

                rb.gravityScale = 0;
                child.SetActive(false);
                if (transform.position.x > 1.7f)
                {
                    countRight++;
                }
                if (transform.position.x < -1f)
                {
                    countLeft++;
                }
                Debug.Log("Trooper Count R = " + countRight + " L = " + countLeft);
                Debug.Log("troopers Length = " + troopers.Length);
                if (countLeft >= 4)
                {
                    if (troopers.Length == 0)
                    {
                        troopers = GameObject.FindGameObjectsWithTag("trooper");
                    }
                    Debug.Log(troopers.Length);
                    foreach (GameObject troop in troopers)
                    {
                        if (troop.transform.position.x < -1f && reachedLeft < 4)
                        {
                            reachedLeft++;
                            Instantiate(terroristPrefab, troop.transform.position, troop.transform.rotation);
                            Destroy(troop);
                        }
                    }
                }
                if (countRight >= 4)
                {
                    if (troopers.Length == 0)
                    {
                        Debug.Log("No Troopers Right Side");
                        troopers = GameObject.FindGameObjectsWithTag("trooper");
                    }
                    Debug.Log(troopers.Length);
                    foreach (GameObject troop in troopers)
                    {
                        if (troop.transform.position.x > 1.7f && reachedRight < 4)
                        {
                            reachedRight++;
                            Instantiate(terroristRevPrefab, troop.transform.position, troop.transform.rotation);
                            Destroy(troop);

                        }
                    }
                }
                Debug.Log("reached Count R = " + reachedRight + " L = " + reachedLeft);
            }

        }
    }
    public void trooperAttacked()
    {
        if(child2.activeInHierarchy){
            child2.SetActive(false);
            return;
        }
        ad.clip = a1;
        if (a1 == null)
            Debug.Log("Here");
        ad.Play();
        transform.position = Vector3.one * 9999f; // move the game object off screen while it finishes it's sound, then destroy it
        Destroy(this.gameObject, a1.length);
    }
}
