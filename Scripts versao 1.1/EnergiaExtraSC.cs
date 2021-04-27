using UnityEngine;
using System.Collections;

public class EnergiaExtraSC : MonoBehaviour {

    public int quantidadeDePontosExtraDeEnergia;
    public float tempoDeVidaDaEnergiaExtra;
    public float velocidadeDaEnergiaExtra;
    public Transform anelDaEnergiaExtra;

    // Use this for initialization
    void Start ()
    {
        gameObject.name = "Energia extra";
        Destroy(gameObject, tempoDeVidaDaEnergiaExtra);
	}
	
	// Update is called once per frame
	void Update ()
    {
        anelDaEnergiaExtra.Rotate(0, 5, 0);
        transform.Translate( new Vector3(0, 0, -1) * velocidadeDaEnergiaExtra);
	}
}
