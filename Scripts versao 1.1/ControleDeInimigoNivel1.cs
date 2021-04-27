using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDeInimigoNivel1 : MonoBehaviour {

    GameObject cameraDoJogo;

    // Use this for initialization
    void Start ()
    {
        GetComponent<Nave>().direcao[2] = 0.2f;
        cameraDoJogo = GameObject.Find("Camera principal");
    }
	
	// Update is called once per frame
	void Update ()
    {
        ///////////////////////////////////////faz a nave atirar////////////////////////////////////////
        GetComponent<Nave>().Atirar(0);

        ///////////////////////verificar limites de acordo com a camera////////////////////////////////////////////////////////////////
        if (transform.position.x > cameraDoJogo.transform.position.x + cameraDoJogo.GetComponent<CameraDoJogo>().limiteHorizontal)
        {
            transform.position = new Vector3(cameraDoJogo.transform.position.x + cameraDoJogo.GetComponent<CameraDoJogo>().limiteHorizontal, transform.position.y, transform.position.z);
        }
        if (transform.position.x < cameraDoJogo.transform.position.x - cameraDoJogo.GetComponent<CameraDoJogo>().limiteHorizontal)
        {
            transform.position = new Vector3(cameraDoJogo.transform.position.x - cameraDoJogo.GetComponent<CameraDoJogo>().limiteHorizontal, transform.position.y, transform.position.z);
        }

        if (transform.position.z < (cameraDoJogo.transform.position.z - 10) - cameraDoJogo.GetComponent<CameraDoJogo>().limiteVertical)
        {
            GameObject.Find("Controlador do estagio").GetComponent<ControladorDoEstagio>().FimDeUsoDoObjeto(gameObject.name, gameObject);
        }
    }
}
