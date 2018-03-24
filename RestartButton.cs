using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour {

	public void restartgame () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void backtomanual () {
		SceneManager.LoadScene ("ManualPage");
	}

	public void startgame () {
		SceneManager.LoadScene ("Main");
	}
}
