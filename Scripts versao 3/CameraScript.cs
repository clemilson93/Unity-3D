using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public GameObject goTarget;
	public GameObject fpsPosition;
	public bool isFps = false;
	public Quaternion rotationDefault;
	void Start () {
		rotationDefault = transform.rotation;
	}

	void Update () {
		if( goTarget != null && isFps == false )
		{
			float xTarget = goTarget.transform.position.x;
			float zTarget = goTarget.transform.position.z;
			transform.position = new Vector3( xTarget, 6, zTarget - 2 );
		}

		if( isFps == true )
		{
			float yRotation = Input.GetAxis("Mouse X");
			goTarget.transform.Rotate( 0, yRotation * 90 * Time.deltaTime, 0 );
			transform.Rotate( 0, yRotation * 90 * Time.deltaTime, 0 );
		}

		if( Input.GetKey(KeyCode.LeftShift))
		{
			Debug.Log("checando");
			transform.position = fpsPosition.transform.position;
			transform.rotation = fpsPosition.transform.rotation;
			isFps = true;
		}
		else if( Input.GetKeyUp(KeyCode.LeftShift))
		{
			transform.rotation = rotationDefault;
			isFps = false;
		}
	}
}
