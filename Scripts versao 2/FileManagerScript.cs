using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

public class FileManagerScript : MonoBehaviour {
	string status = "";
	void Awake ()
	{
		if (!File.Exists (Application.persistentDataPath + "/Game data/Ranking_Data.sys")) {
			Directory.CreateDirectory (Application.persistentDataPath + "/Game data");
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Create (Application.persistentDataPath + "/Game data/Ranking_Data.sys");
			Ranking ranking = new Ranking ();
			ranking.defaultValues ();
			bf.Serialize (file, ranking);
			file.Close ();
			status = "restart application";
		} else if (File.Exists (Application.persistentDataPath + "/Game data/Ranking_Data.sys")) {
			SceneManager.LoadScene ("Lobby");
		}
		else
		{
			status = Application.persistentDataPath;
		}
	}

	void OnGUI()
	{
		GUI.Label (new Rect(50, 50, 200, 400), status);
	}

}

[Serializable]
class Ranking
{
	public string[,]players = new string[10,2];
	public void defaultValues()
	{
		for(int i = 0; i < players.GetLength(0); i++)
		{
			players [i, 0] = "Soldier " + (i + 1);
			players [i, 1] = "0";
		}
	}	
}