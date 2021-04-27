using UnityEngine;
using System.Collections;

public class ThirdPersonControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(
            Input.GetAxis("Horizontal") * Time.deltaTime, //esquerda e direita
            0, 
            Input.GetAxis("Vertical") * Time.deltaTime //frente e volta
            );
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 300);
        }
	}
}
