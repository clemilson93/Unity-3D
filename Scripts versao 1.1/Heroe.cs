using UnityEngine;
using System.Collections;

public class Heroe : MonoBehaviour {

	Animator anim;
    bool jump = false;
    public GameObject poof;
    float speed = 4;
    Vector3 initialPosition;
	// Use this for initialization
	void Awake () 
	{
		anim = GetComponent<Animator> ();
        initialPosition = transform.position;

    }
	
	// Update is called once per frame
	void Update () 
	{
        float xVector = Input.GetAxis("Horizontal");
        if (jump == true && xVector == 0)
        {
            anim.SetBool("wait", true);
        }
        else
        {
            anim.SetBool("wait", false);
        }

        if (xVector !=0 && jump == true)
        {
            anim.SetBool("run", true);
        }
        else
        {
            anim.SetBool("run", false);
        }

        if (jump == false)
        {
            anim.SetBool("jump", true);
        }
        else
        {
            anim.SetBool("jump", false);
        }

        if (Input.GetKey(KeyCode.RightArrow))
		{
            transform.Translate(speed * xVector * Time.deltaTime, 0, 0);
            GetComponent<SpriteRenderer>().flipX = false;
		}
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(speed * xVector * Time.deltaTime, 0, 0);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && jump == true)
		{
            GetComponent<Rigidbody2D>().AddForce(transform.up * 400);
		}
	}

    public void Respawn()
    {
        transform.position = initialPosition;
        gameObject.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D collider2d)
    {
        if (collider2d.gameObject.tag == "Enemy")
        {
            Instantiate(poof, transform.position, transform.rotation);
            gameObject.SetActive(false);
            GameObject.Find("Player").GetComponent<Player>().Death();
        }
        if (collider2d.gameObject.name == "Ring")
        {
            collider2d.gameObject.SetActive(false);
            GameObject.Find("Player").GetComponent<Player>().RingColected();
        }
    }

    void OnCollisionStay2D(Collision2D collision2d)
    {
        if (collision2d.gameObject.tag == "Platform" && transform.position.y - gameObject.GetComponent<Collider2D>().bounds.size.y / 2 > collision2d.gameObject.transform.position.y + collision2d.gameObject.GetComponent<Collider2D>().bounds.size.y/2)
        {
            jump = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision2d)
    {
        if (collision2d.gameObject.tag == "Platform")
        {
            jump = false;
        }
    }
}
