using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosao : MonoBehaviour {
    
    int tempoDeVida;
    float contadorDoTempo;
    ControladorDoEstagio controladorDoEstagio;

    // Use this for initialization
    void Start()
    {
        tempoDeVida = 3;
        controladorDoEstagio = GameObject.Find("Controlador do estagio").GetComponent<ControladorDoEstagio>();
        ReiniciarVariaveis();
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
