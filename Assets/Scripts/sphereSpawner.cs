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
			float rValue = Random.value;
            int arrayIndex = rValue <= .4f ? 1 : rValue <= .7f ? 2 : rValue <= .9f ? 0 : 3; // Weight sphere types.
            GameObject sphere = sphereType[arrayIndex];
            spheres[i] = Instantiate(sphere) as GameObject;
            spheres[i].SetActive(false);
            spheres[i].transform.parent = this.transform.parent;
        }
    }

    // Update is called once per frame
    float timer = 5.0f;
	const float timerMax = 5.0f;
    int index = 0;
    void Update()
    {
		timer -= Time.deltaTime;
        if (timer <= 0)
        {
			GameObject sphere;
			int finalIndex = Mathf.Max(index - 1, 0);
			// Find next non-active sphere. Avoid infinite loop.
			do
			{

				sphere = spheres[index];
				index = (index + 1) % spherePoolCount;
			}
			while (sphere.activeInHierarchy && index != finalIndex);
			sphere.SetActive(true);

			Vector2 position;
			position.y = this.transform.position.y;
			position.x = this.transform.position.x;
			sphere.transform.position = new Vector3(position.x, position.y, -1);

            Vector2 direction;
            direction.y = Random.Range(-.75f, .75f);
            direction.x = Random.Range(-1, 0 * dirX);
			movementController mvmt = sphere.GetComponent<movementController>();
            mvmt.addForce(5, direction*dirX);

            timer = timerMax;
        }
	}
}
