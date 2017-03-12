using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour {

	private Rigidbody2D myRigidbody;		//Player's Rigidbody

	//JUMP VARIABLES
	public float jumpForce;
	public float jumpTime;					//Length of the player's jump
	private float jumpTimeCounter;			//How long has the Player been Jumping for
	public int extraJump;
	private int extraJumpCounter;
	private bool jumping;

	//GROUND CHECK VARIABLES
	private bool grounded;
	private bool groundedFront;
	private bool groundedBack;
	public Transform groundCheckFront;
	public Transform groundCheckBack;
	public float groundCheckRadius;
	public LayerMask whatIsGround; 							//Both Ground and Platforms are considered "Ground"

	//RUNNING VARIABLES
	private bool running;
	public LayerMask whatIsPlatform;

	//FLYING VARIABLES
	public bool canFly;
	public float flyForce;
	public float flyingTime;
	private float flyingTimeCounter;


	// START FUNCTION: called when the game starts
	void Start () 
	{
		myRigidbody = GetComponent<Rigidbody2D> ();			//Calls the Rigidbody from the object that this script is attached to
		jumpTimeCounter = jumpTime;							//Assigns JumpTime (public variable) to jumpTimeCounter (public variable that is used within our code)
		extraJumpCounter = extraJump;
	}

	// UPDATE FUNCTION: called on every frame
	void Update () 
	{
		canPlayerJump ();
		playerRunning ();

		if (!canFly) 
		{
			playerJump ();
		}
	}

	void FixedUpdate()
	{
		if (canFly) 
		{
			playerFly ();
		}
	}




	// PLAYER JUMP FUNCTION: in charge of making the player jump when Input Key is pressed
	void playerJump ()
	{
		//Jumping off the floor----------------------------------------------------------------
		if (Input.GetKeyDown (KeyCode.Space) && grounded)
		{
			myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);				
			jumpTimeCounter = jumpTime;
		}
			
		//Extra Jumping-----------------------------------------------------------------------
		if (Input.GetKeyDown (KeyCode.Space) && extraJumpCounter > 0 && jumping)
		{
			myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);				
			jumpTimeCounter = jumpTime;
			extraJumpCounter -= 1;
		}

		//Jumping Logic-------------------------------------------------------------------------
		if (Input.GetKey (KeyCode.Space) && jumping) 
		{
			if (jumpTimeCounter > 0 && extraJumpCounter >= 0) 
			{
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}
		}
			
		if (Input.GetKeyUp (KeyCode.Space)) 
		{
			jumpTimeCounter = 0;
		}
	}



	// PLAYER FLY FUNCTION: in charge of making the player jump when Input Key is pressed
	void playerFly ()
	{
		//Flying off the floor----------------------------------------------------------------
		bool flyingActive= Input.GetKey (KeyCode.Space);

		if (flyingActive) 
		{
			//myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
			myRigidbody.AddForce (new Vector2 (0, flyForce));
		}

		if (flyingTimeCounter <= 0) 
		{
			canFly = false;
		}

		flyingTimeCounter -= Time.deltaTime;

	}



	// CAN PLAYER JUMP? FUNCTION: determine if the player is capable of jumping or not
	void canPlayerJump(){
		groundedFront = Physics2D.OverlapCircle (groundCheckFront.position, groundCheckRadius, whatIsGround);
		groundedBack = Physics2D.OverlapCircle (groundCheckBack.position, groundCheckRadius, whatIsGround);

		if (groundedFront || groundedBack) 
		{
			grounded = true;
		}

		if (!groundedFront && !groundedBack) 
		{
			grounded = false;
		}

		if (!grounded) 
		{
			jumping = true;
		}

		if (grounded && jumping) 
		{
			extraJumpCounter = extraJump;
			jumpTimeCounter = jumpTime;	
			jumping = false;
		}
	}

	void playerRunning ()
	{
		groundedFront = Physics2D.OverlapCircle (groundCheckFront.position, groundCheckRadius, whatIsPlatform);
		groundedBack = Physics2D.OverlapCircle (groundCheckBack.position, groundCheckRadius, whatIsPlatform);

		if (groundedFront || groundedBack) 
		{
			running = false;
		}

		if (!groundedFront && !groundedBack) 
		{
			running = true;
		}
	}

	// JUMPING STATUS FUNCTION: determine if the player is capable of jumping or not
	public bool getJumpingStatus ()
	{
		return jumping;
	}

	public bool getGroundedStatus ()
	{
		return grounded;
	}

	public bool getRunningStatus ()
	{
		return running;
	}



	// ACTIVATE FLYING POWER UP FROM OTHER SCRIPTS
	public void setPowerUp()
	{
		canFly = true;
		flyingTimeCounter = flyingTime;
	}
}