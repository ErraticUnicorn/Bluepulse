﻿using UnityEngine;
using System.Collections;

public class moveScript : MonoBehaviour {

    public Vector2 speed = new Vector2(2, 10);
    public Vector2 direction = new Vector2(-1, 0);
    private Vector2 movement;
	// Use this for initialization
    void Update()
      {
        // 2 - Movement
        movement = new Vector2(
          speed.x * direction.x,
          speed.y * direction.y);
      }

      void FixedUpdate()
      {
        // Apply movement to the rigidbody
        GetComponent<Rigidbody2D>().velocity = movement;
      }

}
