using UnityEngine;
using System.Collections;

public class meteorSpawner : MonoBehaviour {

    public GameObject upperSpawn;
    public GameObject lowerSpawn;
    public Transform meteorPrefab;
    public float meteorTimer = 10;
    private float origTime;
    void Start()
    {
        origTime = meteorTimer;
    }
	// Update is called once per frame
	void Update () {
        meteorTimer -= Time.deltaTime;
        if (meteorTimer <= 0)
        {
            meteorTimer = origTime;
            Transform meteor = Instantiate(meteorPrefab) as Transform;
            float spawnerChance = Random.Range(0, 10);
            if (spawnerChance < 5)
            {
                meteor.position = upperSpawn.transform.position;
            }
            else
            {
                meteor.position = lowerSpawn.transform.position;
            }
        }
	}
}
