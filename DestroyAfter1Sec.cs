﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter1Sec : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 0.4f);
	}

}
