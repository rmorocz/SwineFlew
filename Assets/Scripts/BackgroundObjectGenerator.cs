using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundObjectGenerator : MonoBehaviour {

	public ObjectPooler[] myObjectPooler;
	private int objectTypes;
	private int objectSelected;

	//TIME VARIABLES
	public float spawnTimeMax;
	public float spawnTimeMin;
	private float spawnTimeCounter;
	private bool spawned;

	void Start () 
	{
		spawnTimeCounter = Random.Range (spawnTimeMin, spawnTimeMax);
		spawned = false;

		objectTypes = myObjectPooler.Length;
	}

	void Update () 
	{
		if (spawned) 
		{
			spawnTimeCounter = Random.Range (spawnTimeMin, spawnTimeMax);
			spawned = false;
		}

		objectSpawn ();
	}

	void objectSpawn ()
	{
		if (spawnTimeCounter <= 0) 
		{
			objectSelected = Random.Range (0, objectTypes);

			GameObject obj = myObjectPooler[objectSelected].GetPooledObject ();
			if (obj == null) {
				return;
			}
			obj.transform.position = transform.position;
			obj.transform.rotation = transform.rotation;
			obj.SetActive (true);
			spawned = true;
		}
		spawnTimeCounter -= Time.deltaTime;
	}
}
