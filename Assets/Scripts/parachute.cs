using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parachute : MonoBehaviour {
    public void parachuteAttacked()
    {
        //ad.GetComponent<AudioSource>().enabled = true;
        GameObject trooper = this.transform.parent.gameObject;
        trooper.GetComponent<Rigidbody2D>().drag = 1;
        gameObject.SetActive(false);
    }
}
