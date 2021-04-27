using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

public class MenuCanvasScript : MonoBehaviour {

	public string [,] listRanking = new string[10,2];
	//gameScreens[0] = gameOptionsScreen; gameScreens[1] = rankingScreen; gameScreens[2] = aboutTheGameScreen;
	//gameScreens[3] = helpScreen; gameScreens[4] = developerScreen;
	public GameObject[] gameScreens;
	GameObject currentScreen;
	public Text top10;
	private AsyncOperation load;
	public Slider progressBar;

	// Use this for initialization
	void Start ()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath + "/Game data/Ranking_Data.sys", FileMode.Open);
		Ranking rankingUp = (Ranking)bf.Deserialize (file);
		for(int i=0; i < rankingUp.players.GetLength(0); i++)
		{
			listRanking [i, 0] = rankingUp.players [i, 0];
			listRanking [i, 1] = rankingUp.players [i, 1];
		}
		file.Close ();

		currentScreen = gameScreens [0];
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void gotoRanking()
	{
		gameScreens [0].SetActive (false);
		gameScreens [1].SetActive (true);
		currentScreen = gameScreens [1];
		top10.text = "1" +"   "+ listRanking [0, 0] +"\n"+ listRanking [0, 1]+"\n\n";
		for(int i=1; i<listRanking.GetLength(0); i++)
		{
			top10.text = top10.text + (i+1) +"   "+ listRanking [i, 0] +"\n"+ listRanking [i, 1]+"\n\n";
		}
	}

	public void gotoMainMenu()
	{
		currentScreen.SetActive (false);
		gameScreens [0].SetActive (true);
		currentScreen = gameScreens [0];
	}

	public void gotoAboutTheGame()
	{
		gameScreens [0].SetActive (false);
		gameScreens [2].SetActive (true);
		currentScreen = gameScreens [2];
	}

	public void startGame()
	{
		if(load == null)
		{
			GameObject.Find ("Game Options Screen").SetActive (false);
			progressBar.gameObject.SetActive (true);
			StartCoroutine (loadMenu());
		}
	}

	IEnumerator loadMenu()
	{
		load = SceneManager.LoadSceneAsync ("Stage");
		while(!load.isDone)
		{
			progressBar.value = load.progress;
			yield return null;
		}
	}

	public void quitGame()
	{
		Application.Quit ();
	}

	public void loadHelpScreen()
	{
		gameScreens [4].SetActive (false);
		gameScreens [3].SetActive (true);
	}
	public void loadDeveloperScreen()
	{
		gameScreens [3].SetActive (false);
		gameScreens [4].SetActive (true);
	}
}
