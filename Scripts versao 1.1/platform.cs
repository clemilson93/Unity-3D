using UnityEngine;
using System.Collections;

public class platform : MonoBehaviour {

    public float maxDis;
    Vector3 initPos;
    public Vector3 directionalVectors;
    public float speed;

	// Use this for initialization
	void Awake ()
    {
        initPos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 currtPos = transform.position;
        if (Vector3.Distance(initPos, currtPos) >maxDis)
        {
            directionalVectors = directionalVectors * -1;
        }
        transform.Translate(directionalVectors.x * Time.deltaTime * speed, directionalVectors.y * Time.deltaTime * speed, directionalVectors.z * Time.deltaTime * speed);
	}
    void OnCollisionStay(Collision goColl)
    {
        if (goColl.gameObject.tag == "Player")
        {
            goColl.gameObject.transform.parent = transform;
        }
    }
    void OnCollisionExit(Collision goColl)
    {
        if (goColl.gameObject.tag == "Player")
        {
            goColl.gameObject.transform.parent = null;
        }
    }
}
