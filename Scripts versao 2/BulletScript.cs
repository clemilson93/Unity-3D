using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public int speed = 6;
	public int damage = 0;

	void Start () {
		Destroy( gameObject, 2.0f );
	}

	void Update () {
		transform.Translate( 0, 0, speed * Time.deltaTime );
	}
}
