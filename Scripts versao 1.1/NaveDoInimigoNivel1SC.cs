using UnityEngine;
using System.Collections;

public class NaveDoInimigoNivel1SC : MonoBehaviour {

    public int energiaAtualDaNaveDoInimigoNivel1;
    public int energiaMaximaDaNaveDoInimigoNivel1;
    public float velocidadeDaNaveDoInimigoNivel1;
    public LimitesDoCenario limitesDoCenario;
    public float tempoParaOProximoTiro;
    public float tempoDeEsperaParaOProximoTiro;
    public GameObject laserDaNaveDoInimigoNivel1;
    public GameObject bonusParaOJogador;
    public GameObject explosao;

    void Awake()
    {
        limitesDoCenario = GameObject.Find("Controlador da tela jogando o jogo").GetComponent<ControladorDaTelaJogandoOJogoSC>().limitesDoCenario;
        energiaAtualDaNaveDoInimigoNivel1 = energiaMaximaDaNaveDoInimigoNivel1;
    }

    void Update()
    {
        if (energiaAtualDaNaveDoInimigoNivel1 <= 0)
        {
            Instantiate(explosao, transform.position, transform.rotation);
            GameObject.Find("Controlador da tela jogando o jogo").GetComponent<ControladorDaTelaJogandoOJogoSC>().pontuacaoDoJogador += 5;
            if (Random.Range(0, 21) == 1)
            {
                Instantiate(bonusParaOJogador, transform.position,Quaternion.identity);
            }
            float novaPosicaoX = Random.Range(limitesDoCenario.esquerdo + 2, limitesDoCenario.direito - 2);
            transform.position = new Vector3(novaPosicaoX, 0, limitesDoCenario.superior + 2);
            energiaAtualDaNaveDoInimigoNivel1 = energiaMaximaDaNaveDoInimigoNivel1;
        }
        if (transform.position.z <= limitesDoCenario.inferior)
        {
            float novaPosicaoX = Random.Range(limitesDoCenario.esquerdo + 2, limitesDoCenario.direito - 2);
            transform.position = new Vector3(novaPosicaoX, 0 , limitesDoCenario.superior + 2);
        }
        if (Time.time >= tempoParaOProximoTiro)
        {
            Instantiate(laserDaNaveDoInimigoNivel1, transform.position, transform.rotation);
            tempoParaOProximoTiro = Time.time + tempoDeEsperaParaOProximoTiro;
        }
        transform.Translate(new Vector3(0, 0, 1) * velocidadeDaNaveDoInimigoNivel1);
    }

    void OnTriggerEnter(Collider objetoColisor)
    {
        if (objetoColisor.gameObject.name == "Laser da nave do jogador")
        {
            for (int contador = objetoColisor.gameObject.GetComponent<LaserDaNaveDoJogadorSC>().dano; contador > 0 && energiaAtualDaNaveDoInimigoNivel1 > 0; contador--)
            {
                energiaAtualDaNaveDoInimigoNivel1 -= 1;
            }
            Destroy(objetoColisor.gameObject);
        }
        if (objetoColisor.gameObject.name == "Nave do jogador")
        {
            energiaAtualDaNaveDoInimigoNivel1 -= energiaAtualDaNaveDoInimigoNivel1;
        }
    }
}
