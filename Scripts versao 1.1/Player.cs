using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

    public GameObject heroe;
    public GameObject info;
    public Text infoText;
    public int ringCount = 0;
    public int ringsRequired = 0;
    public int lives = 3;
    public AudioClip ringCollected;
    public AudioClip damageReceived;
    public AudioClip levelCompleted;

    public void AddRing()
    {
        ringsRequired += 1;
    }

    void Awake()
    {
        StartCoroutine("StartStage");
    }

    // Use this for initialization
    void Update () 
	{
        GameObject.Find("Rings Count").GetComponent<Text>().text = "" + ringCount + " / " + ringsRequired;
        GameObject.Find("Lives Count").GetComponent<Text>().text = "" + lives;
        if (ringCount == ringsRequired)
        {
            infoText.text = "Congratulations!\nYou collected all rings.";
            info.SetActive(true);
            StartCoroutine("LevelCompleted");
        }
    }

    IEnumerator StartStage()
    {
        yield return new WaitForSeconds(2);
        info.SetActive(false);
    }

	public void Death () 
	{
        lives -= 1;
        GetComponent<AudioSource>().clip = damageReceived;
        GetComponent<AudioSource>().Play();
        if (lives > 0)
        {
            StartCoroutine("TryAgain");
        }
        else
        {
            infoText.text = "Game Over";
            info.SetActive(true);
            StartCoroutine("GameOver");
        }
    }

    IEnumerator LevelCompleted()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Main Menu");
    }

    public void RingColected()
    {
        ringCount += 1;
        GetComponent<AudioSource>().clip = ringCollected;
        GetComponent<AudioSource>().Play();
        if (ringCount == ringsRequired)
        {
            GetComponent<AudioSource>().clip = levelCompleted;
            GetComponent<AudioSource>().Play();
        }
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Main Menu");
    }

    IEnumerator TryAgain()
    {
        yield return new WaitForSeconds(3);
        heroe.GetComponent<Heroe>().Respawn();
    }
}
