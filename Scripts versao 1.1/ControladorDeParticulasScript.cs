using UnityEngine;
using System.Collections;

public class ControladorDeParticulasScript : MonoBehaviour {

    public ParticleSystem particula;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //se a tecla T for pressionada o sistema de particulas vai tocar
        if (Input.GetKeyDown(KeyCode.T))
        {
            particula.Play();
        }
        //se a tecla P for pressionada o sistema de particulas vai parar
        if (Input.GetKeyDown(KeyCode.P))
        {
            particula.Pause();
        }
    }
}
