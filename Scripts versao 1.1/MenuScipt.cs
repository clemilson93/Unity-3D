using UnityEngine;
using System.Collections;

public class MenuScipt : MonoBehaviour {

	public GameObject loadingImage;
	public GameObject helpImage;

	public void startGame(){
		loadingImage.SetActive(true);
		Application.LoadLevel("Stage 1 scene");
	}

	public void helpGame(){
		helpImage.SetActive(true);

	}

	public void backGame( GameObject go){
		go.SetActive(false);
		
	}

	public void quitGame(){
		Application.Quit();
	}
}
