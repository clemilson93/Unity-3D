using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriadorDeInimigos : MonoBehaviour {

    public bool fimDeEstagio;
    public GameObject chefe;
    float ultimaMarcacaoNaveInimigaNivel1;
    float ultimaMarcacaoNaveInimigaNivel2;
    public ControladorDoEstagio controladorDoEstagio;

    // Use this for initialization
    void Start ()
    {
        fimDeEstagio = false;
        ultimaMarcacaoNaveInimigaNivel1 = 0;
        ultimaMarcacaoNaveInimigaNivel2 = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        ///////////////////////////////verifica fim do estagio e ativa o chefe da fase///////////////////////////////////
        if (fimDeEstagio)
        {
            chefe.SetActive(true);
            gameObject.SetActive(false);
        }

        ///// Criação de inimigos nivel 1 /////////////////////////////////////////////////////////////////////////
        if (Time.time - ultimaMarcacaoNaveInimigaNivel1 > 3 && !fimDeEstagio)
        {
            GameObject naveInimigaNivel1 = controladorDoEstagio.PegarObjetoDaLista("Nave inimiga nivel 1");
            naveInimigaNivel1.transform.position = transform.position;
            naveInimigaNivel1.transform.rotation = transform.rotation;
            naveInimigaNivel1.GetComponent<Nave>().ReiniciarVariaveis();
            naveInimigaNivel1.SetActive(true);
            ultimaMarcacaoNaveInimigaNivel1 = Time.time;
        }

        ///// Criação de inimigos nivel 2 /////////////////////////////////////////////////////////////////////////
        if (Time.time - ultimaMarcacaoNaveInimigaNivel2 > 6 && !fimDeEstagio)
        {
            GameObject naveInimigaNivel2 = controladorDoEstagio.PegarObjetoDaLista("Nave inimiga nivel 2");
            naveInimigaNivel2.transform.position = transform.position;
            naveInimigaNivel2.transform.rotation = transform.rotation;
            naveInimigaNivel2.GetComponent<Nave>().ReiniciarVariaveis();
            naveInimigaNivel2.SetActive(true);
            ultimaMarcacaoNaveInimigaNivel2 = Time.time;
        }
    }
}
