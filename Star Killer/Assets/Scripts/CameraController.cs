using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject fondo;
	private GameObject fondoNuevo;
	private int contadorFondos;
		
	// Use this for initialization
	void Start () {
		contadorFondos=1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate() {
		Vector3 movement = new Vector3 (0.0f, 0.5f, 0.0f);
		transform.position += movement;
//Creamos un nuevo fondo al alcanzar la posicion y
		if (transform.position.y==(450*contadorFondos)){
			Instantiate(fondo,new Vector3 (0.0f,(35f+(500*contadorFondos)),100f),fondo.transform.rotation);
			print("He creado un nuevo fondo");
			contadorFondos++;
		}
		if (transform.position.y==(550*contadorFondos)){
			Destroy(fondo);
			fondo=fondoNuevo;
			
		}
	}
}
