using UnityEngine;
using System.Collections;
public class Exemple : MonoBehaviour
{
    void Start()
    {

    }
    void Update()
    {
        transform.Translate(0.75f*Time.deltaTime,0 ,0);
        //transform.localRotation = new Quaternion(0, 3 + transform.rotation.x, 0, 0);
    }
}