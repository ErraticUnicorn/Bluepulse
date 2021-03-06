﻿using UnityEngine;
using System.Collections;

public class inputController : MonoBehaviour
{

	private bool actionOngoing;
	private Vector3 lastPos;
	private Vector3 mousePos;
	private movementController movement;
	// Use this for initialization
	void Start()
	{
		actionOngoing = false;
		movement = this.gameObject.GetComponent<movementController>();
	}
	
	// Update is called once per frame


	void OnMouseDown()
	{
		lastPos = this.transform.position;
		movement.stopMovement();
		movement.zeroForce();
		movement.root();
		actionOngoing = true;
	}

	void OnMouseUp()
	{
		if (actionOngoing)
		{
			movement.unroot();
			Vector3 pos = Input.mousePosition;
			pos.z = transform.position.z - Camera.main.transform.position.z;
			mousePos = Camera.main.ScreenToWorldPoint(pos);
			Vector3 heading = mousePos - lastPos;
			float distance = heading.magnitude;
			Vector3 direction = heading / distance;
			movement.addForce(distance + 5, -direction);
		}
	}
}
