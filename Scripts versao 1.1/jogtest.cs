﻿using UnityEngine;
using System.Collections;

public class jogtest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * 5, 0);
        transform.Translate(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * 2);
    }
}
