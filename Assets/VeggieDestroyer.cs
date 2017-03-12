using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeggieDestroyer : MonoBehaviour {

	private GameObject destructionPoint;
	private VeggieController myVeggieController;


	void Start () 
	{
		myVeggieController = this.gameObject.GetComponent<VeggieController> ();
		destructionPoint = GameObject.Find ("DestructionPoint");
	}

	void Update () 
	{
		if (transform.position.x < destructionPoint.transform.position.x) 
		{
			myVeggieController.resetVeggie ();											//Call function to reset veggie to original status
			gameObject.SetActive (false);
		}
	}
}
