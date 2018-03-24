using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByKeyUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp ("Fire1")) 
		{
			Destroy (gameObject);
		}
	}
}
