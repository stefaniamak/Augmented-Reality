using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class InputController : MonoBehaviour {

	// Variables for the speed and turning speed of the rabbit
	public float speed = 5f;
	public float turnSpeed = 5f;

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector2 direction2d = JoystickDirection ();
		Vector3 direction3d = new Vector3 (direction2d.x, 0, direction2d.y);

		// Movement and Rotation
		if (direction2d != Vector2.zero) {
			transform.position += direction3d * Time.deltaTime * speed;

			Quaternion targetRotation = Quaternion.LookRotation (direction3d);
			transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, Time.deltaTime * turnSpeed);

			anim.SetBool ("IsWalking", true);
		} else
			anim.SetBool ("IsWalking", false);

	}

	// Get the joystick's direction from the joystick imput axis
	Vector2 JoystickDirection (){
		float verticalValue = CnInputManager.GetAxis ("Vertical");
		float horizontalValue = CnInputManager.GetAxis ("Horizontal");

		return new Vector2 (horizontalValue, verticalValue);
	}		
}
