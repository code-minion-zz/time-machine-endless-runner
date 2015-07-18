using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformManager : MonoBehaviour {

	private Queue<GameObject> floors;
	public GameObject floorPrefab;
	public GameObject guy;


	// Use this for initialization
	void Start () {
		floors = new Queue<GameObject> ();
		for (int i = 0; i < 4; i++) {
			float xPos = -10 + (floorPrefab.transform.localScale.x * floors.Count);
			floors.Enqueue(GameObject.Instantiate (floorPrefab, new Vector3(xPos, -4.5f, 0f), new Quaternion()) as GameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {

	}


}
