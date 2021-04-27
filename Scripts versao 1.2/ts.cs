using UnityEngine;
using System.Collections;

public class ts : MonoBehaviour {

	public EnemyLaserScript el;

	// Use this for initialization
	void Start () 
	{
		// how to instanciate an enemy laser
		/*EnemyLaserScript inst = Instantiate (el, new Vector3 (0, 0, 0), new Quaternion (0,0,0,0))as EnemyLaserScript;
		inst.speed = 0.2f;
		Debug.Log ("creat");
		inst.directionalVector[0] = 1;
		inst.directionalVector[1] = -1;
		inst.gameObject.SetActive (true);*/

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
