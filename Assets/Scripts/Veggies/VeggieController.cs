using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeggieController : MonoBehaviour {

	private int selectedVeggie;
	private VeggieTypeSelector myVeggieTypeSelector;
	private PlayerJump myPlayerJump;
	private VeggieParticleController particleController;
	private SpriteRenderer mySpriteRenderer;
	private bool isEaten;


	void Start () 
	{
		myVeggieTypeSelector = gameObject.GetComponent<VeggieTypeSelector> ();
		myPlayerJump = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerJump> ();

		particleController = this.gameObject.GetComponentInChildren<VeggieParticleController> ();

		isEaten = false;

		mySpriteRenderer = this.gameObject.GetComponent<SpriteRenderer> ();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (!isEaten) 
		{
			if (other.gameObject.name == "Player") 
			{
				isEaten = true;
				selectedVeggie = myVeggieTypeSelector.getVeggieType ();
				//theScoreManager.AddVeggieScore (scoreToGive);

				if (selectedVeggie == 2) 
				{
					myPlayerJump.setPowerUp ();
				}

				//ACTIVATE SOUND EFFECT-------------------------------------------------------------

				//ACTIVATE PARTICLE EFFECT----------------------------------------------------------
				particleController.SetSelectedVeggie (selectedVeggie);
				particleController.ActivateVeggieParticle ();

				//DEACTIVATE SPRITE AS EATEN STATE--------------------------------------------------
				mySpriteRenderer.enabled = false;

			}
		}
	}

	public void resetVeggie ()
	{
		isEaten = false;
		mySpriteRenderer.enabled = true;
	}
}
