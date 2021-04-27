using UnityEngine;
using System.Collections;

public class PlanoDeFundoJogandoOJogoSC : MonoBehaviour {

    public float velocidadeDeMovimentoDoPlanoDeFundo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, velocidadeDeMovimentoDoPlanoDeFundo) * Time.time;
    }
}
