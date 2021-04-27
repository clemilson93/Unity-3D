using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour {

	public int value = 100;

	void Update(){
		transform.Rotate( 1, 0, 1 );
	}
}
