using UnityEngine;
using System.Collections;

public class teste : MonoBehaviour {
    Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, 30));
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Input.GetAxis("Mouse X") * 15, Input.GetAxis("Mouse Y") * 15, 0);
        //transform.localRotation = rotation;
	}
}
