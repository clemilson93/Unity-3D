using UnityEngine;
using System.Collections;

public class EnemyBulletScript : MonoBehaviour {

	public int speed = 6;
	
	void Start () {
		Destroy( gameObject, 1.0f );
	}
	
	void Update () {
		transform.Translate( 0, 0, speed * Time.deltaTime );
	}
}
