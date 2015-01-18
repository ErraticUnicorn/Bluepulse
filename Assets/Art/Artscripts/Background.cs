using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour 
{
	private Vector3 startPos;
	private Vector3 backPos;
	public float width = 14.22f;
	private float X;
	private float Y;
	
	void Start()
	{
		startPos = transform.position;
	}
	
	void Update()
	{
		if( moves )Move ();
		if( this.transform.position.x <= -(width*0.8f) )ResetSprite();
	}
	private bool moves = true;
	public float moveSpeed = 0;
	private Vector3 movDir = new Vector3(-1,0,0);
	
	void Move()
	{
		this.transform.position += moveSpeed * Time.deltaTime * movDir;
	}
	
	void ResetSprite()
	{
		//calculate current position
		backPos = gameObject.transform.position;
		//calculate new position
		X = backPos.x + width*2;
		//move to new position when invisible
		gameObject.transform.position = new Vector3 (X, startPos.y, startPos.z);
	}
}
