using UnityEngine;
using System.Collections;

public class PlayerShipScript : MonoBehaviour {

	public float mass;
	public float enginePower;
    public float weaponForce;
    public float shieldPower;
    public float currentShieldPower;
    private GameObject objectLibrary;
	public float[]directionalVector;
    public SpriteRenderer shieldPowerBar;

    // Use this for initialization
    void Awake ()
	{
		objectLibrary = GameObject.Find ("ObjectLibrary");
		mass = 3.2f;
		enginePower = 2;
        weaponForce = 2;
        shieldPower = 40;
        currentShieldPower = shieldPower;
        directionalVector = new float[2];
		directionalVector [0] = 0;
		directionalVector [1] = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
        //shield bar
        UpdateShieldBar();
        //end shield bar

        //move player ship
        directionalVector [0] = Input.GetAxis ("Horizontal");
		directionalVector [1] = Input.GetAxis ("Vertical");
        float speed = enginePower / mass;
        transform.Translate (
            (enginePower * directionalVector[0]) / mass * Time.deltaTime,
            (enginePower * directionalVector[1]) / mass * Time.deltaTime, 
            0 );
		//end move player ship

		//shooting
		if(Input.GetKeyDown(KeyCode.H))
		{
			float forceToLaser = mass * speed;
			GameObject laser = objectLibrary.GetComponent<ObjectLibraryScript>().GetLaser("PlayerShipLaser");
			laser.GetComponent<PlayerShipLaserScript> ().spawn ( 
				transform.position, transform.rotation,
                1,
                0,
				forceToLaser + weaponForce
			);

		}
        //end shooting

        //verify limits
        Vector3 leftBotton = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z));
        Vector3 rightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, transform.position.z));
        if (transform.position.x <= leftBotton.x + GetComponent<SpriteRenderer>().bounds.size.x)
        {
            transform.position = new Vector2(leftBotton.x + GetComponent<SpriteRenderer>().bounds.size.x, transform.position.y);
        }
        if (transform.position.y <= leftBotton.y + GetComponent<SpriteRenderer>().bounds.size.y)
        {
            transform.position = new Vector2(transform.position.x, leftBotton.y + GetComponent<SpriteRenderer>().bounds.size.y);
        }
        if (transform.position.x >= rightTop.x - GetComponent<SpriteRenderer>().bounds.size.x)
        {
            transform.position = new Vector2(rightTop.x - GetComponent<SpriteRenderer>().bounds.size.x, transform.position.y);
        }
        if (transform.position.y >= rightTop.y - GetComponent<SpriteRenderer>().bounds.size.y)
        {
            transform.position = new Vector2(transform.position.x, rightTop.y - GetComponent<SpriteRenderer>().bounds.size.y);
        }
        //end verify limits
    }

    public void Reset()
    {
        shieldPower = 40;
    }

    void OnTriggerEnter2D(Collider2D goCollider)
    {
        switch (goCollider.name)
        {
            case "EnemyLaser":
                currentShieldPower -= goCollider.GetComponent<EnemyLaserScript>().damage;
                break;
            case "EnemyLevel01":
                
                break;
            default:
                break;
        }

    }

    void UpdateShieldBar()
    {
        float levelBar = currentShieldPower / shieldPower;
        shieldPowerBar.transform.localScale = new Vector3(levelBar, 1, 1);
        shieldPowerBar.transform.position = new Vector2(
            transform.position.x - shieldPowerBar.sprite.bounds.size.x / 2,
            transform.position.y + GetComponent<SpriteRenderer>().sprite.bounds.size.y
            );
    }
}
