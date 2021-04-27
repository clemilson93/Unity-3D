using UnityEngine;
using System.Collections;

public class EnemyLaserScript : MonoBehaviour {

    public float speed;
    public float mass;
    public float damage;
    private GameObject objectLibrary;
    public float range;
    public Vector2 startPoint;
    public float[] directionalVector;

    void Awake()
    {
        objectLibrary = GameObject.Find("ObjectLibrary");
        directionalVector = new float[2];
        mass = 0.8f;
        range = 5;
        speed = 0;
        damage = 2;
    }

    void Update()
    {
        //move the game object
        transform.Translate(speed * directionalVector[0] * Time.deltaTime, speed * directionalVector[1] * Time.deltaTime, 0);
        //end move the game object

        //verify limit
        if (Vector2.Distance(startPoint, transform.position) >= range)
        {
            objectLibrary.GetComponent<ObjectLibraryScript>().ReplaceInstance(gameObject);
        }
        //end verify limit
    }

    public void Spawn(Vector3 position, Quaternion rotation, float vectorX, float vectorY, float force)
    {
        startPoint = position;
        transform.position = position;
        transform.rotation = rotation;
        directionalVector[0] = vectorX;
        directionalVector[1] = vectorY;
        speed = force / mass;
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
