using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrel_Rotation : MonoBehaviour {

    public Transform pivot;
    public float speed;
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("left") && transform.eulerAngles.z<175)
            transform.RotateAround(pivot.position, Vector3.forward, speed * Time.deltaTime);
        if (Input.GetKey("right")&& transform.eulerAngles.z>10)
            transform.RotateAround(pivot.position, Vector3.back, speed * Time.deltaTime);
    }
}
