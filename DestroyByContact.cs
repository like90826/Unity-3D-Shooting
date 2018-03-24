using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{

	public GameObject explosion;
	public GameObject playerExplosion;

	void Start ()
	{
		//GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
	}

	void OnTriggerEnter(Collider other) 
	{	
		if (other.tag == "Beam") {
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (gameObject);
		}
		if (other.tag == "Player")
		{
			GameObject explosion = Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
			Destroy (gameObject);
			Destroy (explosion, 5);
			//GetComponent<gameController> ().gameOverDisplay.text = "Game Over\nYou Have traveled " + GetComponent<gameController> ().distance.ToString () + " km!";
		}
	}
}
