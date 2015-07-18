using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformManager : MonoBehaviour {

	private List<GameObject> floors;
	public GameObject floorPrefab;
	public GameObject timeTraveller;


	// Use this for initialization
	void Start () {
		floors = new List<GameObject> ();
		for (int i = 0; i < 4; i++) {
			float xPos = -10 + (floorPrefab.transform.localScale.x * floors.Count);
			GameObject floor = GameObject.Instantiate (floorPrefab, new Vector3(xPos, -4.5f, 0f), new Quaternion()) as GameObject;
			Renderer r = floor.GetComponent<Renderer>();
			r.material.color = i * Color.grey;
			floors.Add(floor);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (timeTraveller.transform.position.x > (floors [1].transform.position.x + floors [1].transform.localScale.x / 2)) {
			GameObject tmp = floors[0];
			floors.RemoveAt(0);
			tmp.transform.position = new Vector3(floors[2].transform.position.x + (floors[2].transform.localScale.x*0.5f) + (tmp.transform.localScale.x*0.5f), tmp.transform.position.y);
			floors.Add(tmp);
		}
	}


}
