using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class ControladorDoMenu : MonoBehaviour {

    public Text rankingText;
    InformacoesDoJogo informacoesDoJogo;

	// Use this for initialization
	void Start ()
    {
        informacoesDoJogo = GameObject.Find("Informacoes do jogo").GetComponent<InformacoesDoJogo>();
        rankingText.text = "Maior pontuação\n" + informacoesDoJogo.maiorPontuacao;
    }
	
	public void JogarJogo ()
    {
        SceneManager.LoadScene("Estagio1");
	}

    public void SairDoJogo()
    {
        Application.Quit();
    }
}
