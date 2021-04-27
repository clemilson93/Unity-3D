using UnityEngine;
using System.Collections;

public class EnemySpawnerScript : MonoBehaviour {

    private GameObject objectLibrary;
    public float enemyLevel00InitialTime;
    public float enemyLevel01InitialTime;
    public float enemyLevel00WaitTime;
    public float enemyLevel01WaitTime;

    void Awake ()
    {
        objectLibrary = GameObject.Find("ObjectLibrary");
        enemyLevel00WaitTime = 3;
        enemyLevel00InitialTime = Time.time;
        enemyLevel01WaitTime = 6;
        enemyLevel01InitialTime = Time.time;

    }

    // Update is called once per frame
    void Update ()
    {
        //create enemies level 00 in stage
        if (Mathf.Floor(Time.time) - enemyLevel00InitialTime >= enemyLevel00WaitTime)
        {
            GameObject enemyLevel00 = objectLibrary.GetComponent<ObjectLibraryScript>().GetLaser("EnemyLevel00");
            enemyLevel00.GetComponent<EnemyLevel00Script>().Spawn( transform.position,transform.rotation,-1,0,0 );
            enemyLevel00InitialTime = Time.time;
        }
        if (Mathf.Floor(Time.time) - enemyLevel01InitialTime >= enemyLevel01WaitTime)
        {
            GameObject enemyLevel01 = objectLibrary.GetComponent<ObjectLibraryScript>().GetLaser("EnemyLevel01");
            enemyLevel01.GetComponent<EnemyLevel01Script>().Spawn(transform.position, transform.rotation, -1, 0, 0);
            enemyLevel01InitialTime = Time.time;
        }
        //end create enemies level 00 in stage
    }
}
