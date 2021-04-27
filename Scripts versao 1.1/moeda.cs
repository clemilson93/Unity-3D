using UnityEngine;
using System.Collections;

public class moeda : MonoBehaviour {

    float velocidade = 0;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        velocidade = -GameObject.Find("Jogador").GetComponent<jogador>().velocidade;
        transform.Translate(0, 0, (velocidade *10) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider gObject)
    {
        if (gObject.gameObject.name == "Maratonista")
        {
            //tocar um som
            GameObject.Find("Jogador").GetComponent<jogador>().moedas += 1;
            //devolver esta moeda na pilha do object pool
        }
    }
}
