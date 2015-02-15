using UnityEngine;
using System.Collections;

public class buttonScript : MonoBehaviour {

    public GameObject Ship;

	void OnMouseDown () {
            weaponsScript weapon = Ship.GetComponent<weaponsScript>();
            if (weapon != null)
            {
                weapon.Attack(false);
            }
	}
}
