using UnityEngine;
using System.Collections;

public class ShipControlScript : MonoBehaviour {

	public Rigidbody2D shipbody; //the ship's physics object
	public float forwardThrust = 5000F; //affects general speed
	public float bankAmount = 0.1F; //affects turning speed
	public float bankSpeed = 0.2F; //affects turning speed
	public float turnSpeed = -250F; //affects turning speed
	public float mass = 5F; //"weight" of the ship

	//drag
	public float speedThresholdForDrag = 25F;
	public float defaultDrag = 2F;
	public float fastDrag = 0.5F;
	public float slowDrag = 0.01F;

	//drag while turning (angular)
	public float turningSpeedThresholdForDrag = 5F;
	public float defaultTurningDrag = 32F;
	public float fastTurningDrag = 16F;
	public float slowTurningDrag = 0.1F;

	private float thrust = 0F; //ship's current "thrust" amount
	private float turn = 0F; //ship's current "turn" amount
	private float bank = 0F; //ship's current "bank" amount

	void Start() {
		shipbody.mass = mass; //set mass of ship
	}

	void FixedUpdate() {
		//the ship is moving! thrust value will be affected by drag
		if (Mathf.Abs (thrust) > 0.01F) {
			if (shipbody.velocity.sqrMagnitude > speedThresholdForDrag) {
				shipbody.drag = fastDrag;
			} else {
				shipbody.drag = slowDrag;
			}
		} else {
			shipbody.drag = defaultDrag; 
		}

		//the ship is turning! turning value will be affected by drag
		if (Mathf.Abs (turn) > 0.01F) {
			if (shipbody.angularVelocity > turningSpeedThresholdForDrag) {
				shipbody.angularDrag = fastTurningDrag;
			} else {
				shipbody.angularDrag = slowTurningDrag;
			}
		} else {
			shipbody.angularDrag = defaultTurningDrag;
		}

		float amountToBank = shipbody.angularVelocity * bankAmount;
		bank = Mathf.Lerp(bank, amountToBank, bankSpeed);
	}

	void Thrust(float t) {
		//determine thrust value between 0 and 1
		thrust = Mathf.Clamp(t, -1F, 1F);
	}

	void Turn(float t) {
		//determine turn value between 0 and 1, then affected by turn speed
		turn = Mathf.Clamp(t, -1F, 1F) * turnSpeed;
	}

	void Update () {
		//update ship movements based on player input
		thrust = Input.GetAxis("Vertical");
		turn = Input.GetAxis("Horizontal") * turnSpeed;

		if (thrust > 0F) //the ship is moving!
		{
			thrust = forwardThrust;
		}

		//send thrust/turn values to the ship
		shipbody.MoveRotation(shipbody.rotation + turn * Time.fixedDeltaTime);
		Vector2 vectorThrust = new Vector2(thrust * 2, 0);
		shipbody.AddRelativeForce(vectorThrust);
	}
}
