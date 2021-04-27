using UnityEngine;
using System.Collections;

public class CameraSct : MonoBehaviour {

    public Transform alvo;

    void Update ()
    {
        transform.position = new Vector3(alvo.position.x, alvo.position.y, -3);
	}
}
