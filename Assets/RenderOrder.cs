using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderOrder : MonoBehaviour {

	private MeshRenderer myMeshRenderer;

	// Use this for initialization
	void Start () {
		myMeshRenderer = gameObject.GetComponent<MeshRenderer> ();
		myMeshRenderer.sortingLayerName = "Road";
		myMeshRenderer.sortingOrder = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
