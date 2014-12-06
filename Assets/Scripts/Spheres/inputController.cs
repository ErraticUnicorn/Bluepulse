using UnityEngine;
using System.Collections;

public class inputController : MonoBehaviour {

    private bool actionOngoing;
    private Vector3 lastPos;
    private Vector3 mousePos;
    private colorController currentColor;
    private movementController movement;
	public float heldPercentage;
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
			heldPercentage = Mathf.Min(heldPercentage + Time.deltaTime / maxHoldTime, 1.0f);
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
        if (actionOngoing) {
            Vector3 pos = Input.mousePosition;
            pos.z = transform.position.z - Camera.main.transform.position.z;
            mousePos = Camera.main.ScreenToWorldPoint(pos);
            Vector3 heading = mousePos - lastPos;
            float distance = heading.magnitude;
            Vector3 direction = heading / distance;
            movement.addForce(distance * heldPercentage, direction);
        }
        actionOngoing = false;
    }
}
