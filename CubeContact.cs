using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeContact : MonoBehaviour {

	public GameObject explosion;
	//public GameObject checkShot;

	//public GameObject AttackSphere;

	void Start () 
	{
	}

	void OnTriggerEnter(Collider other) 
	{	
		/*if (other.tag == "asteroid") {
			
		}
		else {
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}*/
		if (other.tag == "Player")
		{
			GameObject selfExplosion = Instantiate(explosion, transform.position, transform.rotation);
			//GameObject attacking = Instantiate (AttackSphere, other.transform.position, other.transform.rotation);
			//protecting.transform.Rotate (0.0f, -90.0f, 60.0f);
			//attacking.transform.parent = other.transform;
			//GameObject check = Instantiate(checkShot, new Vector3 (0.0f, 0.0f, -110.0f), other.transform.rotation);
			//Instantiate(checkShot, transform.position,transform.rotation);
			//PlayerController.resetshot ();
			Destroy (gameObject);
			Destroy (selfExplosion, 5);
			//Destroy (protecting, 5);
		}
	}
}
