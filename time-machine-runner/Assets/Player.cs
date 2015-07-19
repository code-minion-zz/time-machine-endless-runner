﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

	bool jumping;
	bool doubleJumping;
    Rigidbody2D rigid;
	public Text distanceDisplay;

	float speed = 5.1f;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown && !doubleJumping)
        {
            if (jumping)
            {
                doubleJumping = true;
                rigid.velocity = new Vector2(rigid.velocity.x, 0);
            }
            rigid.AddForce(Vector3.up * 11, ForceMode2D.Impulse);
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
