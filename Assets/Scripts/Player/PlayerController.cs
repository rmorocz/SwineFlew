using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D myRigidbody;


	// ANIMATOR VARIABLES
	private Animator myAnimator;
	private PlayerJump myPlayerJump;
	private bool running;
	private bool grounded;


	/*
	public GameManager theGameManager;

	public Transform playerDestructionPoint;

	public Transform collisionCheck;
	public float collisionCheckRadius;
	public LayerMask whatIsBumper;
	private bool collided;
	*/

	void Start () 
	{
		myRigidbody = GetComponent<Rigidbody2D> ();

		myPlayerJump = GetComponent<PlayerJump> ();

		myAnimator = GetComponent<Animator> ();
	}

	void Update(){

		// UPDATING ANIMATOR
		grounded = myPlayerJump.getGroundedStatus ();
		running = myPlayerJump.getRunningStatus ();

		myAnimator.SetFloat ("SpeedY", myRigidbody.velocity.y);
		myAnimator.SetBool ("Running", running);
		myAnimator.SetBool ("Grounded", grounded);

		/* USE TO KILL PIG
		collided = Physics2D.OverlapCircle (collisionCheck.position, collisionCheckRadius, whatIsBumper);
		if (collided) {
			theGameManager.RestartGame ();
		}
		if (transform.position.x <= playerDestructionPoint.position.x) {
			theGameManager.RestartGame ();
		}
		*/
	}

	public void setPowerUp(){

	}
}
