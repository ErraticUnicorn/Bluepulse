using UnityEngine;
using System.Collections;

public class buttonScript : MonoBehaviour {

    public GameObject Ship;

	void OnMouseDown () {
            weaponsScript weapon = Ship.GetComponent<weaponsScript>();
            if (weapon != null)
            {
				Generator generator = Ship.GetComponent<Generator>();
				if (generator.isReady())
				{
					generator.Activate();
					weapon.Attack(false);
				}
			}
	}
}
