using UnityEngine;
using System.Collections;

public class SCArma : MonoBehaviour {
    public Transform saidaDaArma;
    public GameObject bala;

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(bala, saidaDaArma.position, saidaDaArma.rotation);
        }
	}
}
