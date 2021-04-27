using UnityEngine;
using System.Collections;

public class LaserDaNaveDoJogadorSC : MonoBehaviour {

    public float velocidadeDoLaserDaNaveDoJogador;
    public float tempoDeVidaDoLaser;
    public int dano;

	// Use this for initialization
	void Start ()
    {
        gameObject.name = "Laser da nave do jogador";
        Destroy(gameObject, tempoDeVidaDoLaser);
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(0, 0, velocidadeDoLaserDaNaveDoJogador);
	}
}
