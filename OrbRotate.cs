using UnityEngine;
using System.Collections;

public class OrbRotate : MonoBehaviour
{
	public float tumble;

	void Start ()
	{
		
		GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble; 
	}
}
