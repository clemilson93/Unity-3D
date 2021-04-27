using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class LimitesDoCenario
{
    public float esquerdo, direito, superior, inferior;
}

public class ControladorDaTelaJogandoOJogoSC : MonoBehaviour {

    public LimitesDoCenario limitesDoCenario;
    public GameObject telaDeFimDeJogo;
    public GameObject telaDeCarregandoJogo;
    public Image barraDeEnergiDaNaveDoJogador;
    public Text textoDaPontuacaoDoJogador;
    public NaveDoJogadorSC scriptDaNaveDoJogador;
    public int pontuacaoDoJogador;

    
	// Update is called once per frame
	void Update ()
    {
        if (telaDeFimDeJogo.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                TentarNovamente();
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                IrParaMenuPrincipal();
            }
        }
        textoDaPontuacaoDoJogador.text = "Pontos\n" + pontuacaoDoJogador;
        barraDeEnergiDaNaveDoJogador.fillAmount = (float)scriptDaNaveDoJogador.energiaAtualDaNaveDoJogador / (float)scriptDaNaveDoJogador.energiaMaximaDaNaveDoJogador;

    }

    public void FimDeJogo()
    {
        telaDeFimDeJogo.SetActive(true);
    }

    void TentarNovamente()
    {
        telaDeFimDeJogo.SetActive(false);
        telaDeCarregandoJogo.SetActive(true);
        SceneManager.LoadScene("Tela de jogando o jogo");
    }

    void IrParaMenuPrincipal()
    {
        telaDeFimDeJogo.SetActive(false);
        telaDeCarregandoJogo.SetActive(true);
        SceneManager.LoadScene("Tela de menu");
    }
}
