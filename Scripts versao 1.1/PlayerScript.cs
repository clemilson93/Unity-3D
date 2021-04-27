using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public int scores = 0;
	public int lives = 3;
	public string name = "Guardian";
	public SpaceshipScript spaceShip;
	//gameScreens[0] = gamePlayScreen; gameScreens[1] = gameOverScreen;
	public GameObject[] gameScreens;

	void Update()
	{
		if(lives == 0)
		{
			spaceShip.gameOver ();
			gameScreens[0].SetActive (false);
			gameScreens[1].SetActive (true);
			lives = 3;
		}
	}
}
