using UnityEngine;
using System.Collections;

public class healthScript : MonoBehaviour {

    public int hp = 1;
    public bool isEnemy = true;
    public void Damage(int damageCount)
    {
        hp -= damageCount;

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
        if (shot != null && isEnemy)
        {
                Damage(shot.damage);
                Destroy(shot.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D otherCollider)
    {
        if (otherCollider.gameObject.name == "Meteor")
        {
            Damage(1);
            Destroy(otherCollider.gameObject);

        }
    }
}
