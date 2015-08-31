using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public UnityEngine.UI.Text speedDisplay;

	public Rigidbody rb;

	public AudioSource engineSound;

	public float forwardAcceleration;

	void Start() { 
	}

	void FixedUpdate () {
		float acceleration = getModifier (KeyCode.LeftShift, KeyCode.LeftControl) * forwardAcceleration;
		engineSound.mute = acceleration <= 0;
		float verticalAccel = getModifier (KeyCode.Space, KeyCode.V);
		rb.AddRelativeForce(new Vector3(acceleration, 0, verticalAccel));
		speedDisplay.text = rb.velocity.x.ToString();

		
		float spin = getModifier (KeyCode.Q, KeyCode.E) / 5;
		float lateralTilt = getModifier (KeyCode.D, KeyCode.A) / 5;
		float verticalTilt = getModifier (KeyCode.W, KeyCode.S) / 5; 
		rb.AddRelativeTorque (spin, verticalTilt, lateralTilt);
	}

	private float getModifier (KeyCode keyForward, KeyCode keyBackward) {
		return Input.GetKey (keyForward) ? 1 : Input.GetKey (keyBackward) ? -1 : 0;
	}
}
