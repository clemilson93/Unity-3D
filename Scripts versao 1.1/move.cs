using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(
            0,
            0,
            3 * Time.deltaTime * Input.GetAxis("Vertical"));
        transform.Rotate(
            0,
            3 * Input.GetAxis("Horizontal"),
            0);

    }
}
