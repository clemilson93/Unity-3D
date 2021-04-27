using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

public class CanvasScript : MonoBehaviour {

	public Text bestPlayer;
	public Text top10;
	public GameObject currentMenu;
	public string [,] listRanking = new string[10,2];

	void Awake()
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

	void Update()
	{
		bestPlayer.text = listRanking [0, 0] + "\nScores: " + listRanking [0, 1];
	}

	public void gotoLevel(string level)
	{
		SceneManager.LoadScene (level);
	}

	public void gotoMenu(GameObject menu)
	{
		currentMenu.SetActive (false);
		menu.SetActive (true);
		currentMenu = menu;
	}

	public void quitApplication()
	{
		Application.Quit();
	}

	public void loadRanking()
	{
		top10.text = "1" +"   "+ listRanking [0, 0] +"   "+ listRanking [0, 1]+"\n";
		for(int i=1; i<listRanking.GetLength(0); i++)
		{
			top10.text = top10.text + (i+1) +"   "+ listRanking [i, 0] +"   "+ listRanking [i, 1]+"\n";
		}
	}

	public void saveRanking(string playerName, int playerScore)
	{
		bool verify = true;
		for(int i = 0; verify==true; i++)
		{
			Debug.Log (i);
			if(playerScore>int.Parse(listRanking[i,1]))
			{
				Debug.Log (i);
				for(int j=listRanking.GetLength(0)-1; j>i; j--)
				{
					Debug.Log (j);
					listRanking [j, 0] = listRanking [j-1, 0];
					listRanking [j, 1] = listRanking [j-1, 1];
				}
				listRanking [i, 0] = playerName;
				listRanking [i, 1] = "" + playerScore;
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

	public void callSave()
	{
		saveRanking ("clemilson", 4350);
	}
}
