using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

	bool jumping;
	bool doubleJumping;

	public Text distanceDisplay;

	float speed = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown && !doubleJumping) {
			GetComponent<Rigidbody2D>().AddForce(Vector3.up * 600 * (jumping ? 0.5f : 1), ForceMode2D.Force);
			if(jumping)
				doubleJumping = true;
			jumping = true;
		}

		distanceDisplay.text = (int)this.transform.position.x + "m";
	}

	void OnCollisionEnter2D(Collision2D coll){
		jumping = false;
		doubleJumping = false;
    }

    void FixedUpdate() {
		this.transform.position = new Vector3(this.transform.position.x + (speed * Time.fixedDeltaTime), this.transform.position.y, 0);
    }

	void OnBecameInvisible() {
		print ("You lose");
	}
}
