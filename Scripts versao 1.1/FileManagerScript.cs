using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

public class FileManagerScript : MonoBehaviour {
	string status = "";
	public Text feedBackText;
	private AsyncOperation load;
	public Slider progressBar;
	/*appStatus equal to 0, status is neutral 
	 *appStatus equal to 1, status is ok
	 *appStatus equal to -1, status is error
	 */
	int appStatus = 0;
	void Start ()
	{
		if (!File.Exists (Application.persistentDataPath + "/Game data/Ranking_Data.sys")) {
			Directory.CreateDirectory (Application.persistentDataPath + "/Game data");
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Create (Application.persistentDataPath + "/Game data/Ranking_Data.sys");
			Ranking ranking = new Ranking ();
			ranking.defaultValues ();
			bf.Serialize (file, ranking);
			file.Close ();
			feedBackText.gameObject.SetActive (true);
			appStatus = 1;
		} else if (File.Exists (Application.persistentDataPath + "/Game data/Ranking_Data.sys")) {
			feedBackText.gameObject.SetActive (true);
			appStatus = 1;
		}
		else
		{
			feedBackText.gameObject.SetActive (true);
			status = "Error! Contact support\nclemilson93@yahoo.com.br";
			feedBackText.text = status;
			appStatus = -1;
		}
	}

	void Update()
	{
		if (Input.touchCount > 0 || Input.anyKey)
		{
			if(appStatus == 1 && load == null)
			{
				GameObject.Find ("Introduction").SetActive (false);
				GameObject.Find ("Continue Text").SetActive (false);
				progressBar.gameObject.SetActive (true);
				StartCoroutine (loadMenu());
			}
			else if(appStatus == -1)
			{
				Application.Quit ();
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

}

[Serializable]
class Ranking
{
	public string[,]players = new string[10,2];
	public void defaultValues()
	{
		for(int i = 0; i < players.GetLength(0); i++)
		{
			players [i, 0] = "Guardian " + (i + 1);
			players [i, 1] = "0";
		}
	}	
}