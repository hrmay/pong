using UnityEngine;
using System.Collections;

public class MoveRacket : MonoBehaviour {
	public float speed = 30;
	public string axis = "Vertical";

	// Use this for initialization
	void FixedUpdate () {
		float v = Input.GetAxisRaw (axis);
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, v) * speed;

	}
}
