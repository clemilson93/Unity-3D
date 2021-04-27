using UnityEngine;
using System.Collections;

public class MidGunScript : MonoBehaviour {

	public GameObject bulletPlace;
	public int ammoAmount = 5;
	public string gunId = "MidGun";
	public Vector3 relativePosirion;
	public int damage = 3;
	
	public void shoot(){
		if(ammoAmount>0){
			GameObject bullet = Instantiate(Resources.Load("prefabs/guns/Bullet"), bulletPlace.transform.position, bulletPlace.transform.rotation ) as GameObject;
			bullet.GetComponent<BulletScript>().damage = damage;
			ammoAmount--;
		}
	}
}
