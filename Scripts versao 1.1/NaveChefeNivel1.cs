using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveChefeNivel1 : MonoBehaviour {

    public float velocidade;
    public int poderDeDano;
    public float tempoDeRecargaDoTiro;
    public float energiaMaxima;
    public float energiaAtual;
    public int valorDaPontuacaoExtra;
    public Color corDaBala;
    public Transform[] saidaDaBala;
    public float[] direcao = new float[3];//direcao[0] = esquerda/direita, direcao[1] = cima/baixo, direcao[2] = frente/voltar ******* intensidade do movimento é dada por valores de -1 a 1
    ControladorDoEstagio controladorDoEstagio;
    float[] tempoDoProximoTiro;//quantidade de elementos deve ser a mesma da quantidade saidas


    // Use this for initialization
    void Start()
    {
        controladorDoEstagio = GameObject.Find("Controlador do estagio").GetComponent<ControladorDoEstagio>();
        tempoDoProximoTiro = new float[saidaDaBala.Length];
    }

    // Update is called once per frame
    void Update()
    {
        //////////////////////////////// movimentação e limitação de movimento da nave//////////////////////////////////////////////////////////////
        transform.Translate(velocidade * direcao[0], velocidade * direcao[1], velocidade * direcao[2]);

        //////////////////////////////////ação quando a energia acabar/////////////////////////////////////////////////////
        if (energiaAtual == 0)
        {
            controladorDoEstagio.contadorDePontosDoJogador += valorDaPontuacaoExtra;
            controladorDoEstagio.FimDeUsoDoObjeto(gameObject.name, gameObject);
        }
    }

    ////////////////////////////////faz a nave atirar////////////////////////////////////////
    public void Atirar(int numeroDaSaida)
    {
        if (Time.time > tempoDoProximoTiro[numeroDaSaida])
        {
            GameObject bala = controladorDoEstagio.PegarObjetoDaLista("Bala");
            bala.transform.position = saidaDaBala[numeroDaSaida].transform.position;
            bala.transform.rotation = saidaDaBala[numeroDaSaida].transform.rotation;
            bala.transform.localScale = saidaDaBala[numeroDaSaida].transform.localScale;
            bala.GetComponent<Bala>().tagDoObjetoUtilizador = gameObject.tag;
            bala.GetComponent<Bala>().cor = corDaBala;
            bala.GetComponent<Bala>().valorDoDano = poderDeDano;
            bala.GetComponent<Bala>().ReiniciarVariaveis();
            bala.SetActive(true);
            saidaDaBala[numeroDaSaida].GetComponent<AudioSource>().Play();
            tempoDoProximoTiro[numeroDaSaida] = Time.time + tempoDeRecargaDoTiro;
        }
    }

    /////////////////////////////////aplica o dano gradativamente///////////////////////////////////////////////////////
    public void AplicarDano(int valorDoDano)
    {
        for (int contador = 0; contador < valorDoDano && energiaAtual > 0; contador++)
        {
            energiaAtual--;
        }
    }

    //////////////////////////////////verifica colisoes//////////////////////////////////////////////////////
    void OnTriggerEnter(Collider objeto)
    {
        if (objeto.gameObject.tag == "Jogador")
        {
            objeto.gameObject.GetComponent<Nave>().energiaAtual = 0;
        }
    }
}
