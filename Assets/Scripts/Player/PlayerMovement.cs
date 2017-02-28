using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D myRigidbody;		//Player's Rigidbody

	//MOVEMENT VARIABLES
	public float playerSpeed;

	//START FUNCTION
	void Start ()
	{
		myRigidbody = GetComponent<Rigidbody2D> ();	
	}

	//UPDATE FUNCTION
	void Update ()
	{
		myRigidbody.velocity = new Vector2 (playerSpeed, myRigidbody.velocity.y);
	}

	/*
	//MOVEMENT VARIABLES
	public Transform movementThreshold;

	//JUMPING VARIABLES
	private PlayerJump myPlayerJump;
	private bool jumping;

	//SPEED VARIABLES
	public float speed;
	private float currentSpeed;

	// Use this for initialization
	void Start () 
	{
		myRigidbody = GetComponent<Rigidbody2D> ();	
		myPlayerJump = GetComponent<PlayerJump> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		jumping = myPlayerJump.getJumpingStatus ();
		currentSpeed = myRigidbody.velocity.x;
		if (jumping && myRigidbody.position.x < movementThreshold.transform.position.x) 
		{
			myRigidbody.velocity = new Vector2 (speed, myRigidbody.velocity.y);
		}

		if (jumping && currentSpeed < 0) 
		{
			myRigidbody.velocity = new Vector2 (0, myRigidbody.velocity.y);
		}
	}
	*/
}
