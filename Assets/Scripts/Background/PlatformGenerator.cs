using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public ObjectPooler[] myObjectPooler;
	private int platformLevelSelected;
	private bool levelTransition;

	//PLATFORM VARIABLES
	public Transform platformGenerationPoint;
	private float platformWidth;

	//VEGGIE VARIABLES
	private int veggieCounter;

	void Start () 
	{
		levelTransition = false;
		veggieCounter = 0;
	}

	void Update ()
	{
		if (transform.position.x < platformGenerationPoint.position.x) 
		{
			levelSelector ();

			GameObject obj = myObjectPooler[platformLevelSelected].GetPooledObject ();

			if (obj == null) 
			{
				return;
			}

			platformWidth = obj.GetComponent<BoxCollider2D>().size.x;
			transform.position = new Vector3 (transform.position.x + platformWidth, transform.position.y, transform.position.z);

			obj.transform.position = transform.position;
			obj.transform.rotation = transform.rotation;
			obj.SetActive (true);
			veggieCounter += 1;
		}
	}
		
	void levelSelector ()
	{
		if (veggieCounter <= 4) 
		{
			platformLevelSelected = 0;
		} 
		else if (veggieCounter > 4) 
		{
			if (!levelTransition) 
			{
				platformLevelSelected = 1;
				levelTransition = true;
			} 
			else 
			{
				platformLevelSelected = 2;
			}

		}
	}
}
