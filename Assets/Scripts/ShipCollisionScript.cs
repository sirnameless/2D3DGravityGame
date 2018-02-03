using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipCollisionScript : MonoBehaviour {

	public Text scoreCounter; //score counter GUI, located on the canvas
	private float score = 0; //score to keep track of
	private float scorePercentage = 0; //current score percentage
	private const float maxScore = 6; //max possible score (unchanging, so it's a constant)
	private const string scoreText = " of\nspace-barrels collected"; //unchanging text to display next to the score

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Asteroid") {
			//the ship's parent will now become the asteroid - the ship will inherit the asteroid's gravity
			transform.parent = coll.transform;
		}

		if (coll.gameObject.tag == "Collectible") {
			score++; //increment score
			scorePercentage = score / maxScore; //calculate score percentage
			scoreCounter.text = scorePercentage.ToString("P1") + scoreText; //display the percentage as an easy-to-read string
			Destroy(coll.gameObject); //remove collectible
		}
	}

	void OnCollisionExit2D(Collision2D coll) {
		if (coll.gameObject.tag == "Asteroid") {
			//ship should no longer be affected by any asteroid's gravity
			transform.parent = null;
		}
	}
}
