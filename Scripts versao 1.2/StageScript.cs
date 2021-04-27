using UnityEngine;
using System.Collections;

public class StageScript : MonoBehaviour {

	void Update () {
		Debug.Log( "Passou" );
		transform.Rotate( 0, 15 * Time.deltaTime, 0 );
	}
}
