using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public int scores;
    public int expiriencePoints;
    public int level;

	// Use this for initialization
	void Awake ()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update ()
    {
        
	}
}
