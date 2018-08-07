using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletas : MonoBehaviour {

    public int Force;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        GetComponent<Rigidbody>().AddForce(transform.forward * Force);

    }
}
