using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

    public Collider myCollider, target1, target2;
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Physics.IgnoreCollision(myCollider, target1);
            Debug.Log("A");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Physics.IgnoreCollision(myCollider, target2);
            Debug.Log("S");
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.gameObject.name);
    }
}
