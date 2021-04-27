using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ControleDoCanvasSct : MonoBehaviour {

    public void CarregarEstagio()
    {
        SceneManager.LoadScene("Estagio");
    }
    public void SairDoJogo()
    {
        Application.Quit();
    }
}
