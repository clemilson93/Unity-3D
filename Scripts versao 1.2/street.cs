using UnityEngine;
using System.Collections;

public class street : MonoBehaviour {

    float velocidade;
    
    // Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        velocidade = GameObject.Find("Jogador").GetComponent<jogador>().velocidade;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2( 0,-velocidade * Time.time );
	}
}
