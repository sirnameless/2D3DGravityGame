using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour {

	private const int spinSpeed = 15; //how fast this item should spin

	void Update () {
		//make the collectible spin!
		transform.Rotate(Vector3.back * Time.deltaTime * spinSpeed);
	}
}
