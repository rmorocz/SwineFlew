using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour {

	private GameObject destructionPoint;

	void Start () 
	{
		destructionPoint = GameObject.Find ("DestructionPoint");
	}

	void Update () 
	{
		if (transform.position.x < destructionPoint.transform.position.x) 
		{
			gameObject.SetActive (false);
		}
	}
}
