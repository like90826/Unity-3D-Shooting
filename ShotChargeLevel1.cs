using UnityEngine;
using System.Collections;

public class ShotChargeLevel1: MonoBehaviour
{
	public float tumble;
	public float upperbound;
	public Vector3 change;
	float track = 0;
	float trackangel = 0;

	void Start ()
	{

		GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble; 
	}

	void Update()
	{
		if(track < upperbound)
		{
			transform.localScale += change;
			track = track + 1;
			trackangel = trackangel + 1;
		}
		if (trackangel % 1000 == 0) 
		{
			GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble; 
		}
	}
}

