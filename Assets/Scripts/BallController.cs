﻿using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	public int speed;
	public int spinSpeed;

	private Vector3 initialMouseLocation;
	private Vector3 finalMouseLocation;
	private Vector3 mouseDistTraveled;
	private Vector3 ballMoveVector;

	private bool mouseHeldDown;
	private bool moveBall;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		mouseHeldDown = false;
		rb = GetComponent<Rigidbody> ();
		moveBall = false;
		rb.maxAngularVelocity = 1000;
	}
	
	// Update is called once per frame
	void Update () {
		// print((Input.GetAxis ("Mouse X")).ToString());

		//detects whether the mouse is clicked
		if (Input.GetMouseButtonDown (0)) {
			print ("clicked this frame");
			mouseHeldDown = true;
			initialMouseLocation = Input.mousePosition;
		} 

		//detects whether mouse is unclicked
		else if (Input.GetMouseButtonUp (0)) {
			print ("unclicked this frame");
			print ("Final mouse location: " + (mouseDistTraveled.ToString()));
			mouseHeldDown = false;
			finalMouseLocation = Input.mousePosition;
			moveBall = true;
		}

		//do this if the mouse is still held down
		if (mouseHeldDown) {
			finalMouseLocation = Input.mousePosition;
			mouseDistTraveled = initialMouseLocation - finalMouseLocation;
			//print ("******still held down this frame******");
			print (mouseDistTraveled.ToString());
		}
	}

	// Fixed Update is called once per physics calculation
	void FixedUpdate() {
		if (moveBall) {
			rollBall ();
		}
		moveBall = false;


	}

	void rollBall(){
		mouseDistTraveled = initialMouseLocation - finalMouseLocation;
		ballMoveVector.x = mouseDistTraveled.x;
		ballMoveVector.z = mouseDistTraveled.y * speed;
		ballMoveVector.y = 0;

		rb.AddTorque (0, 0, ballMoveVector.x * spinSpeed * (-1));

		ballMoveVector.x = -200;

		rb.AddForce (ballMoveVector); 

		ballMoveVector = Vector3.zero;
	}

	/*
	void getMouseMovement(){
		if (Input.GetAxis ("Mouse X") < 0) {
			print ("left");
		}
		if (Input.GetAxis ("Mouse X") > 0) {
			print ("right");
		}
		if (Input.GetAxis ("Mouse Y") < 0) {
			print ("down");
		}
		if (Input.GetAxis ("Mouse Y") > 0) {
			print ("up");
		}
	}
	*/

}
