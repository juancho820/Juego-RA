using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawn : MonoBehaviour {

    [SerializeField]
    private GameObject spawnee;

    private bool stopSpawning = false;

    [SerializeField]
    private float spawnTime;
    [SerializeField]
    private float spawnDelay;

    private float tiempo;

	// Use this for initialization
	void Start () {
        //InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
	}

    public void Update()
    {
        tiempo += Time.deltaTime;

        if(tiempo >= spawnTime)
        {
            SpawnObject();
            tiempo = 0;
        }
    }

    public void SpawnObject()
    {
        GameObject enemmigo = Instantiate(spawnee, transform.position, transform.rotation);
        enemmigo.transform.parent = transform.parent;
        //if (stopSpawning)
        //{
        //    CancelInvoke("SpawnObject");
        //}
    }
}
