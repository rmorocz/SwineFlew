using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeggieTypeSelector : MonoBehaviour {

	//SPRITE VARIABLES
	private SpriteRenderer mySpriteRenderer;
	public Sprite[] sprites;

	public int selectedSprite;


	[Header("Rate of Appearance")]
	public int carrotRate;
	public int beetRate;
	public int pepperRate;


	private int spriteTypes;

	private int randomSelection;

	void Awake () 
	{
		mySpriteRenderer = gameObject.GetComponent <SpriteRenderer> ();
		spriteTypes = sprites.Length;
	}

	void OnEnable() 
	{
		randomSelection = Random.Range (0, 100);				//This value is used to select the veggie type, allowing for different veggie probabilities assignment

		//VEGGIE SELECTION
		if (randomSelection <= carrotRate) 
		{
			selectedSprite = 0;
		} 
		else if (randomSelection > carrotRate && randomSelection <= (beetRate + carrotRate)) 
		{
			selectedSprite = 1;
		} 
		else if (randomSelection > (beetRate + carrotRate))
		{
			selectedSprite = 2;
		}

		mySpriteRenderer.sprite = sprites [selectedSprite];
	}

	public int getSpriteType ()
	{
		return selectedSprite;
	}
}
