using UnityEngine;
using System.Collections;

public class PlanoDeFundoMenuSC : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, -0.25f) * Time.time;
	}
}
