#pragma strict

private var xVector : int;
private var yVector : int;
private var yVectorRotate : int;
private var zVector : int;
private var velocity : float;

function Start () {
	velocity = 10;//GetComponent(propertiesOfPlayerScript).velocity;
}

function Update () {
	if ( Input.GetKeyDown ( "up" ) || Input.GetKeyDown ( "w" ) ){ zVector = 1 * velocity; }
	if ( Input.GetKeyDown ( "down" ) || Input.GetKeyDown ( "s" ) ){ zVector = -1 * velocity; }
	if ( Input.GetKeyDown ( "right" ) || Input.GetKeyDown ( "d" ) ){ /*xVector = 1 * velocity;*/ yVectorRotate = 1; }
	if ( Input.GetKeyDown ( "left" ) || Input.GetKeyDown ( "a" ) ){ /*xVector = -1 * velocity;*/ yVectorRotate = -1;}
	if ( Input.GetKeyDown ( "space" ) ){ yVector = 1 * velocity; }
	
	if ( Input.GetKeyUp ( "up" ) || Input.GetKeyUp ( "w" ) ){ zVector = 0; }
	if ( Input.GetKeyUp ( "down" ) || Input.GetKeyUp ( "s" ) ){ zVector = 0; }
	if ( Input.GetKeyUp ( "right" ) || Input.GetKeyUp ( "d" ) ){ xVector = 0; yVectorRotate = 0; }
	if ( Input.GetKeyUp ( "left" ) || Input.GetKeyUp ( "a" ) ){ xVector = 0; yVectorRotate = 0; }
	if ( Input.GetKeyUp ( "space" ) ) { yVector = 0; }
	
	transform.Rotate( 0, yVectorRotate, 0 );
	transform.Translate( xVector * Time.deltaTime, yVector * Time.deltaTime, zVector * Time.deltaTime );
}