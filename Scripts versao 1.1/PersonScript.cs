using UnityEngine;
using System.Collections;

public class PersonScript : MonoBehaviour {

    public Animator espada;
    float tempoCorrido;
    float tempoDeEsperaDeAtaque = 3;

	// Use this for initialization
	void Start ()
    {
        tempoCorrido = Time.time;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetAxis("Fire1") == 1)
        {
            espada.SetBool("ataque",  true);
        }
        if (Input.GetAxis("Fire1") == 0)
        {
            espada.SetBool("ataque", false);
        }
        transform.Translate(Input.GetAxis("Horizontal")*Time.deltaTime*2, 0, Input.GetAxis("Vertical") * Time.deltaTime*2);
        transform.Rotate(0, Input.GetAxis("Mouse X") * 5, 0);

    }
}
