using UnityEngine;
using System.Collections;

public class SCControle : MonoBehaviour {

    public GameObject pessoa;

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log(pessoa.GetComponent<SCPessoa>().nome);
        }
	}
}
