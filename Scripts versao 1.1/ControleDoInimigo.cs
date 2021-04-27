using UnityEngine;
using System.Collections;

public class ControleDoInimigo : MonoBehaviour {

    public FlorMonstroSct inimigo;
    public Transform guerreiro;
    public GameObject areaDeAtaque;
    public int distanciaParaAndar;
    Vector2 posicaoInicial;
    bool atacar = true;

    void Awake()
    {
        distanciaParaAndar = 1;
        posicaoInicial = transform.position;
    }

    void Update ()
    {
        if (inimigo.pontosDeVidaAtual <= 0)
        {
            GameObject.Find("ObservadorDoJogo").GetComponent<ControleDoObservadorSct>().monstrosNoEstagio -= 1;
            gameObject.SetActive(false);
        }
        float distanciaDoGuerreiro = Vector2.Distance(transform.position, guerreiro.position);
        if (distanciaDoGuerreiro < 0.8f)
        {
            if (atacar == true)
            {
                atacar = false;
                StartCoroutine("Atacar");
            }
            if (transform.position.x > guerreiro.position.x)
            {

                transform.rotation = new Quaternion(0, 180, 0, 0);
            }
            if (transform.position.x < guerreiro.position.x)
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }
        else
        {
            if (Vector2.Distance(posicaoInicial, transform.position) > distanciaParaAndar && transform.position.x > posicaoInicial.x)
            {
                
                transform.rotation = new Quaternion(0, 180, 0, 0);
            }
            if (Vector2.Distance(posicaoInicial, transform.position) > distanciaParaAndar && transform.position.x < posicaoInicial.x)
            {
               transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            transform.Translate(Time.deltaTime * inimigo.velocidade, 0, 0);
        }

	}

    IEnumerator Atacar()
    {
        areaDeAtaque.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        areaDeAtaque.SetActive(false);
        yield return new WaitForSeconds(1f);
        atacar = true;

    }

    void OnTriggerEnter2D(Collider2D objeto)
    {
        if (objeto.name == "AreaDeAtaqueDoGuerreiro")
        {
            GetComponent<Rigidbody2D>().AddForce(transform.right * -20);
            inimigo.pontosDeVidaAtual -= 1;
        }
    }
}
