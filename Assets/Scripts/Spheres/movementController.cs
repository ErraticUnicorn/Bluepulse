using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class movementController : MonoBehaviour {

    public Vector2 speed = new Vector2(10, 10);
    public Vector2 direction = new Vector2 (1, 1);
    public bool isBlue;
    public bool hasBeenHitByBlue = false;
	public Color myColor;

    private Vector2 movement;
    private float accelConst = 1;
    private Vector2 minspeed;

    private Vector3 leftEdge;
    private Vector3 rightEdge;
    private Vector3 bottomEdge;
    private Vector3 topEdge;
    private Vector3 originalPos;

    private Vector2 curVelocity;
    private Vector2 curDirection;

	// Use this for initialization
	void Start () {
        leftEdge = Camera.main.ViewportToWorldPoint (new Vector3(2.0f,0.0f, 0.0f));
        rightEdge = Camera.main.ViewportToWorldPoint ( new Vector3(-2.0f,0.0f, 0.0f));
        bottomEdge = Camera.main.ViewportToWorldPoint ( new Vector3(0.0f,1.0f, 0.0f));
        topEdge = Camera.main.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, 0.0f));
	}

    void Awake()
    {
        if (isBlue)
        {
            originalPos = this.transform.position;
        }
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

        if (other.gameObject.tag == "sphere" )
        {

            //gain/remove force from other ball?
            this.addForce(5, -curDirection);
            if (other.gameObject.name == "bluepulse")
            {
                hasBeenHitByBlue = true;
            }
        }

        if(this.gameObject.name != "bluepulse" && hasBeenHitByBlue){
            if (other.gameObject.name == "GeneratorSpriteYellow" || other.gameObject.name == "GeneratorSpriteRed"
                || other.gameObject.name == "GeneratorSpriteGreen" || other.gameObject.name == "GeneratorSpritePurple")
            {
				GameObject hitGameObject = other.gameObject;
				Image imageComponent = hitGameObject.GetComponent<Image>();
				if (imageComponent && imageComponent.color == myColor)
				{
					Generator generator = hitGameObject.GetComponent<Generator>();
					if (generator)
					{
						generator.AddValue(10);
					}
				}
                this.gameObject.SetActive(false);
            }
        }

        else
        {
            hasBeenHitByBlue = false;
            this.addForce(5, -curDirection);
        }
    }

     void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name == "Bluepulse Area")
        {
            this.hasBeenHitByBlue = false;
            this.addForce(10, -curDirection);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (isBlue)
        {
            bluePulseSpawner spawner = other.gameObject.GetComponent<bluePulseSpawner>();
            spawner.isBlueBallPresent = false;
        }
    }
}