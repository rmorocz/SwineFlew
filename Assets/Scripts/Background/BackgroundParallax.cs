using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour {

	public Vector2 scrollSpeed;
	private Vector2 offset;
	private MeshRenderer myMeshRenderer;

	void Start () 
	{
		myMeshRenderer = gameObject.GetComponent<MeshRenderer> ();
		offset = myMeshRenderer.material.GetTextureOffset ("_MainTex");
	}

	void Update () 
	{
		offset += scrollSpeed * Time.deltaTime;
		myMeshRenderer.material.SetTextureOffset("_MainTex", offset);
	}
}
