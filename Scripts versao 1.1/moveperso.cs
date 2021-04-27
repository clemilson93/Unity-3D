using UnityEngine;
using System.Collections;

public class moveperso : MonoBehaviour {

    Animator anim;
    bool pulo = false;


	// Use this for initialization
	void Start () {
        

    }
	
	// Update is called once per frame
	void Update ()
    {
        anim = GetComponent<Animator>();
        float zVector = Input.GetAxis("Vertical");
        float yVector = Input.GetAxis("Horizontal");
        float speed = zVector * Time.deltaTime * 6;
        float rSpeed = yVector * 3;
        if (speed != 0)
        {
            anim.SetBool("correr", true);
        }
        else
        {
            anim.SetBool("correr", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && pulo==true)
        {
            anim.SetBool("pular", true);
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(transform.up * 400);
        }


        transform.Rotate(0, rSpeed, 0);
        transform.Translate(0, 0, speed);
    }

    void OnCollisionStay(Collision goColl)
    {
        if (goColl.gameObject.tag == "ground")
        {
            pulo = true;
        }
    }
    void OnCollisionExit(Collision goColl)
    {
        if (goColl.gameObject.tag == "ground")
        {
            pulo = false;
            anim.SetBool("pular", false);
        }
    }
}
