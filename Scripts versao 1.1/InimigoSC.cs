using UnityEngine;
using System.Collections;

public class InimigoSC : MonoBehaviour {

    int pontosDeVida = 3;
    public Animator anim;
    public bool desativar;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (pontosDeVida <= 0)
        {
            anim.SetBool("morte", true);
        }
        if (desativar)
        {
            gameObject.SetActive(false);
        }
	}

    void OnTriggerEnter(Collider objeto)
    {
        if (objeto.gameObject.name == "Espada")
        {
            pontosDeVida -= 1;
        }
    }
}
