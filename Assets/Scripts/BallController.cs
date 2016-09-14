using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	public int speed;
	public Vector3 spin;
	private bool mouseHeldDown = false;
	private bool touchingBallCondition = true;
	private Vector3 initialMouseLocation;
	private Vector3 finalMouseLocation;
	private Vector3 mouseDistTraveled;

	private int throwSpeed;
	private int throwSpin;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// getMouseMovement ();

		//detects whether the mouse is clicked
		if (Input.GetMouseButtonDown (0)) {
			print ("clicked this frame");
			mouseHeldDown = true;
			initialMouseLocation = Input.mousePosition;

			//detects whether the mouse is over the ball
			if (touchingBallCondition) {
				print ("clicked on ball");
			}
		} 

		//detects whether mouse is unclicked
		else if (Input.GetMouseButtonUp (0)) {
			print ("unclicked this frame");
			mouseHeldDown = false;
			finalMouseLocation = Input.mousePosition;
			rollBall ();
		}

		//do this if the mouse is still held down
		if (mouseHeldDown) {
			print ("******still held down this frame******");
		}
	}

	// Fixed Update is called once per physics calculation
	void FixedUpdate() {

	}

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

	void rollBall(){
		mouseDistTraveled = initialMouseLocation - finalMouseLocation;
		throwSpeed = mouseDistTraveled.x;
		throwSpin = mouseDistTraveled.y;
	}
}
