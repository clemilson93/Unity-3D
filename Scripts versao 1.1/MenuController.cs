using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuController : MonoBehaviour {



	// Use this for initialization
	public void QuitGame ()
    {
        Application.Quit();
	}
	
	// Update is called once per frame
	public void StartGame ()
    {
        SceneManager.LoadScene("Stage");
	}
}
