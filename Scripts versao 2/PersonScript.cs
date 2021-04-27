using UnityEngine;
using System.Collections;

public class PersonScript : MonoBehaviour {

    // Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.DownArrow)|| Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0, 0, Time.deltaTime * 3);
        }
        /////////////////////////////////////////////////////////////////////////////////
        if (Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") > 0)
        {
            transform.rotation = Quaternion.Euler(0, 45, 0);
        }
        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") > 0)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (Input.GetAxis("Vertical") < 0 && Input.GetAxis("Horizontal") > 0)
        {
            transform.rotation = Quaternion.Euler(0, 135, 0);
        }
        if (Input.GetAxis("Vertical") < 0 && Input.GetAxis("Horizontal") == 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetAxis("Vertical") < 0 && Input.GetAxis("Horizontal") < 0)
        {
            transform.rotation = Quaternion.Euler(0, 225, 0);
        }
        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") < 0)
        {
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        if (Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") < 0)
        {
            transform.rotation = Quaternion.Euler(0, 315, 0);
        }
    }
}
