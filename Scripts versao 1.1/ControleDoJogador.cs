using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDoJogador : MonoBehaviour {

    GameObject cameraDoJogo;

    // Use this for initialization
    void Start ()
    {
        cameraDoJogo = GameObject.Find("Camera principal");
    }
	
	// Update is called once per frame
	void Update ()
    {
        /////////////////////////// Tiro da nave /////////////////////////////////////////////////////////////////////////
        if (Input.GetButton("Fire1"))
        {
            GetComponent<Nave>().Atirar(0);
        }

        //////////////////////////////// movimentação da nave//////////////////////////////////////////////////////////////
        GetComponent<Nave>().direcao[0] = Input.GetAxis("Horizontal");
        GetComponent<Nave>().direcao[2] = Input.GetAxis("Vertical");

        ///////////////////////verificar limites de acordo com a camera////////////////////////////////////////////////////////////////
        if (transform.position.x > cameraDoJogo.transform.position.x + cameraDoJogo.GetComponent<CameraDoJogo>().limiteHorizontal)
        {
            transform.position = new Vector3(cameraDoJogo.transform.position.x + cameraDoJogo.GetComponent<CameraDoJogo>().limiteHorizontal, transform.position.y, transform.position.z);
        }
        if (transform.position.x < cameraDoJogo.transform.position.x - cameraDoJogo.GetComponent<CameraDoJogo>().limiteHorizontal)
        {
            transform.position = new Vector3(cameraDoJogo.transform.position.x - cameraDoJogo.GetComponent<CameraDoJogo>().limiteHorizontal, transform.position.y, transform.position.z);
        }

        if (transform.position.z > (cameraDoJogo.transform.position.z - 5) + cameraDoJogo.GetComponent<CameraDoJogo>().limiteVertical)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, (cameraDoJogo.transform.position.z - 5) + cameraDoJogo.GetComponent<CameraDoJogo>().limiteVertical);
        }
        if (transform.position.z < (cameraDoJogo.transform.position.z - 5) - cameraDoJogo.GetComponent<CameraDoJogo>().limiteVertical)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, (cameraDoJogo.transform.position.z - 5) - cameraDoJogo.GetComponent<CameraDoJogo>().limiteVertical);
        }
    }
}
