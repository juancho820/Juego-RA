using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {

    public GameObject Emitter;
    public GameObject Bullet;
    private GameObject Temporary_Bullet_Handler;
    private GameObject Temporary_Bullet_Handler2;
    private GameObject Temporary_Bullet_Handler3;
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
            Temporary_Bullet_Handler.transform.Rotate(Vector3.left);

            Temporary_Bullet_Handler2 = Instantiate(Bullet, Emitter.transform.position, Emitter.transform.rotation) as GameObject;
            Temporary_Bullet_Handler2.transform.Rotate(Vector3.up * 20);

            Temporary_Bullet_Handler3 = Instantiate(Bullet, Emitter.transform.position, Emitter.transform.rotation) as GameObject;
            Temporary_Bullet_Handler3.transform.Rotate(Vector3.up * -20);

            Destroy(Temporary_Bullet_Handler, 4.0f);
            Destroy(Temporary_Bullet_Handler2, 4.0f);
            Destroy(Temporary_Bullet_Handler3, 4.0f);

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
