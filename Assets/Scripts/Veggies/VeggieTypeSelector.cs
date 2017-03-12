using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeggieTypeSelector : MonoBehaviour {

	[Header("Veggie Types")]
	public Sprite[] veggieSprites;
	private int selectedVeggie;
	private SpriteRenderer mySpriteRenderer;
	private int randomSelection;

	[Header("Rate of Appearance")]
	public int carrotRate;
	public int beetRate;
	public int pepperRate;


	void Awake () 
	{
		mySpriteRenderer = gameObject.GetComponent <SpriteRenderer> ();
	}

	void OnEnable() 
	{
		randomSelection = Random.Range (0, 100);				//This value is used to select the veggie type, allowing for different veggie probabilities assignment

		//VEGGIE SELECTION
		if (randomSelection <= carrotRate) 
		{
			selectedVeggie = 0;
		} 
		else if (randomSelection > carrotRate && randomSelection <= (beetRate + carrotRate)) 
		{
			selectedVeggie = 1;
		} 
		else if (randomSelection > (beetRate + carrotRate))
		{
			selectedVeggie = 2;
		}

		mySpriteRenderer.sprite = veggieSprites [selectedVeggie];
	}

	public int getVeggieType ()
	{
		return selectedVeggie;
	}
}
