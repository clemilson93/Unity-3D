using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CanvasDoMenu : MonoBehaviour {

    public Text jogador1;
    public Text jogador2;
    public Text jogador3;
    public Text jogador4;
    public Toggle jogadorComputador2;
    public Toggle jogadorComputador3;
    public Toggle jogadorComputador4;
    bool[,] jogadores = new bool[4, 2];
	// Use this for initialization
	void Awake ()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                jogadores[i,j] = false;
            }
        }
    }

    void Update()
    {
        
    }

    public void Acao(int comando)
    {
        switch (comando)
        {
            case 0:
                SceneManager.LoadScene("espacoDeJogo");
                break;
            case 1:
                Application.Quit();
                break;
            case 2:
                SceneManager.LoadScene("menu");
                break;
        }
    }

    public void TrocaDePersonagem(int botaoDoJogador)
    {
        switch (botaoDoJogador)
        {
            case 0:
                if (jogadores[botaoDoJogador, 0] == false)
                {
                    jogador1.text = "Mulher";
                    jogadores[botaoDoJogador, 0] = true;
                }
                else
                {
                    jogador1.text = "Homem";
                    jogadores[botaoDoJogador, 0] = false;
                }
                break;
            case 1:
                if (jogadores[botaoDoJogador, 0] == false)
                {
                    jogador2.text = "Mulher";
                    jogadores[botaoDoJogador, 0] = true;
                }
                else
                {
                    jogador2.text = "Homem";
                    jogadores[botaoDoJogador, 0] = false;
                }
                break;
            case 2:
                if (jogadores[botaoDoJogador, 0] == false)
                {
                    jogador3.text = "Mulher";
                    jogadores[botaoDoJogador, 0] = true;
                }
                else
                {
                    jogador3.text = "Homem";
                    jogadores[botaoDoJogador, 0] = false;
                }
                break;
            case 3:
                if (jogadores[botaoDoJogador, 0] == false)
                {
                    jogador4.text = "Mulher";
                    jogadores[botaoDoJogador, 0] = true;
                }
                else
                {
                    jogador4.text = "Homem";
                    jogadores[botaoDoJogador, 0] = false;
                }
                break;
        }
    }
}
