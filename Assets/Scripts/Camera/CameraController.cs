using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public PlayerController thePlayer;
	private Vector3 lastPlayerPosition;
	private float distanceToMove;

	//START FUNCTION
	void Start () 
	{
		thePlayer = FindObjectOfType<PlayerController> ();

		lastPlayerPosition = thePlayer.transform.position;
	}
	
	//UPDATE FUNCTION
	void Update () 
	{
		distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;

		transform.position = new Vector3 (transform.position.x + distanceToMove, transform.position.y, transform.position.z);

		lastPlayerPosition = thePlayer.transform.position;
	}
}
