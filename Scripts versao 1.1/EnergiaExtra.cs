using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergiaExtra : MonoBehaviour {

    public int valorDaEnergiaExtra;
    float ultimaMarcacao;
    public int tempoDeVida;
    ControladorDoEstagio controladorDoEstagio;

    // Use this for initialization
    void Start ()
    {
        controladorDoEstagio = GameObject.Find("Controlador do estagio").GetComponent<ControladorDoEstagio>();
        ReiniciarVariaveis();

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - ultimaMarcacao > tempoDeVida)
        {
            controladorDoEstagio.FimDeUsoDoObjeto(gameObject.name, gameObject);
        }
    }

    ////////////////////////////////// tratar colisao////////////////////////////////////////
    void OnTriggerEnter(Collider objeto)
    {
        if (objeto.tag == "Jogador")
        {
            objeto.GetComponent<Nave>().AplicarEnergiaExtra(valorDaEnergiaExtra);
            GetComponent<AudioSource>().Play();
            GetComponent<Animator>().SetBool("capturada", true);
        }
    }

    ////////////////////////////para reiniciar variaveis////////////////////////////////////////////////////////////
    public void ReiniciarVariaveis()
    {
        ultimaMarcacao = Time.time;
    }
}
