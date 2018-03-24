using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Boundary boundary;
	public Text ifReady;

	private Quaternion calibrateQuaternion;

	public GameObject charge;
	public GameObject beam;
	public Transform shotspawn;
	public GameObject explosion;


	private float nextFire;
	private float fireRate;
	private bool shotready = true;
	private bool charging = false;
	private GameObject charger;
	private GameObject bolt;
	private float sizetracker = 0;
	private float lastshot;

	void Update ()
	{
		sizetracker = sizetracker + 1;
		if (Time.time - lastshot > 30) 
		{
			shotready = true;
		}
		if (shotready) {
			ifReady.text = "Shot is Ready!";
		}


		if (Input.GetButton("Fire1") && shotready)
		{
			shotready = false;
			lastshot = Time.time;
			charger = Instantiate (charge, shotspawn.position, Quaternion.identity);

			//charger.transform.parent = transform;
			sizetracker = 0;
			ifReady.text = "";
			charging = true;
		}
		if (Input.GetButtonUp ("Fire1") && charging) 
		{
			nextFire = Time.time + fireRate;
			//bolt.GetComponent<Rigidbody>().velocity = bolt.transform.forward * 10;
			//bolt.GetComponent<Rigidbody>().velocity = new Vector3 (0.0f, -40, 0.0f);
			bolt = Instantiate (beam, shotspawn.position, Quaternion.identity);
			charging = false;
			if (sizetracker > 130) {
				bolt.transform.localScale = new Vector3 (5, 1, 5);
			} else {
				if (sizetracker > 70) {
					bolt.transform.localScale = new Vector3 (3, 1, 3);
				}
			}
			//bolt.transform.parent = transform;
			GetComponent<AudioSource> ().Play ();
		}
		charger.transform.position = Vector3.Lerp (charger.transform.position, shotspawn.position, 1);
		bolt.transform.position = Vector3.Lerp (bolt.transform.position, shotspawn.position, 1);
	}

	void Start () {

		CalibrateAccelerometer ();
		fireRate = 30.0f;
		ifReady.text = "";
	}

	void FixedUpdate ()
	{
		//float moveHorizontal = Input.GetAxis ("Horizontal");
		//float moveVertical = Input.GetAxis ("Vertical");

		Vector3 accelerationRaw = Input.acceleration;
		Vector3 acceleration = FixAcceleration (accelerationRaw);
		Vector3 movement = new Vector3 (acceleration.x, 0.0f, acceleration.y);

		//movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		GetComponent<Rigidbody>().velocity = movement * speed;

		GetComponent<Rigidbody>().position = new Vector3 
			(
				Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
			);

		//GetComponent<Rigidbody>().rotation = Quaternion.Euler (GetComponent<Rigidbody>().velocity.y * -tilt, GetComponent<Rigidbody>().velocity.x * -tilt, 0.0f);
	}

	void CalibrateAccelerometer () {
		Vector3 accelerationSnapshot = Input.acceleration;
		Quaternion rotateQuaternion = Quaternion.FromToRotation (new Vector3 (0.0f, 0.0f, -1.0f), accelerationSnapshot);
		calibrateQuaternion = Quaternion.Inverse (rotateQuaternion);
	}

	Vector3 FixAcceleration (Vector3 acceleration) {
		Vector3 fixedAcceleration = calibrateQuaternion * acceleration;
		return fixedAcceleration;
	}

	void OnTriggerEnter(Collider other) 
	{	
		if (other.tag == "Shootable")
		{
			GameObject selfExplosion = Instantiate(explosion, other.transform.position, other.transform.rotation);
			nextFire = 0.0f;
			shotready = true;
			Destroy (other.gameObject);
			Destroy (selfExplosion, 5);
		}
	}
}