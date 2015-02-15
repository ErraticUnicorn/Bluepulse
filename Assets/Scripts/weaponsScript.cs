using UnityEngine;
using System.Collections;

public class weaponsScript : MonoBehaviour {

    public Transform shotPrefab;
    public GameObject topGun;
    public GameObject bottomGun;

    public float shootingRate = 0.25f;

    private float shootCooldown;

    void Start()
    {
        shootCooldown = 0f;
    }

    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }
    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            shootCooldown = shootingRate;

            Transform shotTransform1 = Instantiate(shotPrefab) as Transform;
            Transform shotTransform2 = Instantiate(shotPrefab) as Transform;


            shotTransform1.position = topGun.transform.position;
            shotTransform2.position = bottomGun.transform.position;
        }
    }

    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }
}
