using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public int force;

	void Update () {

        GetComponent<Rigidbody>().AddForce(transform.forward * force);

    }
}
