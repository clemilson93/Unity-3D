using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
	
	public int speed = 3;
	public int speedRotation = 90;
	public int scores = 0;
	public int currentHealth = 13;
	public int healthDefault = 13;
	public GameObject hand;
	public GameObject gun;
	public GameObject hud;
	Animator anim;

	void Start () 
	{
		anim = GetComponent<Animator>();
	}

	void Update () 
	{
		if( currentHealth <=0 ){
			GameObject.Find("Hud").GetComponent<HudScript>().gameOver();
			Destroy(gameObject);
		}
		if( Input.GetKeyDown( KeyCode.M ) )
		{
			if(hud.GetComponent<HudScript>().help == true)
			{
				hud.GetComponent<HudScript>().help = false;
			}
			else
			{
				hud.GetComponent<HudScript>().help = true;
			}
		}
		movePlayer();
		playAnimations();
		if( gun != null){

			if( Input.GetMouseButtonDown(0) ){
				if( gun.name == "SmallGun" )
				{
					gun.GetComponent<SmallGunScript>().shoot();
				}
				else if( gun.name == "MidGun" )
				{
					gun.GetComponent<MidGunScript>().shoot();
				}
				else if( gun.name == "LargeGun" )
				{
					gun.GetComponent<LargeGunScript>().shoot();
				}
			}

			holdGun();
			if( Input.GetKey( KeyCode.Q ) ){
				gun.transform.position = new Vector3( transform.position.x, 0.14f, transform.position.z );
				gun = null;
			}
		}

	}

	void OnTriggerEnter( Collider goCollider )
	{
		if( goCollider.gameObject.tag == "Item" )
		{
			hud.GetComponent<HudScript>().missionManager.itemsCollected();
			scores += goCollider.gameObject.GetComponent<ItemScript>().value;
			Destroy(goCollider.gameObject);
		}

		if( goCollider.gameObject.tag == "Bullet"){
			Destroy(goCollider.gameObject);
			currentHealth--;
		}

		if( goCollider.gameObject.tag == "Gun" )
		{
			pickUpGun( goCollider, goCollider.gameObject.name );

			if( goCollider.gameObject.name == "SmallGun" )
			{
				Debug.Log("SmallGun");
			}
			if( goCollider.gameObject.name == "MidGun" )
			{
				Debug.Log( "MidGun" );
			}
			if( goCollider.gameObject.name == "LargeGun" )
			{
				Debug.Log("LargeGun");
			}
		}

		if( goCollider.gameObject.tag == "EnemyGun" )
		{

		}

		if( goCollider.gameObject.tag == "EnemyBullet" )
		{

		}
	}
	
	public int calculateHealth()
	{
		int value = ( currentHealth * 100) / healthDefault;
		return value;
	}

	void holdGun(){
		gun.transform.position = hand.transform.position;
		gun.transform.rotation = hand.transform.rotation;
	}

	void pickUpGun( Collider goCollider, string gunId ){
		if( gun != null)
		{
			if( goCollider.gameObject.name == "SmallGun" && goCollider.gameObject.name == gun.name )
			{
				gun.GetComponent<SmallGunScript>().ammoAmount += goCollider.gameObject.GetComponent<SmallGunScript>().ammoAmount;
				Destroy( goCollider.gameObject );
			}
			else if( goCollider.gameObject.name == "MidGun" && goCollider.gameObject.name == gun.name )
			{
				gun.GetComponent<MidGunScript>().ammoAmount += goCollider.gameObject.GetComponent<MidGunScript>().ammoAmount;
				Destroy( goCollider.gameObject );
			}
			else if( goCollider.gameObject.name == "LargeGun" && goCollider.gameObject.name == gun.name )
			{
				gun.GetComponent<LargeGunScript>().ammoAmount += goCollider.gameObject.GetComponent<LargeGunScript>().ammoAmount;
				Destroy( goCollider.gameObject );
			}
		}
		else
		{
			gun = goCollider.gameObject;
		}
	}

	void movePlayer()
	{
		float vectorX = Input.GetAxis("Horizontal");
		float vectorZ = Input.GetAxis("Vertical");
		transform.Translate( 0, 0, vectorZ * speed * Time.deltaTime);
		transform.Rotate( 0, vectorX * speedRotation * Time.deltaTime, 0 );
	}

	void playAnimations()
	{
		if( Input.GetAxis("Vertical") !=0 )
		{
			anim.SetBool("run",true);
		}
		else
		{
			anim.SetBool("run",false);
		}
	}
}
