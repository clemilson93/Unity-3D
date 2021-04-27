using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class jogador : MonoBehaviour {

    public float velocidade = 0.1f;
    float distancia = 0;
    int pontos = 0;
    int pontosPorDistancia = 1;
    public int moedas = 0;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (Time.time%30 == 0)
        {
            velocidade = velocidade + 0.05f;
        }
        if (Time.time % 1 == 0)
        {
            pontos = pontos + pontosPorDistancia;
        }

        GameObject.Find("Pontos").GetComponent<Text>().text = "Pontos: " + pontos+" + "+pontosPorDistancia;
        GameObject.Find("Moedas").GetComponent<Text>().text = "Moedas: " + moedas;
    }
}
