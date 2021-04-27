using UnityEngine;
using System.Collections;

public class CameraS : MonoBehaviour {

    Transform target;
    // Use this for initialization
    void Awake()
    {
        Application.targetFrameRate = 30;
        target = GameObject.Find("Heroe").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x, target.transform.position.y - target.transform.position.y / 6, transform.position.z), 0.3f);
        }
    }
}
