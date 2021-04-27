using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	
	public int health = 3;
	public int speed = 2;
	public GameObject gun;
	public GameObject hud;
	public bool followPlayer = false;
	public int alarm0 = 0;
	public int alarm1 = 0;
	public bool canShoot = true;
	Animator anim;
	
	void Start()
	{
		anim = GetComponent<Animator>();
	}

	void Update () 
	{
		alarm0++;
		alarm1++;
		alarm1M ();
		playAnimations();
		
		if( health <= 0)
		{
			hud.GetComponent<HudScript>().missionManager.enemyDefeated();
			Destroy(gameObject);
		}
		
		if( followPlayer == false)
		{
			alarm0M ();
			transform.Translate( 0, 0, speed * Time.deltaTime );
		}
		else
		{
			transform.Translate( 0, 0, speed * Time.deltaTime );
		}
		
		GameObject player = GameObject.Find("Player");

		if (player != null) 
		{
			Debug.DrawRay(transform.position, transform.forward * 3.0f);
			RaycastHit hit;
			if(Physics.Raycast( transform.position, transform.forward, out hit, 3.0f ))
			{
				if( hit.collider.gameObject.tag == "Wall" )
				{
					followPlayer = false;
					canShoot = false;
				}
				if( hit.collider.gameObject.tag == "Enemy" )
				{
					canShoot = false;
				}
			}

			float step2 = (player.transform.position.z - transform.position.z) * (player.transform.position.z - transform.position.z);
			float step1 = (player.transform.position.x - transform.position.x) * (player.transform.position.x - transform.position.x);
			float distance = Mathf.Sqrt( step1 + step2 );

			if( distance < 3 )
			{
				speed = 0;
				followPlayer = true;
				transform.LookAt( player.transform );
				if( canShoot == true)
				{
					shoot();
					canShoot = false;
				}
			}
			if( distance > 3 && distance < 5 )
			{
				speed = 2;
				transform.LookAt( player.transform );
				followPlayer = true;
			}

		}

	}
	
	void OnTriggerEnter( Collider goCollider )
	{
		if( goCollider.gameObject.tag == "Bullet")
		{
			health -= goCollider.GetComponent<BulletScript>().damage;
			Destroy(goCollider.gameObject);
		}
	}

	void alarm0M()
	{
		if( alarm0 % (30 * 3) == 0)
		{
			float val = Random.value * 4;
			if( val>=0&&val<=1)
			{
				transform.Rotate(0,90,0);
			}
			else if( val>=1&&val<=2)
			{
				transform.Rotate(0,-90,0);
			}
			else if( val>=2&&val<=3)
			{
				transform.Rotate(0,180,0);
			}
			else if( val>=3&&val<=4)
			{
				transform.Rotate(0,-180,0);
			}
			alarm0 = 0;
		}
	}
	void alarm1M()
	{
		if (alarm1 % (30 * 1) == 0) 
		{
			canShoot = true;
		}
	}

	void shoot()
	{
		if( gun.name == "SmallGun" )
		{
			gun.GetComponent<SmallGunScript>().shoot();
			gun.GetComponent<SmallGunScript>().ammoAmount +=1;
		}
		else if( gun.name == "MidGun" )
		{
			gun.GetComponent<MidGunScript>().shoot();
			gun.GetComponent<MidGunScript>().ammoAmount +=1;
		}
		else if( gun.name == "LargeGun" )
		{
			gun.GetComponent<LargeGunScript>().shoot();
			gun.GetComponent<LargeGunScript>().ammoAmount +=1;
		}
	}

	void playAnimations()
	{
		if( speed !=0 )
		{
			anim.SetBool("run",true);
		}
		else
		{
			anim.SetBool("run",false);
		}
	}
}