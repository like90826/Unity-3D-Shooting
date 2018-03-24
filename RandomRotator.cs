using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
	public float tumble;

	void Start ()
	{
		float scalechange;
		scalechange = Random.Range (-0.5f, 3.0f);
		Vector3 change = new Vector3 (scalechange, scalechange, scalechange);
		transform.localScale += change;
		GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble; 
	}
}