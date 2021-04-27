using UnityEngine;
using System.Collections;

public class NaveDoInimigoNivel2SC : MonoBehaviour {

    public int energiaAtualDaNaveDoInimigoNivel2;
    public int energiaMaximaDaNaveDoInimigoNivel2;
    public float velocidadeDaNaveDoInimigoNivel2;
    public LimitesDoCenario limitesDoCenario;
    public float tempoParaOProximoTiro;
    public float tempoDeEsperaParaOProximoTiro;
    public GameObject laserDaNaveDoInimigoNivel2;
    public int sentidoDeMovimentoEmX;
    public GameObject bonusParaOJogador;
    public GameObject explosao;

    void Awake()
    {
        limitesDoCenario = GameObject.Find("Controlador da tela jogando o jogo").GetComponent<ControladorDaTelaJogandoOJogoSC>().limitesDoCenario;
        energiaAtualDaNaveDoInimigoNivel2 = energiaMaximaDaNaveDoInimigoNivel2;
    }

    void Update()
    {
        if (energiaAtualDaNaveDoInimigoNivel2 <= 0)
        {
            Instantiate(explosao, transform.position, transform.rotation);
            GameObject.Find("Controlador da tela jogando o jogo").GetComponent<ControladorDaTelaJogandoOJogoSC>().pontuacaoDoJogador += 10;
            if (Random.Range(0, 21) == 1)
            {
                Instantiate(bonusParaOJogador, transform.position, Quaternion.identity);
            }
            float novaPosicaoX = Random.Range(limitesDoCenario.esquerdo + 2, limitesDoCenario.direito - 2);
            transform.position = new Vector3(novaPosicaoX, 0, limitesDoCenario.superior + 2);
            energiaAtualDaNaveDoInimigoNivel2 = energiaMaximaDaNaveDoInimigoNivel2;
        }
        if (transform.position.z <= limitesDoCenario.inferior)
        {
            float novaPosicaoX = Random.Range(limitesDoCenario.esquerdo + 2, limitesDoCenario.direito - 2);
            transform.position = new Vector3(novaPosicaoX, 0, limitesDoCenario.superior + 2);
        }
        if (transform.position.x <= limitesDoCenario.esquerdo)
        {
            sentidoDeMovimentoEmX = sentidoDeMovimentoEmX * -1;
        }
        if (transform.position.x >= limitesDoCenario.direito)
        {
            sentidoDeMovimentoEmX = sentidoDeMovimentoEmX * -1;
        }
        if (Time.time >= tempoParaOProximoTiro)
        {
            Instantiate(laserDaNaveDoInimigoNivel2, transform.position, transform.rotation);
            tempoParaOProximoTiro = Time.time + tempoDeEsperaParaOProximoTiro;
        }
        transform.Translate(new Vector3(sentidoDeMovimentoEmX, 0, 1) * velocidadeDaNaveDoInimigoNivel2);

    }

    void OnTriggerEnter(Collider objetoColisor)
    {
        if (objetoColisor.gameObject.name == "Laser da nave do jogador")
        {
            for (int contador = objetoColisor.gameObject.GetComponent<LaserDaNaveDoJogadorSC>().dano; contador > 0 && energiaAtualDaNaveDoInimigoNivel2 > 0; contador--)
            {
                energiaAtualDaNaveDoInimigoNivel2 -= 1;
            }
            Destroy(objetoColisor.gameObject);
        }
        if (objetoColisor.gameObject.name == "Nave do jogador")
        {
            energiaAtualDaNaveDoInimigoNivel2 -= energiaAtualDaNaveDoInimigoNivel2;
        }
    }
}
