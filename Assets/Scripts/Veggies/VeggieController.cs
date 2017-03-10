using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeggieController : MonoBehaviour {

	public int selectedVeggie;
	private VeggieTypeSelector myVeggieTypeSelector;
	private PlayerJump myPlayerJump;

	// Use this for initialization
	void Start () {
		myVeggieTypeSelector = gameObject.GetComponent<VeggieTypeSelector> ();
		myPlayerJump = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerJump> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.name == "Player") 
		{
			//theScoreManager.AddVeggieScore (scoreToGive);



			selectedVeggie = myVeggieTypeSelector.getVeggieType();

			if (selectedVeggie == 2) 
			{
				myPlayerJump.setPowerUp ();
			}
			//Sound Effect included here

			//Particle Effect dependent on the selected veggie
			//Object.Instantiate (myPoof, gameObject.transform.position, poofRotation);

			gameObject.SetActive (false);
		}
	}
}
