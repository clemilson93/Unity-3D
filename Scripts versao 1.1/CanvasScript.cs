using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour {

	public Text scoreText;
	public Text livesText;
	public Text playerNameText;
	public PlayerScript player;
	public string [,] listRanking = new string[10,2];
	private AsyncOperation load;
	public Slider progressBar;

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
	}
	
	// Update is called once per frame
	void Update ()
	{
		scoreText.text = "Scores: " + player.scores;
		livesText.text = "Lives: " + player.lives;
	}

	public void checkPlayerName()
	{
		if (playerNameText.text.Length <= 9 && playerNameText.text.Length > 0) {
			player.name = playerNameText.text;
			saveRanking ();
			if(load == null)
			{
				GameObject.Find ("Game Over Screen").SetActive (false);
				progressBar.gameObject.SetActive (true);
				StartCoroutine (loadMenu());
			}

		}
	}

	IEnumerator loadMenu()
	{
		load = SceneManager.LoadSceneAsync ("MainMenu");
		while(!load.isDone)
		{
			progressBar.value = load.progress;
			yield return null;
		}
	}

	public void saveRanking()
	{
		bool verify = true;
		for(int i = 0; verify==true && i <listRanking.GetLength(0); i++)
		{
			Debug.Log (i);
			if(player.scores>int.Parse(listRanking[i,1]))
			{
				Debug.Log (i + "pass");
				for(int j=listRanking.GetLength(0)-1; j>i; j--)
				{
					Debug.Log (j);
					listRanking [j, 0] = listRanking [j-1, 0];
					listRanking [j, 1] = listRanking [j-1, 1];
				}
				listRanking [i, 0] = player.name;
				listRanking [i, 1] = "" + player.scores;
				verify = false;
			}

		}
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath + "/Game data/Ranking_Data.sys", FileMode.Open);
		Ranking rankingSav = new Ranking ();
		for(int i=0; i < listRanking.GetLength(0); i++)
		{
			rankingSav.players [i, 0] = listRanking [i, 0];
			rankingSav.players [i, 1] = listRanking [i, 1];
		}
		bf.Serialize (file, rankingSav);
		file.Close ();
	}
}
