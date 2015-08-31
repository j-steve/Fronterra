using UnityEngine;
using System.Collections;

public class PlanetController : MonoBehaviour {

	private const float GRAV_CONST = 6.67384E-11f;


	public Rigidbody playerShip;

	public GameObject atmosphere;

	public Rigidbody moon;

	public float mass;

	// Use this for initialization
	void Start () {
		moon.AddForce (15000, 0, 0);
		moon.drag = 0;
		moon.angularDrag = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate(new Vector3(0f, -0.02f, 0f));
		atmosphere.transform.Rotate(new Vector3(0f, 0.04f, 0f));
		applyGravity (playerShip);
		applyGravity (moon);
//		Debug.Log (gravitationalPull);
		//playerShip.AddRelativeForce (gravitationalPull);
		//playerShip.AddForce (positionDiff / 100);
	}

	private void applyGravity(Rigidbody target) {
		
		float radius = Vector3.Distance (target.position, gameObject.transform.position);
		Vector3 positionDiff = this.gameObject.transform.position - target.position;
		positionDiff *= mass / Mathf.Pow (radius, 2);
		target.AddForce (positionDiff);
	}

	private float gravTransform(float value) {
		return GRAV_CONST * (mass > 0 ? 1 : -1) / Mathf.Pow (value, 2);
	}
}
