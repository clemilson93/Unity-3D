using UnityEngine;
using System.Collections;

public class ControleDoJogadorSct : MonoBehaviour {

    public GuerreiroSct guerreiro;
    bool pulo = false;
    bool ataque = true;
    public GameObject areaDeAtaque;

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)&&pulo == true)
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * 200);
            pulo = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && ataque == true)
        {
            ataque = false;
            StartCoroutine("Atacar");
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Time.deltaTime * guerreiro.velocidade, 0, 0);
            transform.rotation = new Quaternion(0,0,0,0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Time.deltaTime * guerreiro.velocidade, 0, 0);
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        if (guerreiro.pontosDeVidaAtual <= 0)
        {
            GameObject.Find("ObservadorDoJogo").GetComponent<ControleDoObservadorSct>().FimDeJogo();
            gameObject.SetActive(false);
        }
    }

    IEnumerator Atacar()
    {
        areaDeAtaque.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        areaDeAtaque.SetActive(false);
        ataque = true;
        
    }

    void OnCollisionEnter2D(Collision2D objeto)
    {
        if (objeto.gameObject.tag == "Plataforma")
        {
            pulo = true;
        }
        if (objeto.gameObject.name == "PlataformaEmMovimento")
        {
            transform.parent = objeto.transform;
        }
    }

    void OnCollisionExit2D(Collision2D objeto)
    {
        if (objeto.gameObject.name == "PlataformaEmMovimento")
        {
            transform.parent = null;
        }
    }

    void OnTriggerEnter2D(Collider2D objeto)
    {
        if (objeto.name == "AreaDeAtaqueDoInimigo")
        {
            GetComponent<Rigidbody2D>().AddForce(transform.right * -100);
            guerreiro.pontosDeVidaAtual -= 1;
        }

        if (objeto.name == "Limite")
        {
            GameObject.Find("ObservadorDoJogo").GetComponent<ControleDoObservadorSct>().FimDeJogo();
            gameObject.SetActive(false);
        }

    }
}
