using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CapsuleController : MonoBehaviour {


    private Rigidbody rb;
    private Animation anim;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {

        float x = CrossPlatformInputManager.GetAxis("Horizontal");
        float y = CrossPlatformInputManager.GetAxis("Vertical");

        Vector3 movement = new Vector3(x, 0, y);

        rb.velocity = movement * 1.2f;

        if(x != 0 && y != 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(x,y) * Mathf.Rad2Deg,transform.eulerAngles.z);
        }
        if (x != 0 || y != 0)
        {
            anim.Play("Run");
        }
        else
        {
            anim.Play("Idle");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Moneda")
        {
            Destroy(other.gameObject);
        }
    }
}
