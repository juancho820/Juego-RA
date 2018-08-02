using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {

    public GameObject Emitter;
    public GameObject Bullet;
    private GameObject Temporary_Bullet_Handler;
    public float Cooldown;
    private bool fireRate = true;
    public float Force;

	// Use this for initialization
	void Start () {
        Cooldown = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {

        if(CapsuleController.ispressed == true && fireRate == true)
        {
            Temporary_Bullet_Handler = Instantiate(Bullet, Emitter.transform.position, Emitter.transform.rotation) as GameObject;
            Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);
            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

            Temporary_RigidBody.AddForce(transform.forward * Force);

            Destroy(Temporary_Bullet_Handler, 4.0f);

            StartCoroutine(shoot());
        }
    }

    public IEnumerator shoot()
    {
        fireRate = false;
        //wait for some time
        yield return new WaitForSeconds(Cooldown);
        fireRate = true;
    }
}
