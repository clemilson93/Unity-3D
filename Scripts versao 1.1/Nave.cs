using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour {

    public float velocidade;
    public int poderDeDano;
    public float tempoDeRecargaDoTiro;
    public float energiaMaxima;
    public float energiaAtual;
    public int valorDaPontuacaoExtra;
    public Color corDaBala;
    public Transform[]saidaDaBala;
    public float[] direcao = new float[3];//direcao[0] = esquerda/direita, direcao[1] = cima/baixo, direcao[2] = frente/voltar ******* intensidade do movimento é dada por valores de -1 a 1
    ControladorDoEstagio controladorDoEstagio;
    GameObject explosao;
    GameObject item;
    float[]tempoDoProximoTiro;//quantidade de elementos deve ser a mesma da quantidade saidas


    // Use this for initialization
    void Start ()
    {
        controladorDoEstagio = GameObject.Find("Controlador do estagio").GetComponent<ControladorDoEstagio>();
        tempoDoProximoTiro = new float[saidaDaBala.Length];
        ReiniciarVariaveis();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //////////////////////////////// movimentação e limitação de movimento da nave//////////////////////////////////////////////////////////////
        transform.Translate(velocidade * direcao[0], velocidade * direcao[1], velocidade * direcao[2]);
        
        //////////////////////////////////ação quando a energia acabar/////////////////////////////////////////////////////
        if (energiaAtual == 0)
        {
           if (gameObject.tag == "Inimigo")
            {
                GerarExplosao();
                controladorDoEstagio.contadorDePontosDoJogador += valorDaPontuacaoExtra;
                if (Random.Range(0, 2) == 1)
                {
                    item = controladorDoEstagio.PegarObjetoDaLista("Energia extra");
                    item.transform.position = transform.position;
                    item.GetComponent<EnergiaExtra>().ReiniciarVariaveis();
                    item.SetActive(true);
                }
            }
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

    /////////////////////////////////aplica a energia gradativamente///////////////////////////////////////////////////////
    public void AplicarEnergiaExtra(int valorDaEnergiaExtra)
    {
        for (int contador = 0; contador < valorDaEnergiaExtra && energiaAtual < energiaMaxima; contador++)
        {
            energiaAtual++;
        }
    }

    /////////////////////////////gerar uma explosao///////////////////////////////////////////////
    public void GerarExplosao()
    {
        explosao = controladorDoEstagio.PegarObjetoDaLista("Explosao");
        explosao.transform.position = transform.position;
        explosao.GetComponent<Explosao>().ReiniciarVariaveis();
        explosao.SetActive(true);
    }

    ////////////////////////////para reiniciar variaveis////////////////////////////////////////////////////////////
    public void ReiniciarVariaveis()
    {
        energiaAtual = energiaMaxima;
    }

    //////////////////////////////////verifica colisoes//////////////////////////////////////////////////////
    void OnTriggerEnter(Collider objeto)
    {
        //execulta a acao quando a tag do gameobject colisor é igual o da tag escolhida e quando a tag do gameobject colisor é diferente da tag do gameobject utilizador
        if (objeto.gameObject.tag == "Jogador" && objeto.gameObject.tag != gameObject.tag)
        {//isso ocorrera quando a nave for um inimigo
            controladorDoEstagio.contadorDePontosDoJogador += valorDaPontuacaoExtra;
            objeto.gameObject.GetComponent<Nave>().AplicarDano(poderDeDano);
            GerarExplosao();
            controladorDoEstagio.FimDeUsoDoObjeto(gameObject.name, gameObject);
        }
    }
}
