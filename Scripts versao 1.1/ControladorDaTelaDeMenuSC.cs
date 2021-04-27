using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ControladorDaTelaDeMenuSC : MonoBehaviour {

    public GameObject opcoesDoMenuPrincipal;
    public GameObject telaDeCarregamentoDoJogo;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ComecarJogo()
    {
        opcoesDoMenuPrincipal.SetActive(false);
        telaDeCarregamentoDoJogo.SetActive(true);
        SceneManager.LoadScene("Tela de jogando o jogo");
    }

    public void SairDoJogo()
    {
        Application.Quit();
    }
}
