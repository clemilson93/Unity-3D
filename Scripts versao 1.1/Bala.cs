using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {

    public float velocidade;
    public int valorDoDano;
    public int tempoDeVida;
    public Color cor;
    float contadorDoTempo;
    ControladorDoEstagio controladorDoEstagio;
    public string tagDoObjetoUtilizador;

    // Use this for initialization
    void Start ()
    {
        controladorDoEstagio = GameObject.Find("Controlador do estagio").GetComponent<ControladorDoEstagio>();
        ReiniciarVariaveis();
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(0, 0, velocidade);

        if (Time.time - contadorDoTempo > tempoDeVida)
        {
            FimDeUtilizacao();
        }
    }

    //////////////////////////////tratar o fim de utilizacao////////////////////////////////////////
    public void FimDeUtilizacao()
    {
        controladorDoEstagio.FimDeUsoDoObjeto(gameObject.name, gameObject);
    }

    ////////////////////////////para reiniciar variaveis////////////////////////////////////////////////////////////
    public void ReiniciarVariaveis()
    {
        contadorDoTempo = Time.time;
        GetComponent<Renderer>().material.color = cor;
    }

    //////////////////////////////////verifica colisoes//////////////////////////////////////////////////////
    void OnTriggerEnter(Collider objeto)
    {
        //execulta a acao quando a tag do gameobject colisor é igual o da tag escolhida e quando a tag do gameobject colisor é diferente da tag do gameobject utilizador
        if (objeto.gameObject.tag == "Jogador" && objeto.gameObject.tag != tagDoObjetoUtilizador)
        {
            objeto.gameObject.GetComponent<Nave>().AplicarDano(valorDoDano);
            FimDeUtilizacao();
        }
        if (objeto.gameObject.tag == "Inimigo" && objeto.gameObject.tag != tagDoObjetoUtilizador)
        {
            objeto.gameObject.GetComponent<Nave>().AplicarDano(valorDoDano);
            FimDeUtilizacao();
        }
        if (objeto.gameObject.tag == "Bala" && objeto.gameObject.tag != tagDoObjetoUtilizador)
        {
            FimDeUtilizacao();
        }
    }
}
