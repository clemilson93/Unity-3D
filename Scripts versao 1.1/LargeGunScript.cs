using UnityEngine;
using System.Collections;

public class LargeGunScript : MonoBehaviour {

	public GameObject bulletPlace;
	public int ammoAmount = 3;
	public string gunId = "LargeGun";
	public Vector3 relativePosirion;
	public int damage = 5;

	public void shoot(){
		if(ammoAmount>0){
			GameObject bullet = Instantiate(Resources.Load("prefabs/guns/Bullet"), bulletPlace.transform.position, bulletPlace.transform.rotation ) as GameObject;
			bullet.GetComponent<BulletScript>().damage = damage;
			ammoAmount--;
		}
	}
}
