using UnityEngine;
using System.Collections;

public class OrbContact : MonoBehaviour
{

	public GameObject explosion;

	public GameObject protectSphere;

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
			GameObject protecting = Instantiate (protectSphere, other.transform.position, other.transform.rotation);
			protecting.transform.Rotate (0.0f, -90.0f, 60.0f);
			protecting.transform.parent = other.transform;
			Destroy (gameObject);
			Destroy (selfExplosion, 5);
			Destroy (protecting, 10);
		}
	}
}

