using UnityEngine;
using System.Collections;

public class LaserDaNaveDoInimigoNivel2SC : MonoBehaviour {

    public float velocidadeDoLaserDaNaveDoInimigoNivel2;
    public float tempoDeVidaDoLaserDaNaveDoInimigoNivel2;
    public int dano;

    // Use this for initialization
    void Start()
    {
        gameObject.name = "Laser da nave do inimigo nivel 2";
        Destroy(gameObject, tempoDeVidaDoLaserDaNaveDoInimigoNivel2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, velocidadeDoLaserDaNaveDoInimigoNivel2);
    }

    void OnTriggerEnter(Collider objetoColisor)
    {
        if (objetoColisor.gameObject.name == "Nave do jogador")
        {
            objetoColisor.gameObject.GetComponent<NaveDoJogadorSC>().TratarDano(dano);
        }
    }
}
