using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public Transform target;
    Quaternion rot;
    float rotX = 0, rotY = 0;

    void Update ()
    {
        rotY += Input.GetAxis("Mouse X");
        rotX += Input.GetAxis("Mouse Y");
        rot = Quaternion.Euler(rotX, rotY, 0);
        transform.position = target.transform.position + rot * new Vector3(0, 3, -2);
        transform.LookAt(target.position);
    }
}
