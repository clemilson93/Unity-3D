using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class sct : MonoBehaviour {

    AsyncOperation level;
    public Image bar;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            StartCoroutine("loadStage");
        }
        bar.fillAmount = level.progress + 0.1f ;
        if (level.progress == 0.9f)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                level.allowSceneActivation = true;
            }
        }
	}

    IEnumerator loadStage()
    {
        level = SceneManager.LoadSceneAsync("s");
        level.allowSceneActivation = false;
        yield return null;

    }
}
