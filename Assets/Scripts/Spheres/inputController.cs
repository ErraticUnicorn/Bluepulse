using UnityEngine;
using System.Collections;

public class inputController : MonoBehaviour {

    private bool actionOngoing;
    private Vector3 lastPos;
    private Vector3 mousePos;
    private colorController currentColor;
    private movementController movement;
	private float heldPercentage;
	public float maxHoldTime;

	// Use this for initialization
	void Start () {
        actionOngoing = false;
        currentColor = this.gameObject.GetComponent<colorController>();
        movement = this.gameObject.GetComponent<movementController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (actionOngoing && heldPercentage <= 1.0f)
		{
			heldPercentage = heldPercentage + Time.deltaTime / maxHoldTime;
		}
	}

    void OnMouseDown() {
        if (currentColor.sphereColor == sphereType.BLUE) {
            currentColor.setBlue();
            lastPos = this.transform.position;
            movement.stopMovement();
            actionOngoing = true;
			heldPercentage = 0.0f;
        }
    }

    void OnMouseUp() {
        if (actionOngoing)
		{
			Vector3 pos = Input.mousePosition;
			pos.z = transform.position.z - Camera.main.transform.position.z;
			mousePos = Camera.main.ScreenToWorldPoint(pos);
			Vector3 heading = mousePos - lastPos;
			float distance = heading.magnitude;
			Vector3 direction;
			if (heldPercentage <= 1.0f)
			{
				direction = heading / distance;
			}
			else
			{
				direction = Random.insideUnitCircle.normalized;
			}
            movement.addForce(distance * (heldPercentage <= 1.0f ? heldPercentage : 1.0f), direction);
        }
        actionOngoing = false;
    }
}
