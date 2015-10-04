using UnityEngine;
using System.Collections;

public class bluePulseSpawner : MonoBehaviour {

    public bool isBlueBallPresent = true;
    public movementController bluepulse;

    void OnMouseDown()
    {
        if (!isBlueBallPresent)
        {
			bluepulse.snapToParent();
			bluepulse.stopMovement();
			bluepulse.zeroForce();
            isBlueBallPresent = true;
        }
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.Equals(bluepulse.gameObject))
		{
			isBlueBallPresent = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.Equals(bluepulse.gameObject))
		{
			isBlueBallPresent = false;
		}
	}
}
