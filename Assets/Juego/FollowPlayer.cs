using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    private GameObject wayPoint;
    //private Animation anim;
    private Vector3 wayPointPos;
    //This will be the zombie's speed. Adjust as necessary.
    private float speed = 4.0f;
    void Start()
    {
        //At the start of the game, the zombies will find the gameobject called wayPoint.
        //anim.GetComponent<Animation>();
        wayPoint = GameObject.FindGameObjectWithTag("Player");
        
    }

    void Update()
    {
        wayPointPos = new Vector3(wayPoint.transform.position.x, transform.position.y, wayPoint.transform.position.z);
        //Here, the zombie's will follow the waypoint.
        transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);
        //if (wayPointPos- > 5)
        //{
        //    anim.Play("Walk");
        //}
        //else
        //{
        //    anim.Play("Idle");
        //}
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Debug.Log("Tocado");
            Destroy(gameObject);
        }

    }
}
