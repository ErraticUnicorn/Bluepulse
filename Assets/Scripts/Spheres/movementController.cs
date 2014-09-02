using UnityEngine;
using System.Collections;

public class movementController : MonoBehaviour {

    public Vector2 speed = new Vector2(5, 5);
    public Vector2 direction = new Vector2 (1, 1);

    private Vector2 movement;
    private float accelConst = 1;
    private Vector2 minspeed;

    private Vector3 leftEdge;
    private Vector3 rightEdge;
    private Vector3 bottomEdge;
    private Vector3 topEdge;

	// Use this for initialization
	void Start () {
        leftEdge = Camera.main.ViewportToWorldPoint (new Vector3(0.0f,0.0f, 0.0f));
        rightEdge = Camera.main.ViewportToWorldPoint ( new Vector3(1.0f,0.0f, 0.0f));
        bottomEdge = Camera.main.ViewportToWorldPoint ( new Vector3(0.0f,0.0f, 0.0f));
        topEdge = Camera.main.ViewportToWorldPoint(new Vector3(0.0f, 1.0f, 0.0f));

        var randomNumber = Random.Range(0, 2);
        if (randomNumber <= .5f)
        {
            rigidbody2D.AddForce(speed);
        }
        else
        {
            rigidbody2D.AddForce(-speed);
        }
	}

    void FixedUpdate() {
        Vector2 curSpeed = this.rigidbody2D.velocity;

        if (transform.position.x > rightEdge.x)
        {
            Debug.Log("Off the screen");
            curSpeed.x = -this.rigidbody2D.velocity.x;
            this.rigidbody2D.velocity = curSpeed;
        }
        if (transform.position.x < leftEdge.x)
        {
            Debug.Log("Off the screen");
            curSpeed.x = -this.rigidbody2D.velocity.x;
            this.rigidbody2D.velocity = curSpeed;
        }
        if (transform.position.y < bottomEdge.y)
        {
            Debug.Log("off the bottom");
            curSpeed.y = -this.rigidbody2D.velocity.y;
            this.rigidbody2D.velocity = curSpeed;
        }
        if (transform.position.y > topEdge.y)
        {
            Debug.Log("off the top");
            curSpeed.y = -this.rigidbody2D.velocity.y;
            this.rigidbody2D.velocity = curSpeed;
        }


    }


}