using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScale : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Vector3 change = new Vector3 (2, 2, 2);
		transform.localScale += change;
	}
}
