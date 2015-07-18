using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformManager : MonoBehaviour {

	private List<GameObject> floors;
	public List<GameObject> floorPrefabs;
	public GameObject timeTraveller;

    public GameObject randomFloor
    {
        get
        {
            if (floorPrefabs.Count == 0) return null;
            return floorPrefabs[Random.Range(0, floorPrefabs.Count-1)];
        }
    }
        
        

	// Use this for initialization
	void Start () {
        GameObject randFloor = randomFloor;
        if (randFloor == null) return;
		floors = new List<GameObject> ();
		for (int i = 0; i < 4; i++) {
			float xPos = -10 + (randFloor.transform.localScale.x * floors.Count);
			GameObject floor = GameObject.Instantiate (randFloor, new Vector3(xPos, -4.5f, 0f), new Quaternion()) as GameObject;
			//Renderer r = floor.GetComponent<Renderer>();
			//r.material.color = Color.Lerp(Color.red,Color.blue, 0.25f * i);// new Color(0.5f,0.5f,0.5f)'i * Color.grey;
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
