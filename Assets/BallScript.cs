using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {
	public float speed = 30;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().velocity = Vector2.right * speed;
	}

	float HitFactor (Vector2 ballPos, Vector2 racketPos, float racketHeight) {
		// ascii art:
		// ||  1 <- at the top of the racket
		// ||
		// ||  0 <- at the middle of the racket
		// ||
		// || -1 <- at the bottom of the racket

		return (ballPos.y - racketPos.y) / racketHeight;
	}

	void OnCollisionEnter2D(Collision2D col) {
		// Note: 'col' holds the collision information. If the
		// Ball collided with a racket, then:
		//   col.gameObject is the racket
		//   col.transform.position is the racket's position
		//   col.collider is the racket's collider

		if (col.gameObject.name == "RacketLeft") {
			float y = HitFactor (transform.position, col.transform.position, col.collider.bounds.size.y);

			Vector2 dir = new Vector2 (1, y).normalized;

			GetComponent<Rigidbody2D> ().velocity = dir * speed;
		}

		if (col.gameObject.name == "RacketRight") {
			float y = HitFactor (transform.position, col.transform.position, col.collider.bounds.size.y);

			Vector2 dir = new Vector2 (-1, y).normalized;

			GetComponent<Rigidbody2D> ().velocity = dir * speed;
		}

	}
		
}
