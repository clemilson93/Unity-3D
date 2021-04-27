using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ControleDoObservadorSct : MonoBehaviour {

    public Image BarraDeVida;
    public Text contadorDeMonstros;
    public Text fim;
    public GuerreiroSct guerreiro;
    public int monstrosNoEstagio;
    public GameObject telaFimDeJogo;

    void Update ()
    {
        BarraDeVida.fillAmount = (float)guerreiro.pontosDeVidaAtual/ (float)guerreiro.pontosDeVidaMaxima;
        contadorDeMonstros.text = "MONSTROS: " + monstrosNoEstagio;
        if (monstrosNoEstagio == 0)
        {
            fim.text = "Fim de jogo\nTodos monstros derrotados";
            guerreiro.gameObject.SetActive(false);
            FimDeJogo();
        }
	}

    public void FimDeJogo()
    {
        telaFimDeJogo.SetActive(true);
        StartCoroutine("IrParaMenuPrincipal");
    }

    IEnumerator IrParaMenuPrincipal()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MenuPrincipal");
    }
}
