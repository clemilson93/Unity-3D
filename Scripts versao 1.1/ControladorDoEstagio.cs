using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControladorDoEstagio : MonoBehaviour {

    //graficos
    public Text textoEstagioConcluido;
    public Text textoPontosDoJogador;
    public Text textoFimDeJogo;
    public Image barraDeEnergiaDoJogador;

    //objetos
    public GameObject naveDoJogador;
    public GameObject naveInimigaNivel1;
    public GameObject naveInimigaNivel2;
    public GameObject explosao;
    public GameObject energiaExtra;
    public GameObject bala;
    public GameObject criadorDeInimigos;
    public GameObject informacoesDoJogo;

    //animacoes
    public Animator animacaoDaCamera;

    //listas
    List<GameObject> listaDeNavesInimigasNivel1 = new List<GameObject>();
    List<GameObject> listaDeNavesInimigasNivel2 = new List<GameObject>();
    List<GameObject> listaDeExplosoes = new List<GameObject>();
    List<GameObject> listaDeEnergiasExtra = new List<GameObject>();
    List<GameObject> listaDeBalas = new List<GameObject>();

    //outras variaveis
    public int contadorDePontosDoJogador;
    public bool fimDeJogo;
    public bool estagioConcluido;
    
    // Use this for initialization
    void Start()
    {
        contadorDePontosDoJogador = GameObject.Find("Informacoes do jogo").GetComponent<InformacoesDoJogo>().pontosDoJogador;
        fimDeJogo = false;
        estagioConcluido = false;
    }

    // Update is called once per frame
    void Update()
    {
        /////////////////////////////////atualizando informações da tela//////////////////////////////////////
        barraDeEnergiaDoJogador.fillAmount = naveDoJogador.GetComponent<Nave>().energiaAtual / naveDoJogador.GetComponent<Nave>().energiaMaxima;
        textoPontosDoJogador.text = "Pontos marcados\n" + contadorDePontosDoJogador;

        ////////////////////////verifica estado fim do jogo//////////////////////////////////////////////////////////////////
        if (fimDeJogo)
        {
            textoFimDeJogo.gameObject.SetActive(true);
            animacaoDaCamera.enabled = false;
            naveDoJogador.SetActive(false);
            criadorDeInimigos.SetActive(false);
            if (Input.GetKeyDown(KeyCode.M))
            {
                GameObject.Find("Informacoes do jogo").GetComponent<InformacoesDoJogo>().SalvarPontuacao(contadorDePontosDoJogador);
                SceneManager.LoadScene("Menu");
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                GameObject.Find("Informacoes do jogo").GetComponent<InformacoesDoJogo>().SalvarPontuacao(contadorDePontosDoJogador);
                SceneManager.LoadScene("Estagio1");
            }
        }

        ////////////////////////verifica estado estagio concluido//////////////////////////////////////////////////////////////////
        if (estagioConcluido)
        {
            textoEstagioConcluido.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                GameObject.Find("Informacoes do jogo").GetComponent<InformacoesDoJogo>().SalvarPontuacao(contadorDePontosDoJogador);
                SceneManager.LoadScene("Menu");
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                GameObject.Find("Informacoes do jogo").GetComponent<InformacoesDoJogo>().pontosDoJogador = contadorDePontosDoJogador;
                GameObject.Find("Informacoes do jogo").GetComponent<InformacoesDoJogo>().SalvarPontuacao(contadorDePontosDoJogador);
                SceneManager.LoadScene("Estagio1");
            }
        }
    }

    ////////////////////////////////retorna itens da lista para utiliza-los//////////////////////////////////////////////////
    public GameObject PegarObjetoDaLista(string nomeDoObjeto)
    {
        GameObject objetoDaLista = null;
        switch (nomeDoObjeto)
        {
            case "Nave inimiga nivel 1":
                if (listaDeNavesInimigasNivel1.Count > 0)
                {
                    objetoDaLista = listaDeNavesInimigasNivel1[0];
                    listaDeNavesInimigasNivel1.Remove(listaDeNavesInimigasNivel1[0]);
                }
                else
                {
                    objetoDaLista = Instantiate(naveInimigaNivel1);
                    objetoDaLista.name = "Nave inimiga nivel 1";
                }
                break;
            case "Nave inimiga nivel 2":
                if (listaDeNavesInimigasNivel2.Count > 0)
                {
                    objetoDaLista = listaDeNavesInimigasNivel2[0];
                    listaDeNavesInimigasNivel2.Remove(listaDeNavesInimigasNivel2[0]);
                }
                else
                {
                    objetoDaLista = Instantiate(naveInimigaNivel2);
                    objetoDaLista.name = "Nave inimiga nivel 2";
                }
                break;
            case "Explosao":
                if (listaDeExplosoes.Count > 0)
                {
                    objetoDaLista = listaDeExplosoes[0];
                    listaDeExplosoes.Remove(listaDeExplosoes[0]);
                }
                else
                {
                    objetoDaLista = Instantiate(explosao);
                    objetoDaLista.name = "Explosao";
                }
                break;
            case "Energia extra":
                if (listaDeEnergiasExtra.Count > 0)
                {
                    objetoDaLista = listaDeEnergiasExtra[0];
                    listaDeEnergiasExtra.Remove(listaDeEnergiasExtra[0]);
                }
                else
                {
                    objetoDaLista = Instantiate(energiaExtra);
                    objetoDaLista.name = "Energia extra";
                }
                break;
            case "Bala":
                if (listaDeBalas.Count > 0)
                {
                    objetoDaLista = listaDeBalas[0];
                    listaDeBalas.Remove(listaDeBalas[0]);
                }
                else
                {
                    objetoDaLista = Instantiate(bala);
                    objetoDaLista.name = "Bala";
                }
                break;
        }
        return objetoDaLista;
    }

    //////////////////////adiciona item que ja foi utilizado para a lista//////////////////////////////////////////////////
    public void FimDeUsoDoObjeto(string nomeDoObjeto, GameObject objeto)
    {
        objeto.SetActive(false);
        switch (nomeDoObjeto)
        {
            case "Nave inimiga nivel 1":
                listaDeNavesInimigasNivel1.Add(objeto);
                break;
            case "Nave inimiga nivel 2":
                listaDeNavesInimigasNivel2.Add(objeto);
                break;
            case "Explosao":
                listaDeExplosoes.Add(objeto);
                break;
            case "Energia extra":
                listaDeEnergiasExtra.Add(objeto);
                break;
            case "Bala":
                listaDeBalas.Add(objeto);
                break;
            case "Nave do jogador":
                fimDeJogo = true;
                
                break;
            case "Nave inimiga chefe":
                estagioConcluido = true;
                naveDoJogador.GetComponent<Nave>().enabled = false;
                naveDoJogador.GetComponent<ControleDoJogador>().enabled = false;
                objeto.GetComponent<Nave>().enabled = false;
                objeto.GetComponent<ControleDoChefe>().enabled = false;
                objeto.SetActive(true);
                objeto.GetComponent<Animator>().SetBool("sem energia", true);
                objeto.GetComponent<Animator>().enabled = true;
                break;
        }
    }
}
