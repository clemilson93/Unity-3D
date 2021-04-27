using UnityEngine;
using System.Collections;

public class FlorMonstroSct : MonoBehaviour {

    public int pontosDeVidaAtual;
    public int pontosDeVidaMaxima;
    public float velocidade;

    void Awake()
    {
        GameObject.Find("ObservadorDoJogo").GetComponent<ControleDoObservadorSct>().monstrosNoEstagio += 1;
        pontosDeVidaMaxima = 6;
        pontosDeVidaAtual = pontosDeVidaMaxima;
        velocidade = 0.5f;
    }
}
