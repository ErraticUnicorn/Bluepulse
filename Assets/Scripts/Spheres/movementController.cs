using UnityEngine;
using System.Collections;

public class movementController : MonoBehaviour {

    public Vector2 speed = new Vector2(10, 10);
    public Vector2 direction = new Vector2 (1, 1);

    private Vector2 movement;
    private float accelConst = 1;
    private Vector2 minspeed;

    private Vector3 leftEdge;
    private Vector3 rightEdge;
    private Vector3 bottomEdge;
    private Vector3 topEdge;

    private Vector2 curVelocity;

	// Use this for initialization
	void Start () {
        leftEdge = Camera.main.ViewportToWorldPoint (new Vector3(-.25f,0.0f, 0.0f));
        rightEdge = Camera.main.ViewportToWorldPoint ( new Vector3(1.25f,0.0f, 0.0f));
        bottomEdge = Camera.main.ViewportToWorldPoint ( new Vector3(0.0f,-.25f, 0.0f));
        topEdge = Camera.main.ViewportToWorldPoint(new Vector3(0.0f, 1.25f, 0.0f));

	}

    void FixedUpdate() {
        Vector2 curSpeed = this.rigidbody2D.velocity;

        if (transform.position.x > rightEdge.x)
        {
            curSpeed.x = -this.rigidbody2D.velocity.x;
            this.rigidbody2D.velocity = curSpeed;
        }
        if (transform.position.x < leftEdge.x)
        {
            curSpeed.x = -this.rigidbody2D.velocity.x;
            this.rigidbody2D.velocity = curSpeed;
        }
        if (transform.position.y < bottomEdge.y)
        {
            curSpeed.y = -this.rigidbody2D.velocity.y;
            this.rigidbody2D.velocity = curSpeed;
        }
        if (transform.position.y > topEdge.y)
        {
            curSpeed.y = -this.rigidbody2D.velocity.y;
            this.rigidbody2D.velocity = curSpeed;
        }
    }

    public void stopMovement() {
        curVelocity = this.rigidbody2D.velocity;
        this.rigidbody2D.velocity = Vector2.zero;
    }

    public void resumeMovement() {
        rigidbody2D.AddForce(curVelocity);
    }

    public void addForce(float constant, Vector2 direction) {
        float speedx = speed.x * direction.x;
        float speedy = speed.y * direction.y;
        Vector2 newSpeed = new Vector2(constant * speedx, constant * speedy);
        rigidbody2D.AddForce(newSpeed);
    }
}