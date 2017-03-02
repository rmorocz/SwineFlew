using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour {

	public GameObject pooledObject;
	public int pooledAmount = 10;
	public bool willGrow = true;			//Is the list of specific objects attached to this script allowed to grow?

	List<GameObject> pooledObjects;

	void Start () 
	{
		pooledObjects = new List<GameObject> ();

		for (int i = 0; i < pooledAmount; i++) 
		{
			GameObject obj = (GameObject) Instantiate (pooledObject);
			obj.SetActive (false);
			pooledObjects.Add (obj);
		}
	}

	public GameObject GetPooledObject()
	{
		for (int i = 0; i < pooledObjects.Count; i++) 
		{
			if (!pooledObjects [i].activeInHierarchy) 
			{
				return pooledObjects [i];
			}
		}

		if (willGrow)			//If the list is not long enough and the specific list of objects is allowed to grow
		{
			GameObject obj = (GameObject) Instantiate (pooledObject);
			pooledObjects.Add (obj);
			return obj;
		}

		return null;
	}
}
