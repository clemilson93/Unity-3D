using UnityEngine;
using System.Collections;

public class PlataformaEmMovimentoSct : MonoBehaviour {

    Vector2 posicaoInicial;
    float velocidade;
    float distanciaParaMovimento;
    public int vetorDirecionalX, vetorDirecionalY;

    void Awake ()
    {
        posicaoInicial = transform.position;
        velocidade = 0.8f;
        distanciaParaMovimento = 2f;
    }
	
	void Update ()
    {
        if (Vector2.Distance(posicaoInicial, transform.position) > distanciaParaMovimento && transform.position.x > posicaoInicial.x)
        {
            vetorDirecionalX = -1;
        }
        if (Vector2.Distance(posicaoInicial, transform.position) > distanciaParaMovimento && transform.position.x < posicaoInicial.x)
        {
            vetorDirecionalX = +1;
        }
        if (Vector2.Distance(posicaoInicial, transform.position) > distanciaParaMovimento && transform.position.y > posicaoInicial.y)
        {
            vetorDirecionalY = -1;
        }
        if (Vector2.Distance(posicaoInicial, transform.position) > distanciaParaMovimento && transform.position.y < posicaoInicial.y)
        {
            vetorDirecionalY = +1;
        }
        transform.Translate(Time.deltaTime * velocidade * vetorDirecionalX, Time.deltaTime * velocidade * vetorDirecionalY, 0);
    }
}
