﻿using System.Collections;
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

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
	}
	
    public void SpawnObject()
    {
        GameObject enemmigo = Instantiate(spawnee, transform.position, transform.rotation);
        enemmigo.transform.parent = transform.parent;
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }
}
