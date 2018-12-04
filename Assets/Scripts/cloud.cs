using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud : MonoBehaviour {
    public float speed;
    public Boundary boundary;

    // Update is called once per frame
    void Update()
    {
        transform.Translate((new Vector3(1, 0, 0)) * speed * Time.deltaTime);
        if (transform.position.x > boundary.xMax)
        {
            //add boundary instead of hard coding the val
            Destroy(this.gameObject);
        }
    }
}
