using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeggieParticleController : MonoBehaviour {

	private ParticleSystem myParticleSystem;
	private ParticleSystemRenderer myParticleRenderer;
	public Material[] particleTypes;

	void Start()
	{
		myParticleSystem = GetComponent<ParticleSystem> ();
		myParticleRenderer = GetComponent<ParticleSystemRenderer> ();
	}

	public void SetSelectedVeggie(int selectedVeggie)
	{
		myParticleRenderer.material = particleTypes[selectedVeggie];
	}

	public void ActivateVeggieParticle()
	{
		myParticleSystem.Clear ();
		myParticleSystem.Play ();
	}
}
