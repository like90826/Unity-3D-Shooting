using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
	public GameObject hazard;
	public GameObject hazard2;
	public GameObject hazard3;
	public GameObject backgroundHazard;
	public GameObject orb;
	public GameObject cube;
	public Vector3 spawnValues;
	public Vector3 backgroundSpawn1;
	public Vector3 backgroundSpawn2;
	public Vector3 backgroundSpawn3;
	public Vector3 backgroundSpawn4;
	public int backgroundhazardCount;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public Text distanceDisplay;
	public Text gameOverDisplay;
	public int distance;
	public GameObject restartButton;
	public GameObject backToManualButton;

  	GameObject[] hazards = new GameObject[3];

	private GameObject gameControllerObject;
	private int level;
	private int orbspawnwait;
	private int cubespawnwait;
	//private bool ifgameover;


	void Start ()
	{
		gameOverDisplay.text = "";
		restartButton.SetActive (false);
		backToManualButton.SetActive (false);
		orbspawnwait = 5;
		cubespawnwait = 3;
		StartCoroutine (SpawnWaves ());
	}

	IEnumerator SpawnWaves ()
	{
		hazards [0] = hazard;
		hazards [1] = hazard2;
		hazards [2] = hazard3;
		level = 1;
		int orbRate = 1;
		int cubeRate = 1;
		yield return new WaitForSeconds (startWait);
		while (true) {
			gameControllerObject = GameObject.FindWithTag ("Player");
			//Debug.Log (gameControllerObject.name);
			for (int i = 0; i < hazardCount * level; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, Random.Range (-spawnValues.z, spawnValues.z));
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazards [Random.Range (0, 3)], spawnPosition, spawnRotation);
				level = 1 + (distance / 10);
				orbRate += 1;
				cubeRate += 1;
				distance += 1;
				distanceDisplay.text = "Distance: " + distance.ToString () + " km";
				if (gameControllerObject == null) {
					gameOverDisplay.text = "Game Over\nYou Have traveled " + distance.ToString () + " km !";
					restartButton.SetActive (true);
					backToManualButton.SetActive (true);
					Debug.Log (gameControllerObject.name);
					break;
				}
				//Debug.Log (gameControllerObject.name);
				for (int j = 0; j < backgroundhazardCount; j++) {
					Vector3 backgroundspawnPosition = new Vector3 (Random.Range (-backgroundSpawn1.x, backgroundSpawn1.x), backgroundSpawn1.y, Random.Range (5, backgroundSpawn1.z));
					Quaternion backgroundspawnRotation = Quaternion.identity;
					Instantiate (backgroundHazard, backgroundspawnPosition, backgroundspawnRotation);
				}
				for (int j = 0; j < backgroundhazardCount; j++) {
					Vector3 backgroundspawnPosition = new Vector3 (Random.Range (-backgroundSpawn2.x, backgroundSpawn2.x), backgroundSpawn2.y, Random.Range (-backgroundSpawn2.z, -5));
					Quaternion backgroundspawnRotation = Quaternion.identity;
					Instantiate (backgroundHazard, backgroundspawnPosition, backgroundspawnRotation);
				}
				for (int j = 0; j < backgroundhazardCount; j++) {
					Vector3 backgroundspawnPosition = new Vector3 (Random.Range (7, backgroundSpawn3.x), backgroundSpawn3.y, Random.Range (-backgroundSpawn3.z, backgroundSpawn3.z));
					Quaternion backgroundspawnRotation = Quaternion.identity;
					Instantiate (backgroundHazard, backgroundspawnPosition, backgroundspawnRotation);
				}
				for (int j = 0; j < backgroundhazardCount; j++) {
					Vector3 backgroundspawnPosition = new Vector3 (Random.Range (-backgroundSpawn4.x, -7), backgroundSpawn4.y, Random.Range (-backgroundSpawn4.z, backgroundSpawn4.z));
					Quaternion backgroundspawnRotation = Quaternion.identity;
					Instantiate (backgroundHazard, backgroundspawnPosition, backgroundspawnRotation);
				}
				if (orbRate >= orbspawnwait) {
					Instantiate (orb, spawnPosition, spawnRotation);
					orbRate = 1;
					orbspawnwait = Random.Range (10, 16);
				}
				if (cubeRate >= cubespawnwait) {
					Instantiate (cube, spawnPosition, spawnRotation);
					cubeRate = 1;
					cubespawnwait = Random.Range (5, 11);
				}
				/*if (protect >= protectionduration) {
					Destroy (protecting);
				}*/
				yield return new WaitForSeconds (spawnWait);
			}
		}
	}
}
