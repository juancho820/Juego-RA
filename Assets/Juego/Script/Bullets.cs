using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {

    public GameObject emitter;
    public GameObject bullet;
    private GameObject Temporary_Bullet_Handler;
    private GameObject Temporary_Bullet_Handler2;
    private GameObject Temporary_Bullet_Handler3;
    public ParticleSystem ps;
    private float cooldown;
    private bool fireRate = true;

	// Use this for initialization
	void Start () {
        cooldown = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {

        if(CapsuleController.ispressed == true && fireRate == true)
        {
            ps.Play();

            Temporary_Bullet_Handler = Instantiate(bullet, emitter.transform.position, emitter.transform.rotation) as GameObject;
            Temporary_Bullet_Handler.transform.Rotate(Vector3.left);

            Temporary_Bullet_Handler2 = Instantiate(bullet, emitter.transform.position, emitter.transform.rotation) as GameObject;
            Temporary_Bullet_Handler2.transform.Rotate(Vector3.up * 20);

            Temporary_Bullet_Handler3 = Instantiate(bullet, emitter.transform.position, emitter.transform.rotation) as GameObject;
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
        yield return new WaitForSeconds(cooldown);
        fireRate = true;
    }
}
