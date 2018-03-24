using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectionContact : MonoBehaviour {

	public GameObject explosion;

	void OnTriggerEnter(Collider other) 
	{	
		if (other.tag == "asteroid")
		{
			GameObject selfExplosion = Instantiate(explosion, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
			Destroy (selfExplosion, 5);
			//GetComponent<gameController> ().gameOverDisplay.text = "Game Over\nYou Have traveled " + GetComponent<gameController> ().distance.ToString () + " km!";
		}
	}
}
