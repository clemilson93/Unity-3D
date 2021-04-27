using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDoChefe : MonoBehaviour {

    GameObject cameraDoJogo;

    // Use this for initialization
    void Start ()
    {
        GetComponent<Animator>().enabled = false;
        cameraDoJogo = GameObject.Find("Camera principal");
        GetComponent<NaveChefeNivel1>().direcao[0] = 0.2f;
        GetComponent<NaveChefeNivel1>().direcao[2] = 0.2f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<NaveChefeNivel1>().Atirar(0);
        GetComponent<NaveChefeNivel1>().Atirar(1);
        GetComponent<NaveChefeNivel1>().Atirar(2);
        GetComponent<NaveChefeNivel1>().Atirar(3);

        ///////////////////////verificar limites de acordo com a camera////////////////////////////////////////////////////////////////
        if (transform.position.x > cameraDoJogo.transform.position.x + cameraDoJogo.GetComponent<CameraDoJogo>().limiteHorizontal)
        {
            GetComponent<NaveChefeNivel1>().direcao[0] = +0.2f;
        }
        if (transform.position.x < cameraDoJogo.transform.position.x - cameraDoJogo.GetComponent<CameraDoJogo>().limiteHorizontal)
        {
            GetComponent<NaveChefeNivel1>().direcao[0] = -0.2f;
        }

        if (transform.position.z > (cameraDoJogo.transform.position.z - 5) + cameraDoJogo.GetComponent<CameraDoJogo>().limiteVertical)
        {
            GetComponent<NaveChefeNivel1>().direcao[2] = +0.2f;
        }
        if (transform.position.z < (cameraDoJogo.transform.position.z - 5) - cameraDoJogo.GetComponent<CameraDoJogo>().limiteVertical)
        {
            GetComponent<NaveChefeNivel1>().direcao[2] = -0.2f;
        }
    }
}
