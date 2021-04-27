using UnityEngine;
using System.Collections;

public class ExplosaoSC : MonoBehaviour {

    public float tempoDeVidaDaExplosao;

	// Use this for initialization
	void Start ()
    {
        Destroy(gameObject, tempoDeVidaDaExplosao);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
