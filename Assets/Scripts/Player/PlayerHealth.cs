using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float health;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Damage is an optional parameter, averageDamageAmount = 10 by default
	public void TakeDamage(float damage = 10){
		health -= damage;
	}
}
