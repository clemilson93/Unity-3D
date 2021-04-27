using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ControladorDaApresentacao : MonoBehaviour {

    public VideoPlayer video;

	// Use this for initialization
	void Start ()
    {
        SceneManager.LoadScene("Menu");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (((int)video.frame / (int)video.frameCount) == 1)
        {
            SceneManager.LoadScene("Menu");
        }
	}
}
