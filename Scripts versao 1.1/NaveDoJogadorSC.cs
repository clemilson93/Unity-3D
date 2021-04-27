using UnityEngine;
using System.Collections;

public class NaveDoJogadorSC : MonoBehaviour {

    public int energiaAtualDaNaveDoJogador;
    public int energiaMaximaDaNaveDoJogador;
    public float velocidadeDaNaveDoJogador;
    public LimitesDoCenario limitesDoCenario;
    public float tempoParaOProximoTiro;
    public float tempoDeEsperaParaOProximoTiro;
    public GameObject laserDaNaveDoJogador;
    public GameObject explosao;

    void Awake()
    {
        limitesDoCenario = GameObject.Find("Controlador da tela jogando o jogo").GetComponent<ControladorDaTelaJogandoOJogoSC>().limitesDoCenario;
        energiaAtualDaNaveDoJogador = energiaMaximaDaNaveDoJogador;
    }

    void Update()
    {
        if (energiaAtualDaNaveDoJogador == 0)
        {
            Instantiate(explosao, transform.position, transform.rotation);
            GameObject.Find("Controlador da tela jogando o jogo").GetComponent<ControladorDaTelaJogandoOJogoSC>().FimDeJogo();
            gameObject.SetActive(false);
        }
        if (Time.time >= tempoParaOProximoTiro && Input.GetKey(KeyCode.S))
        {
            Instantiate(laserDaNaveDoJogador, transform.position, transform.rotation);
            tempoParaOProximoTiro = Time.time + tempoDeEsperaParaOProximoTiro;
        }
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(movimentoHorizontal, 0, movimentoVertical) * velocidadeDaNaveDoJogador);
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, limitesDoCenario.esquerdo, limitesDoCenario.direito),
            0,
            Mathf.Clamp(transform.position.z, limitesDoCenario.inferior, limitesDoCenario.superior)
            );
    }

    public void TratarDano(int dano)
    {
    }

    void OnTriggerEnter(Collider objetoColisor)
    {
        if (objetoColisor.gameObject.name == "Laser da nave do inimigo nivel 1")
        {
            for (int contador = objetoColisor.gameObject.GetComponent<LaserDaNaveDoInimigoNivel1SC>().dano; contador > 0 && energiaAtualDaNaveDoJogador > 0; contador--)
            {
                energiaAtualDaNaveDoJogador -= 1;
            }
            Destroy(objetoColisor.gameObject);
        }
        if (objetoColisor.gameObject.name == "Laser da nave do inimigo nivel 2")
        {
            for (int contador = objetoColisor.gameObject.GetComponent<LaserDaNaveDoInimigoNivel2SC>().dano; contador > 0 && energiaAtualDaNaveDoJogador > 0; contador--)
            {
                energiaAtualDaNaveDoJogador -= 1;
            }
            Destroy(objetoColisor.gameObject);
        }
        if (objetoColisor.gameObject.name == "Energia extra")
        {
            GetComponent<AudioSource>().Play();
            for (int contador = objetoColisor.gameObject.GetComponent<EnergiaExtraSC>().quantidadeDePontosExtraDeEnergia; contador > 0 && energiaAtualDaNaveDoJogador < energiaMaximaDaNaveDoJogador; contador--)
            {
                energiaAtualDaNaveDoJogador += 1;
            }
            Destroy(objetoColisor.gameObject);
        }
        if (objetoColisor.gameObject.name == "Nave do inimigo nivel 1")
        {
            for (int contador = 2; contador > 0 && energiaAtualDaNaveDoJogador > 0; contador--)
            {
                energiaAtualDaNaveDoJogador -= 1;
            }
        }
        if (objetoColisor.gameObject.name == "Nave do inimigo nivel 2")
        {
            for (int contador = 4; contador > 0 && energiaAtualDaNaveDoJogador > 0; contador--)
            {
                energiaAtualDaNaveDoJogador -= 1;
            }
        }
    }
}
