using UnityEngine;
using System.Collections;

public class SCBala : MonoBehaviour {

    public float velocidade;

    void Update ()
    {
        transform.Translate(0, 0, velocidade);
	}
}
