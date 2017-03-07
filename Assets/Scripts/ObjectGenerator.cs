using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour {

	public ObjectPooler[] myObjectPooler;
	private int objectTypes;
	private int objectSelected;

	//TIME VARIABLES
	public float spawnTimeMax;
	public float spawnTimeMin;
	private float spawnTimeCounter;
	private bool spawned;

	//POSITION VARIABLES
	public float spawnHeightMax;
	public float spawnHeightMin;
	private float spawnHeight;

	void Start () 
	{
		spawnTimeCounter = Random.Range (spawnTimeMin, spawnTimeMax);
		spawnHeight = Random.Range (spawnHeightMin, spawnHeightMax);
		spawned = false;

		objectTypes = myObjectPooler.Length;
	}

	void Update () 
	{
		if (spawned) {
			spawnTimeCounter = Random.Range (spawnTimeMin, spawnTimeMax);
			spawnHeight = Random.Range (spawnHeightMin, spawnHeightMax);
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
			obj.transform.position = new Vector2 (transform.position.x, spawnHeight);
			obj.transform.rotation = transform.rotation;
			obj.SetActive (true);
			spawned = true;
		}
		spawnTimeCounter -= Time.deltaTime;
	}
}
