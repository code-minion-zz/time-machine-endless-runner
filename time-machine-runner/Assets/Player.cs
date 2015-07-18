using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

    void FixedUpdate()
    {
        this.transform.position = new Vector3(this.transform.position.x + (10 * Time.fixedDeltaTime), this.transform.position.y, 0);
    }
}
