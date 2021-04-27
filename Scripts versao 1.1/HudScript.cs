using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HudScript : MonoBehaviour 
{

	public Stage1MissionsScript missionManager;
	public bool help = false;
	public bool missionComplete = false;
	public GameObject player;
	public GameObject gameOverImage;

	void Start () 
	{
		missionManager = GetComponent<Stage1MissionsScript>();
		missionManager.startMission1();
		Application.targetFrameRate = 30;
	}

	void Update () 
	{
		if( missionManager.currentMission != null )
		{
			missionComplete = missionManager.currentMission.checkMission();

			if( missionComplete == true ){
				gameOver();
			}

			if( help == true )
			{
				GameObject.Find( "MissionText" ).GetComponent<Text>().text = "Objective: " + missionManager.currentMission.description;
			}
			else
			{
				GameObject.Find( "MissionText" ).GetComponent<Text>().text = "";
			}
			GameObject.Find( "ItemCount" ).GetComponent<Text>().text = "Items to find: " + missionManager.currentMission.itemsToCollect;
			GameObject.Find( "EnemyCount" ).GetComponent<Text>().text = "Enemies to defeat: " + missionManager.currentMission.enemiesToDefeat;
		}
		else
		{
			GameObject.Find( "MissionText" ).GetComponent<Text>().text = "";
			GameObject.Find( "ItemCount" ).GetComponent<Text>().text = "";
			GameObject.Find( "EnemyCount" ).GetComponent<Text>().text = "";
		}
		if( player != null )
		{
			PlayerScript playerScript = player.GetComponent<PlayerScript>();
			GameObject.Find( "HealthBar" ).GetComponent<Slider>().value = playerScript.calculateHealth();
			GameObject.Find( "ScoreText" ).GetComponent<Text>().text = "Scores: " + playerScript.scores;
			GameObject.Find( "HealthText" ).GetComponent<Text>().text = "Health: " + playerScript.scores;

			if( playerScript.gun != null )
			{
				int gunAmmo = 0;
				string gunId = "";
				if( playerScript.gun.name == "SmallGun")
				{
					gunId = playerScript.gun.GetComponent<SmallGunScript>().gunId;
					gunAmmo = playerScript.gun.GetComponent<SmallGunScript>().ammoAmount;
				}
				else if( playerScript.gun.name == "MidGun")
				{
					gunId = playerScript.gun.GetComponent<MidGunScript>().gunId;
					gunAmmo = playerScript.gun.GetComponent<MidGunScript>().ammoAmount;
				}
				else if( playerScript.gun.name == "LargeGun")
				{
					gunId = playerScript.gun.GetComponent<LargeGunScript>().gunId;
					gunAmmo = playerScript.gun.GetComponent<LargeGunScript>().ammoAmount;
				}
				GameObject.Find( "AmmoCount" ).GetComponent<Text>().text = gunId + ": " + gunAmmo;
			}
			else
			{
				GameObject.Find( "AmmoCount" ).GetComponent<Text>().text = "no gun";
			}
		}
	}

	public void gameOver(){
		gameOverImage.SetActive(true);
		GameObject.Find( "GameOverScores").GetComponent<Text>().text = "Final scores: " + player.GetComponent<PlayerScript>().scores;
	}

	public void gotoMainMenu(){
		Application.LoadLevel(0);
	}

	public void quitGame(){
		Application.Quit();
	}

}
