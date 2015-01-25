using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class sphereSpawner : MonoBehaviour {

    public GameObject[] sphereType;
    public int spherePoolCount = 20;
    private GameObject[] spheres;
    private List<GameObject> spawnedSpheres;
    public bool leftSpawn;
    public bool rightSpawn;
    private int dirX;


	// Use this for initialization
	void Start () {
        spawnedSpheres = new List<GameObject>();
        if (leftSpawn)
        {
            dirX = -1;

        }
        else
        {
            dirX = 1;
        }

	}

    void Awake() {
        spheres = new GameObject[spherePoolCount];
        for (int i = 0; i < spheres.Length; i++) {
            int arrayIndex = Random.Range(0, sphereType.Length);
            GameObject sphere = sphereType[arrayIndex];
            spheres[i] = Instantiate(sphere) as GameObject;
            spheres[i].SetActive(false);
            spheres[i].transform.parent = this.transform.parent;
        }

        for (int i = 0; i < spherePoolCount/2; i++) {
            //spheres[i].SetActive(true);
            Vector2 position;
            position.y = this.transform.position.y;
            position.x = this.transform.position.x;
            spheres[i].transform.position = new Vector3(position.x, position.y, -1);
           
        }

    }

    // Update is called once per frame
    int timer = 0;
    int index = 0;
    void Update()
    {
        timer--;
        if (timer <= 0)
        {
            movementController mvmt = spheres[index].GetComponent<movementController>();
            spheres[index].SetActive(true);
            Vector2 direction;
            direction.y = Random.Range(-.75f, .75f);
            direction.x = Random.Range(-1, 0 * dirX);
            mvmt.addForce(5, direction*dirX);
            timer = 180;
            index++;
            if (index >= spherePoolCount / 2)
                index = 0;
        }
	}
}
