#pragma strict

function Start () {

}

function Update () {
	var hit : RaycastHit;
	Debug.DrawRay(transform.position, Vector3.down*3);
	var landingRay = new Ray(transform.position, Vector3.down);
	if(Physics.Raycast( transform.position, Vector3.down, hit, 3)){
		if(hit.collider.name == "cidadeParte01"){
			Debug.Log("Colisao");
		}
	}
}