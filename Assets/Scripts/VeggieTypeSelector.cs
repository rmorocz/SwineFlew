using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeggieTypeSelector : MonoBehaviour {

	//SPRITE VARIABLES
	private SpriteRenderer mySpriteRenderer;
	public Sprite[] sprites;
	private int spriteTypes;
	public int selectedSprite;

	void Awake () 
	{
		mySpriteRenderer = GetComponent <SpriteRenderer> ();
		spriteTypes = sprites.Length;
		selectedSprite = Random.Range (0, spriteTypes);
		mySpriteRenderer.sprite = sprites [selectedSprite];
	}

	void OnDisable() 
	{
		selectedSprite = Random.Range (0, spriteTypes);
		mySpriteRenderer.sprite = sprites [selectedSprite];
	}

	public int getSpriteType ()
	{
		return selectedSprite;
	}
}
