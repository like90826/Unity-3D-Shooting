using UnityEngine;
using System.Collections;

public class mover : MonoBehaviour
{
	public float speed;
	public float xangle;
	public float zangle;

	void Start ()
	{
		GetComponent<Rigidbody>().velocity = new Vector3 (Random.Range(-xangle,xangle), speed, Random.Range(-zangle,zangle));
	}
}
