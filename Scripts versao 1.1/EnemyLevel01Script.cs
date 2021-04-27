using UnityEngine;
using System.Collections;

public class EnemyLevel01Script : MonoBehaviour {

    public float mass;
    public float enginePower;
    public float weaponForce;
    public float damage;
    private GameObject objectLibrary;
    public float[] directionalVector;
    public float waitTime;
    public float initialTime;
    public float shieldPower;
    public float currentShieldPower;
    public SpriteRenderer shieldPowerBar;

    // Use this for initialization
    void Awake()
    {
        objectLibrary = GameObject.Find("ObjectLibrary");
        mass = 3.2f;
        enginePower = 2f;
        weaponForce = 2;
        waitTime = 1.5f;
        damage = 7;
        shieldPower = 40;
        currentShieldPower = shieldPower;
        directionalVector = new float[2];
        directionalVector[0] = -0.6f;
        directionalVector[1] = 0;
        initialTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //update shield bar
        UpdateShieldBar();
        //end update shield bar

        //move player ship
        float speed = enginePower / mass;
        transform.Translate(
            (enginePower * directionalVector[0]) / mass * Time.deltaTime,
            (enginePower * directionalVector[1]) / mass * Time.deltaTime,
            0);
        //end move player ship

        //shooting
        if (Mathf.Floor(Time.time) - initialTime >= waitTime)
        {
            float forceToLaser = mass * speed;
            GameObject laser = objectLibrary.GetComponent<ObjectLibraryScript>().GetLaser("EnemyLaser");
            laser.GetComponent<EnemyLaserScript>().Spawn(
                transform.position, transform.rotation,
                -1,
                0,
                forceToLaser + weaponForce
            );
            initialTime = Time.time;
        }
        //end shooting

        //verify limits
        Vector3 leftBotton = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z));
        Vector3 rightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, transform.position.z));
        if (transform.position.x <= leftBotton.x - GetComponent<SpriteRenderer>().bounds.size.x)
        {
            objectLibrary.GetComponent<ObjectLibraryScript>().ReplaceInstance(gameObject);
        }
        //end verify limits
    }

    public void Reset()
    {

    }

    public void Spawn(Vector3 position, Quaternion rotation, float vectorX, float vectorY, float force)
    {
        transform.position = position;
        transform.rotation = rotation;
        directionalVector[0] = vectorX;
        directionalVector[1] = vectorY;
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

    void OnTriggerEnter2D(Collider2D goCollider)
    {
        switch (goCollider.name)
        {
            case "PlayerShip":
                goCollider.GetComponent<PlayerShipScript>().currentShieldPower -= damage;
                objectLibrary.GetComponent<ObjectLibraryScript>().ReplaceInstance(gameObject);
                break;
            default:
                break;
        }
    }
}
