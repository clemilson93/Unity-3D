using UnityEngine;
using System.Collections;

public class LaserDaNaveDoInimigoNivel1SC : MonoBehaviour {

    public float velocidadeDoLaserDaNaveDoInimigoNivel1;
    public float tempoDeVidaDoLaserDaNaveDoInimigoNivel1;
    public int dano;

    // Use this for initialization
    void Start()
    {
        gameObject.name = "Laser da nave do inimigo nivel 1";
        Destroy(gameObject, tempoDeVidaDoLaserDaNaveDoInimigoNivel1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, velocidadeDoLaserDaNaveDoInimigoNivel1);
    }
}
