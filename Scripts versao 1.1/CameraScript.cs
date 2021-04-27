using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public Transform target, camTranf;
    public MovieTexture video;
    public AudioSource audio;
    float horizontal = 0;
    float vertical = 0;
    float distance = 5;
    void Awake()
    {
        camTranf = transform;
    }

    // Use this for initialization
    void Update ()
    {
        horizontal += Input.GetAxis("Mouse X");
        vertical += Input.GetAxis("Mouse Y");
        distance += -Input.GetAxis("Mouse ScrollWheel");
        vertical = Mathf.Clamp(vertical, -45, 45);
        distance = Mathf.Clamp(distance, 2, 4);
        Quaternion rot = Quaternion.Euler(vertical, horizontal, 0);
        Vector3 dir = new Vector3(0, 0, -distance);
        Debug.Log(target.position + "=>target" + rot + "=>rotation" + dir + "=>direction");
        camTranf.position = target.position + rot * dir;
        Debug.Log(rot * dir);
        //camTranf.LookAt(target.position);
    }

    // Update is called once per frame
    public void proxcena()
    {
        SceneManager.LoadScene("nan");
    }
    public void playvideo()
    {
        video.Play();
    }
}
