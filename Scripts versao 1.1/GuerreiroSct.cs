using UnityEngine;
using System.Collections;

public class GuerreiroSct : MonoBehaviour {

    public int pontosDeVidaAtual;
    public int pontosDeVidaMaxima;
    public float velocidade;
    void Awake ()
    {
        pontosDeVidaMaxima = 6;
        pontosDeVidaAtual = pontosDeVidaMaxima;
        velocidade = 1.5f;
    }

}
