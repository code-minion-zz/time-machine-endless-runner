using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

	bool jumping;
	bool doubleJumping;
    Rigidbody2D rigid;
	public Text distanceDisplay;

    public AudioSource explosion;
    public AudioSource jump;

    float speed = 1f;

    Camera mainz;

    bool gameOver = false;

	// Use this for initialization
	void Start () {
        mainz = Camera.main;
        rigid = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown && !doubleJumping)
        {
            jump.Play();
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
		this.transform.position = new Vector3(this.transform.position.x + (5.2f * speed * Time.fixedDeltaTime), this.transform.position.y, 0);
        speed += Time.fixedDeltaTime * 0.01f;
        
        if(gameOver)
        {
            if (!explosion.isPlaying)
            {
                Application.LoadLevel(0);
            }

        }
        else
        {
            if (transform.position.x < mainz.transform.position.x - 10 || transform.position.y < mainz.transform.position.y - 6)
            {
                print("You lose");
                explosion.Play();
                gameOver = true;
            }
        }

    }

	//void OnBecameInvisible() {
	//	print ("You lose");
 //       explosion.Play();
 //       //Application.LoadLevel(0);
	//}
}
