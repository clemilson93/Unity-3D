using UnityEngine;
using System.Collections;

public class Ring : MonoBehaviour {

	// Use this for initialization
	void Awake ()
    {
        GameObject.Find("Player").GetComponent<Player>().AddRing();
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
