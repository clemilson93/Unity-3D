using UnityEngine;
using System.Collections;

public class maratonista : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x>-0.9f)
        {
            transform.Translate(-0.9f, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < 0.9f)
        {
            transform.Translate(0.9f, 0, 0);
        }
    }

    void OnTriggerEnter(Collider gObject)
    {
        if (gObject.gameObject.name == "Obstaculo")
        {
            //tocar um som
            //chama a tela de fim de jogo
            //desativa este game object
        }
    }
}
