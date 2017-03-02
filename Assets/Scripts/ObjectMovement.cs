using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour {

	private Rigidbody2D myRigidbody;

	//SPEED VARIABLES
	public float speed;

	// Use this for initialization
	void Start () 
	{
		myRigidbody = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () 
	{
		myRigidbody.velocity = new Vector2 (speed, myRigidbody.velocity.y);
	}
}
