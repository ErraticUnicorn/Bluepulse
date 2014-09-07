using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class sphereSpawner : MonoBehaviour {

    public GameObject sphere;
    public int spherePoolCount = 20;
    private GameObject[] spheres;
    private List<GameObject> spawnedSpheres;

    Vector3 leftSpawnpoint;
    Vector3 rightSpawnpoint;


	// Use this for initialization
	void Start () {
        spawnedSpheres = new List<GameObject>();

	}

    void Awake() {
        spheres = new GameObject[spherePoolCount];
        for (int i = 0; i < spheres.Length; i++) {
            spheres[i] = Instantiate(sphere) as GameObject;
            spheres[i].SetActive(false);
            spheres[i].transform.parent = this.transform.parent;
        }
        Vector3 leftSpawnpoint = Camera.main.ViewportToWorldPoint(new Vector3(-.20f, 0.5f, 0.0f));
        Vector3 rightSpawnpoint = Camera.main.ViewportToWorldPoint(new Vector3(1.20f, 0.5f, 0.0f));

        for (int i = 0; i < 10; i++) {
            movementController mvmt = spheres[i].GetComponent<movementController>();
            spheres[i].SetActive(true);
            Vector2 direction;
            direction.y = Random.Range(-.75f, .75f);
            float leftOrRight = Random.Range(0f, 1f);
            if(leftOrRight < .5){
                spheres[i].transform.position = new Vector3(leftSpawnpoint.x, leftSpawnpoint.y, this.transform.position.z);
                direction.x = Random.Range(0f, 1f);
                mvmt.addForce(1, direction);
            } else {
                spheres[i].transform.position = new Vector3(rightSpawnpoint.x, rightSpawnpoint.y, this.transform.position.z);
                direction.x = Random.Range(-1f, 0f);
                mvmt.addForce(1, direction);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
	    
	}
}
