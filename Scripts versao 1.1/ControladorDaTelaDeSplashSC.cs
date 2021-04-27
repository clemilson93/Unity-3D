using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Video;

public class ControladorDaTelaDeSplashSC : MonoBehaviour {

    public GameObject telaDeCarregamentoDoJogo;
    public VideoPlayer video;
    public AsyncOperation cena;

    void Start()
    {
        video.Play();

        
    }

    void Update()
    {
        if (((int)video.frame / (int)video.frameCount) == 1 && cena == null)
        {
            StartCoroutine("CarregarTelaDeMenu");
        }
    }

    IEnumerator CarregarTelaDeMenu()
    {
        telaDeCarregamentoDoJogo.SetActive(true);
        cena = SceneManager.LoadSceneAsync("Tela de menu");
        return null;
    }
}
