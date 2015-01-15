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

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint (new Vector3(1.0f,0.0f, 0.0f));
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint ( new Vector3(0.0f,1.0f, 0.0f));
        Vector3 bottomEdge = Camera.main.ViewportToWorldPoint ( new Vector3(0.0f,1.0f, 0.0f));
        Vector3 topEdge = Camera.main.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, 0.0f));

        for (int i = 0; i < spherePoolCount/2; i++) {
            movementController mvmt = spheres[i].GetComponent<movementController>();
            spheres[i].SetActive(true);
            Vector2 direction;
            direction.y = Random.Range(-.75f, .75f);
            Vector2 position;
            position.y = Random.Range(bottomEdge.y, topEdge.y);
            position.x = Random.Range(leftEdge.x, rightEdge.x);
            spheres[i].transform.position = new Vector3(position.x, position.y, this.transform.position.z);
            direction.x = Random.Range(-1f, 1f);
            mvmt.addForce(1, direction);
           
        }

    }

    // Update is called once per frame
    void Update()
    {
	    
	}
}
