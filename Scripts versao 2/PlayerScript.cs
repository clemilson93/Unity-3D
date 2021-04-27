using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public int lives = 3;
	public int scores = 0;
	public Text scoresText;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
		scoresText.text = "Scores: " + scores;
        if (lives <= 0)
        {
            //game over
        }
	}
}
