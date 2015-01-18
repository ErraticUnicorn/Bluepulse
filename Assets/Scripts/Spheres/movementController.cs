using UnityEngine;
using System.Collections;

public class movementController : MonoBehaviour {

    public Vector2 speed = new Vector2(10, 10);
    public Vector2 direction = new Vector2 (1, 1);

    private Vector2 zeroSpeed = new Vector2(0, 0);

    private Vector2 movement;
    private float accelConst = 1;
    private Vector2 minspeed;

    private Vector3 leftEdge;
    private Vector3 rightEdge;
    private Vector3 bottomEdge;
    private Vector3 topEdge;

    private Vector2 curVelocity;
    private Vector2 curDirection;

    private bool isBlue;
    private Transform blueBall;
    private Vector3 originalPos;

	// Use this for initialization
	void Start () {
        isBlue = this.gameObject.GetComponent<colorController>().isBlue;
        leftEdge = Camera.main.ViewportToWorldPoint (new Vector3(1.0f,0.0f, 0.0f));
        rightEdge = Camera.main.ViewportToWorldPoint ( new Vector3(0.0f,1.0f, 0.0f));
        bottomEdge = Camera.main.ViewportToWorldPoint ( new Vector3(0.0f,1.0f, 0.0f));
        topEdge = Camera.main.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, 0.0f));
        if (isBlue) {
            originalPos = this.transform.position;
            blueBall = this.transform;
        }

	}


    void FixedUpdate() {
        Vector2 curSpeed = this.rigidbody2D.velocity;

        if (transform.position.x > rightEdge.x && !isBlue)
        {
            curSpeed.x = -this.rigidbody2D.velocity.x;
            this.rigidbody2D.velocity = curSpeed;
        }
        if (transform.position.x < leftEdge.x && !isBlue)
        {
            curSpeed.x = -this.rigidbody2D.velocity.x;
            this.rigidbody2D.velocity = curSpeed;
        }

        if (isBlue)
        {
            if (transform.position.x < rightEdge.x - 2 || transform.position.x > leftEdge.x + 2)
            {
                
                Instantiate(blueBall, originalPos, Quaternion.identity);
                this.gameObject.SetActive(false);
            }
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

    public Vector2 getCurDirection(){
        return curDirection;
    }

    public void addForce(float constant, Vector2 direction) {
        curDirection = direction;
        float speedx = speed.x * direction.x;
        float speedy = speed.y * direction.y;
        Vector2 newSpeed = new Vector2(constant * speedx, constant * speedy);
        rigidbody2D.AddForce(newSpeed);
    }

    public void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag == "sphere")
        {
            if (this.gameObject.GetComponent<colorController>().bluePulseActive())
            {
                other.gameObject.GetComponent<colorController>().hitByBlue();
            }
            //gain/remove force from other ball?
            this.addForce(1, -curDirection);
        }
    }
}

