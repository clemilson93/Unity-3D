using UnityEngine;
using System.Collections;

public class Enemy00 : MonoBehaviour {

    float speed = -1;
    float initialPosition = 0;
    float distanceToWalk = 5;

	// Use this for initialization
	void Awake ()
    {
        initialPosition = transform.position.x;


    }
	
	// Update is called once per frame
	void Update ()
    {
        float distanceWalked = initialPosition - transform.position.x;
        if (distanceWalked >= distanceToWalk)
        {
            speed = 1;
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (distanceWalked <= -distanceToWalk)
        {
            speed = -1;
            GetComponent<SpriteRenderer>().flipX = false;
        }
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}
